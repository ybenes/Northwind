using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebCoreUI.ViewComponents
{
    public class UrunListesiViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            

            return View();

        }

    }
}
