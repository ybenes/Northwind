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
    public class SatisDetayBS : ISatisDetayBS
    {
        private readonly ISatisDetayRepository _repo;
        public SatisDetayBS(ISatisDetayRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Satis_Detay entity)
        {
            _repo.Delete(entity);
        }
        public void Delete(int Id)
        {

            _repo.Delete(_repo.Get(x => x.SatisID == Id));
        }
        public Satis_Detay Get(Expression<Func<Satis_Detay, bool>> filter, params string[] includelist)
        {
            return _repo.Get(filter, includelist);
        }
        public List<Satis_Detay> GetAll(Expression<Func<Satis_Detay, bool>> filter, params string[] includelist)
        {
            return _repo.GetAll(filter, includelist);
        }
        public Satis_Detay GetById(int Id, params string[] includelist)
        {
            return _repo.Get(x => x.SatisID == Id, includelist);
        }
        public void Insert(Satis_Detay entity)
        {
            _repo.Insert(entity);
        }
        public void Update(Satis_Detay entity)
        {
            _repo.Update(entity);
        }
    }
}
