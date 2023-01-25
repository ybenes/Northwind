using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using Northwind.Model.Entity;
using Northwind.Model.statics;
using Northwind.Model.ViewModel.Areas.Admin;
using Northwind.WebCoreUI.Models;
using System.Diagnostics;

namespace Northwind.WebCoreUI.Controllers
{
    public class HomeController : Controller
    {
        IKullaniciBS kullaniciBS;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IKullaniciBS _kullaniciBS=null)
        {
            _logger = logger;
            kullaniciBS= _kullaniciBS;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Starter()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Starter(SignInViewModel vm)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.Adi = vm.Adi;
            kullanici.Soyadi = vm.Soyadi;
            kullanici.KullaniciAdi = vm.KullaniciAdi;
            kullanici.Email = vm.Email;
            if (vm.Sifre == vm.SifreTekrar)
            {
                kullanici.Sifre = vm.Sifre;
            }
            else
            {
                return Json(new { result = false, k = kullanici, Mesaj = "Kayıt İşlemi Başarısız." });
            }

            kullaniciBS.Insert(kullanici);

            return Json(new { result = true, k = kullanici, Mesaj = "Kayıt İşlemi Başarılı." });
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}