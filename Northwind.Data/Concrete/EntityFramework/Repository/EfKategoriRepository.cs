using Core.Data.Abstract;
using Core.Data.Concrete.EntityFramework;
using Northwind.Data.Abstract;
using Northwind.Data.Concrete.EntityFramework.Context;
using Northwind.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Concrete
{
    public class EfKategoriRepository : EfRepositoryBase<Kategori, NorthwindContext>, IKategoriRepository
    {
    }
}
