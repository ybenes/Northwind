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
    public class MusteriBS : IMusteriBS
    {
        private readonly IMusteriRepository _repo;
        public MusteriBS(IMusteriRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Musteri entity)
        {
            _repo.Delete(entity);
        }
        public void Delete(int Id)
        {

            _repo.Delete(_repo.Get(x => x.MusteriID == Id));
        }
        public Musteri Get(Expression<Func<Musteri, bool>> filter, params string[] includelist)
        {
            return _repo.Get(filter, includelist);
        }
        public List<Musteri> GetAll(Expression<Func<Musteri, bool>> filter, params string[] includelist)
        {
            return _repo.GetAll(filter, includelist);
        }
        public Musteri GetById(int Id, params string[] includelist)
        {
            return _repo.Get(x => x.MusteriID == Id, includelist);
        }
        public void Insert(Musteri entity)
        {
            _repo.Insert(entity);
        }
        public void Update(Musteri entity)
        {
            _repo.Update(entity);
        }
    }
}
