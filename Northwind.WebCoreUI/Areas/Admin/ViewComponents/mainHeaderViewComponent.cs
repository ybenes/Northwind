using Microsoft.AspNetCore.Mvc;

namespace Northwind.WebCoreUI.Areas.Admin.ViewComponents
{
    public class mainHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
