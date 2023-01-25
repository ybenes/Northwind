using Microsoft.AspNetCore.Mvc;
using Northwind.Data.Concrete.EntityFramework.Context;
using Northwind.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebCoreUI.ViewComponents
{
    public class KategoriMenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            NorthwindContext context = new NorthwindContext();

            List<Kategori> kategoriler = context.Kategoriler.ToList();

            return View(kategoriler);

        }
    }
}
