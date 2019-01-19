using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.General
{
    public class RRepository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        #region .:: Prorpiedades ::.
        protected SolutionContext _db;
        #endregion

        #region .:: Construtor ::.
        public RRepository(SolutionContext db)
        {
            _db = db;
        }

        #endregion

        public void Add(TEntity entity)
        {
            entity = BeforAdd(entity);
            using (var tc = _db.Database.BeginTransaction())
            {
                try
                {                   
                    _db.Entry(entity).State = EntityState.Added;
                    _db.SaveChanges();
                    tc.Commit();
                }
                catch (Exception ex)
                {
                    tc.Rollback();
                    throw new Exception(ex.Message, ex);
                }
            }


        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            using (var tc = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Set<TEntity>().Where(predicate).ToList().ForEach(del => _db.Set<TEntity>().Remove(del));
                    _db.SaveChanges();
                    tc.Commit();
                }
                catch (Exception ex)
                {
                    tc.Rollback();
                    throw new Exception(ex.InnerException.InnerException.Message.ToString());
                }
            }
        }

        public void Update(TEntity entity)
        {
            entity = BeforUpdate(entity);
            using (var tc = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Modified;
                    _db.SaveChanges();
                    tc.Commit();
                    ClearEntityCache();
                }
                catch (Exception ex)
                {
                    tc.Rollback();
                    throw new Exception(ex.InnerException.InnerException.Message.ToString());
                }
            }
        }

        public TEntity Get(params object[] Keys)
        {

            TEntity entity = _db.Set<TEntity>().Find(Keys);
            return entity;
        }

        public IQueryable<TEntity> GetListAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public ICollection<TEntity> GetIncludeNotPagination(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _db.Set<TEntity>();

            if (where != null)
            {
                if (include != null)
                {
                    if (include.Body is NewExpression)
                    {
                        (include.Body as NewExpression).Arguments.ToList().ForEach(x =>
                        {
                            var inc = x as MemberExpression;
                            string s = inc.ToString();
                            s = s.Substring(s.IndexOf('.') + 1);
                            query = query.Include(s);
                        });

                        query = query.Where(where);
                    }
                    else
                    {
                        query = query.Where(where).Include(include);
                    }
                }
                else
                {
                    query = query.Where(where).Include(include);
                }
            }


            return query.ToList();
        }

        #region .:: Methods Helpers ::.
        public virtual TEntity BeforAdd(TEntity entity)
        {           
            entity.CreateDate = DateTime.Now;
            entity.ModifieldDate = DateTime.Now;
            return entity;
        }

        public virtual TEntity BeforUpdate(TEntity entity)
        {
            entity.ModifieldDate = DateTime.Now;
            return entity;
        }

        // Métodos Internos
        private void ClearEntityCache()
        {
            try
            {
                foreach (EntityEntry dbEntityEntry in _db.ChangeTracker.Entries())
                    if (dbEntityEntry.Entity != null)
                        dbEntityEntry.State = EntityState.Detached;
            }
            catch
            {
            }
        }
        #endregion
    }
}
