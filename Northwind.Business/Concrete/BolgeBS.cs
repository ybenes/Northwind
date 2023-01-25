using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Northwind.Business.Abstract;
using Northwind.Data.Abstract;
using Northwind.Model.Entity;

namespace Northwind.Business.Concrete
{
    public class BolgeBS : IBolgeBS
    {
        private readonly IBolgeRepository _repo;
        public BolgeBS(IBolgeRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Bolge entity)
        {
            _repo.Delete(entity);
        }
        public void Delete(int Id)
        {
            
            _repo.Delete(_repo.Get(x=>x.BolgeID==Id));
        }
        public Bolge Get(Expression<Func<Bolge, bool>> filter, params string[] includelist)
        {
            return _repo.Get(filter, includelist);
        }
        public List<Bolge> GetAll(Expression<Func<Bolge, bool>> filter, params string[] includelist)
        {
            return _repo.GetAll(filter, includelist);
        }
        public Bolge GetById(int Id, params string[] includelist)
        {
            return _repo.Get(x=>x.BolgeID==Id, includelist);
        }
        public void Insert(Bolge entity)
        {
            _repo.Insert(entity);
        }
        public void Update(Bolge entity)
        {
            _repo.Update(entity);
        }
    }
}
