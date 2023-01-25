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
    public class KullaniciBS : IKullaniciBS
    {
        private readonly IKullaniciRepository _repo;
        public KullaniciBS(IKullaniciRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Kullanici entity)
        {
            _repo.Delete(entity);
        }
        public void Delete(int Id)
        {

            _repo.Delete(_repo.Get(x => x.Id == Id));
        }
        public Kullanici Get(Expression<Func<Kullanici, bool>> filter, params string[] includelist)
        {
            return _repo.Get(filter, includelist);
        }
        public List<Kullanici> GetAll(Expression<Func<Kullanici, bool>> filter, params string[] includelist)
        {
            return _repo.GetAll(filter, includelist);
        }
        public Kullanici GetById(int Id, params string[] includelist)
        {
            return _repo.Get(x => x.Id == Id, includelist);
        }
        public void Insert(Kullanici entity)
        {
            _repo.Insert(entity);
        }
        public void Update(Kullanici entity)
        {
            _repo.Update(entity);
        }
    }
}
