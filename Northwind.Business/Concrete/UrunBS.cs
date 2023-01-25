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
    public class UrunBS : IUrunBS
    {
        private readonly IUrunRepository _repo;
        public UrunBS(IUrunRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Urun entity)
        {
            _repo.Delete(entity);
        }
        public void Delete(int Id)
        {

            _repo.Delete(_repo.Get(x => x.UrunID == Id));
        }
        public Urun Get(Expression<Func<Urun, bool>> filter, params string[] includelist)
        {
            return _repo.Get(filter, includelist);
        }
        public List<Urun> GetAll(Expression<Func<Urun, bool>> filter, params string[] includelist)
        {
            return _repo.GetAll(filter, includelist);
        }
        public Urun GetById(int Id, params string[] includelist)
        {
            return _repo.Get(x => x.UrunID == Id, includelist);
        }
        public void Insert(Urun entity)
        {
            _repo.Insert(entity);
        }
        public void Update(Urun entity)
        {
            _repo.Update(entity);
        }
    }
}
