using Microsoft.AspNetCore.Mvc;
using Northwind.Model.Entity;
using Northwind.Model.Statics;
using Northwind.WebCoreUI.Areas.Admin.Filter;
using Northwind.WebCoreUI.Extensions;

namespace Northwind.WebCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {
        ISessionManager session;

        public HomeController(ISessionManager _session)
        {
             session = _session;
        }



        public IActionResult Index()
        {
            


            return View();
        }
    }
}
