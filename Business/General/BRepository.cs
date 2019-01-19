using Model.General;
using Repository.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.General
{
    public class BRepository<TEntity> where TEntity : BaseModel
    {
        protected RRepository<TEntity> repository;

        public BRepository(RRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Add(TEntity entity)
        {
            repository.Add(entity);
        }

        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            repository.Delete(predicate);
        }

        public virtual TEntity Get(params object[] Keys)
        {
            return repository.Get(Keys);
        }

        public IQueryable<TEntity> GetListAll(Expression<Func<TEntity, bool>> predicate)
        {
            return repository.GetListAll(predicate);
        }

        public ICollection<TEntity> GetIncludeNotPagination(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null)
        {
            return repository.GetIncludeNotPagination(where, include);
        }
    }
}
