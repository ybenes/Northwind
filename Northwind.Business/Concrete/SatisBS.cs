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
    public class SatisBS : ISatisBS
    {
        private readonly ISatisRepository _repo;
        public SatisBS(ISatisRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Satis entity)
        {
            _repo.Delete(entity);
        }
        public void Delete(int Id)
        {

            _repo.Delete(_repo.Get(x => x.SatisID == Id));
        }
        public Satis Get(Expression<Func<Satis, bool>> filter, params string[] includelist)
        {
            return _repo.Get(filter, includelist);
        }
        public List<Satis> GetAll(Expression<Func<Satis, bool>> filter, params string[] includelist)
        {
            return _repo.GetAll(filter, includelist);
        }
        public Satis GetById(int Id, params string[] includelist)
        {
            return _repo.Get(x => x.SatisID == Id, includelist);
        }
        public void Insert(Satis entity)
        {
            _repo.Insert(entity);
        }
        public void Update(Satis entity)
        {
            _repo.Update(entity);
        }
    }
}
