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
    public class NakliyeciBS : INakliyeciBS
    {
        private readonly INakliyeciRepository _repo;
        public NakliyeciBS(INakliyeciRepository repo)
        {
            _repo = repo;
        }
        public void Delete(Nakliyeci entity)
        {
            _repo.Delete(entity);
        }
        public void Delete(int Id)
        {

            _repo.Delete(_repo.Get(x => x.NakliyeciID == Id));
        }
        public Nakliyeci Get(Expression<Func<Nakliyeci, bool>> filter, params string[] includelist)
        {
            return _repo.Get(filter, includelist);
        }
        public List<Nakliyeci> GetAll(Expression<Func<Nakliyeci, bool>> filter, params string[] includelist)
        {
            return _repo.GetAll(filter, includelist);
        }
        public Nakliyeci GetById(int Id, params string[] includelist)
        {
            return _repo.Get(x => x.NakliyeciID == Id, includelist);
        }
        public void Insert(Nakliyeci entity)
        {
            _repo.Insert(entity);
        }
        public void Update(Nakliyeci entity)
        {
            _repo.Update(entity);
        }
    }
}
