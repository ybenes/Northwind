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
    public class PersonelBS : IPersonelBS
    {
        private readonly IPersonelRepository _repo;
        public PersonelBS(IPersonelRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Personel entity)
        {
            _repo.Delete(entity);
        }
        public void Delete(int Id)
        {

            _repo.Delete(_repo.Get(x => x.PersonelID == Id));
        }
        public Personel Get(Expression<Func<Personel, bool>> filter, params string[] includelist)
        {
            return _repo.Get(filter, includelist);
        }
        public List<Personel> GetAll(Expression<Func<Personel, bool>> filter, params string[] includelist)
        {
            return _repo.GetAll(filter, includelist);
        }
        public Personel GetById(int Id, params string[] includelist)
        {
            return _repo.Get(x => x.PersonelID == Id, includelist);
        }
        public void Insert(Personel entity)
        {
            _repo.Insert(entity);
        }
        public void Update(Personel entity)
        {
            _repo.Update(entity);
        }
    }
}
