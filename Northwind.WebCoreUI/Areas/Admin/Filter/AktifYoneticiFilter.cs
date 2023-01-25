using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Northwind.Model.Entity;
using Northwind.Model.Statics;
using Northwind.WebCoreUI.Extensions;

namespace Northwind.WebCoreUI.Areas.Admin.Filter
{
    public class AktifYoneticiFilter : ActionFilterAttribute,IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Kullanici kullanici = context.HttpContext.Session.GetObject<Kullanici>(Keys.AktifYonetici);

            if (kullanici == null)
            {
                context.Result = new RedirectResult("/Admin/Kullanici/Login");
            }

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {


            base.OnActionExecuted(context);
        }


    }
}
