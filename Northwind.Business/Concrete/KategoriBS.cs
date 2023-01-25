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
    public class KategoriBS : IKategoriBS
    {
        private readonly IKategoriRepository _repo;
        public KategoriBS(IKategoriRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Kategori entity)
        {
            _repo.Delete(entity);
        }
        public void Delete(int Id)
        {

            _repo.Delete(_repo.Get(x => x.KategoriID == Id));
        }
        public Kategori Get(Expression<Func<Kategori, bool>> filter, params string[] includelist)
        {
            return _repo.Get(filter, includelist);
        }
        public List<Kategori> GetAll(Expression<Func<Kategori, bool>> filter, params string[] includelist)
        {
            return _repo.GetAll(filter, includelist);
        }
        public Kategori GetById(int Id, params string[] includelist)
        {
            return _repo.Get(x => x.KategoriID == Id, includelist);
        }
        public void Insert(Kategori entity)
        {
            _repo.Insert(entity);
        }
        public void Update(Kategori entity)
        {
            _repo.Update(entity);
        }
    }
}
