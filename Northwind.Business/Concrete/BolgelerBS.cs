using Northwind.Business.Abstract;
using Northwind.Data.Abstract;
using Northwind.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class BolgelerlerBS : IBolgelerBS
    {
        private readonly IBolgelerRepository _repo;
        public BolgelerlerBS(IBolgelerRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Bolgeler entity)
        {
            _repo.Delete(entity);
        }
        public void Delete(int Id)
        {

            _repo.Delete(_repo.Get(x => x.BolgeID == Id));
        }
        public Bolgeler Get(Expression<Func<Bolgeler, bool>> filter, params string[] includelist)
        {
            return _repo.Get(filter, includelist);
        }
        public List<Bolgeler> GetAll(Expression<Func<Bolgeler, bool>> filter, params string[] includelist)
        {
            return _repo.GetAll(filter, includelist);
        }
        public Bolgeler GetById(int Id, params string[] includelist)
        {
            return _repo.Get(x => x.BolgeID == Id, includelist);
        }
        public void Insert(Bolgeler entity)
        {
            _repo.Insert(entity);
        }
        public void Update(Bolgeler entity)
        {
            _repo.Update(entity);
        }
    }
}
