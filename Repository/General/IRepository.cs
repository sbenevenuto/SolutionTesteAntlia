using Model.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.General
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        void Add(TEntity entity);
        void Delete(Func<TEntity, bool> predicate);
        void Update(TEntity entity);
        TEntity Get(params object[] Keys);
        IQueryable<TEntity> GetListAll(Expression<Func<TEntity, bool>> predicate);
        ICollection<TEntity> GetIncludeNotPagination(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null);
    }
}
