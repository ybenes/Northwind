using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Northwind.Business.Abstract;
using Northwind.Model.Entity;
using Northwind.Model.Statics;
using Northwind.Model.ViewModel.Areas.Admin;
using Northwind.WebCoreUI.Areas.Admin.Filter;
using Northwind.WebCoreUI.Extensions;
using VektorelMarket.Core.Utility;

namespace Northwind.WebCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KullaniciController : Controller
    {
        IKullaniciBS _kullaniciBS;
        ISessionManager _session;
        public KullaniciController(IKullaniciBS kullaniciBS,ISessionManager session)
        {
            _kullaniciBS= kullaniciBS;
            _session= session;
        }
        
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();


            return View(model);
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Login(LoginViewModel vm)
        {

            if (!ModelState.IsValid)
            {


                return Json(new {result=false, mesaj="Hatalı işlem"});
            }
            string gkodu = _session.GuvenlikKodu;
            if (gkodu ==vm.GuvenlikKodu)
            {
                Kullanici kullanici = _kullaniciBS.Get(x => x.Email == vm.Email && x.Sifre == vm.Sifre);

                if (kullanici == null)
                {



                    return Json(new { result = false, mesaj = "Kullanıcı Bulunamadı" });
                }
                else
                {

                    

                    _session.AktifYonetici = kullanici;

                    return Json(new { result = true, mesaj = "Panel" });
                }
            }
            else
            {
                return Json(new { result = false, mesaj = "Güvenlik Kodu Hatalı" });
            }



        }

        public IActionResult Logout()
        {

           _session.AktifYonetici = null;
           return RedirectToAction("Login", "Kullanici");

        }

        public IActionResult GuvenlikKodu()
        {
            

            CaptchaGenerator generator = new CaptchaGenerator(4,"Verdana",20);
            
            Bitmap resim = generator.GuvenlikResmiUret();

            _session.GuvenlikKodu = generator.OlusturulanString;

            byte[] dizi = Converters.ImageToByteArray(resim);

            return File(dizi,"image/jpg");
        }

    }
}
