using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.WebCoreUI.Areas.Admin.Filter;

namespace Northwind.WebCoreUI.Areas.Admin.ViewComponents
{
    public class sideBarViewComponent : ViewComponent
    {
        ISessionManager session;
        public sideBarViewComponent(ISessionManager _session)
        {
            session = _session;
        }


        public IViewComponentResult Invoke()
        {

            if (session != null && session.AktifYonetici != null)
            {

                TempData["Yonetici"] = session.AktifYonetici.Adi + " " + session.AktifYonetici.Soyadi;
            }

            return View();
        }
    }
}
