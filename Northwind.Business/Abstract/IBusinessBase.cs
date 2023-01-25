using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Northwind.Business.Abstract
{
   public interface IBusinessBase<TEntity>

        where TEntity: IBaseDomain, new()
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter, params string[] includelist);
        TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includelist);
        TEntity GetById(int Id, params string[] includelist);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int Id);

    }
}
