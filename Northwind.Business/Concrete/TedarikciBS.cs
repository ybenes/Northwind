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
    public class TedarikciBS : ITedarikciBS
    {
        private readonly ITedarikciRepository _repo;
        public TedarikciBS(ITedarikciRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Tedarikci entity)
        {
            _repo.Delete(entity);
        }
        public void Delete(int Id)
        {

            _repo.Delete(_repo.Get(x => x.TedarikciID == Id));
        }
        public Tedarikci Get(Expression<Func<Tedarikci, bool>> filter, params string[] includelist)
        {
            return _repo.Get(filter, includelist);
        }
        public List<Tedarikci> GetAll(Expression<Func<Tedarikci, bool>> filter, params string[] includelist)
        {
            return _repo.GetAll(filter, includelist);
        }
        public Tedarikci GetById(int Id, params string[] includelist)
        {
            return _repo.Get(x => x.TedarikciID == Id, includelist);
        }
        public void Insert(Tedarikci entity)
        {
            _repo.Insert(entity);
        }
        public void Update(Tedarikci entity)
        {
            _repo.Update(entity);
        }
    }
}
