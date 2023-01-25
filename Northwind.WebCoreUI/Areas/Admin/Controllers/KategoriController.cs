using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.Business.Abstract;
using Northwind.Data.Concrete.EntityFramework.Context;
using Northwind.Model.Entity;
using Northwind.Model.statics;
using Northwind.Model.ViewModel.Areas.Admin;
using Northwind.WebCoreUI.Areas.Admin.Filter;

namespace Northwind.WebCoreUI.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class KategoriController : Controller
    {
        IKategoriBS KategoriBS;
        ISessionManager session;
        public KategoriController(IKategoriBS kategoriBS, ISessionManager _session)
        {
            KategoriBS = kategoriBS;
            session = _session;
        }


        [HttpGet]
        public IActionResult Index()
        {

            // KATEGORİ EKLE 


            List<Kategori> kategoriler = KategoriBS.GetAll(null);

            List<SelectListItem> selectLists = kategoriler.Select(x => new SelectListItem() { Text = x.KategoriAdi, Value = x.KategoriID.ToString() }).ToList();
            selectLists.Insert(0, new SelectListItem("Üst Kategori Seçiniz", "-1"));

            KategoriViewModel model = new KategoriViewModel();
            model.KategoriSelectList = selectLists;


            // KATEGORİ LİSTESİ 
            model.KategoriListesi = kategoriler;


            return View(model);
        }


        [HttpPost]
        public IActionResult Ekle(KategoriViewModel vm)
        {

            Kategori k = new Kategori();

            k.KategoriAdi = vm.KategoriAdi;
            k.Aciklama= vm.Aciklama;
           
            k.AktifMi = true;
            

            List<Kategori> kategoriler = KategoriBS.GetAll(null);

            List<SelectListItem> selectLists = kategoriler.Select(x => new SelectListItem() { Text = x.KategoriAdi, Value = x.KategoriID.ToString() }).ToList();
            selectLists.Insert(0, new SelectListItem("Üst Kategori Seçiniz", "-1"));

            KategoriViewModel model = new KategoriViewModel();
            model.KategoriSelectList = selectLists;


           
            model.KategoriListesi = kategoriler;

            KategoriBS.Insert(k);


            return Json(new { result = true,kategori = k, model = model, Mesaj = Messages.InsertCategorySuccess });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult KategoriGetir(int KategoriId)
        {

            Kategori kategori = KategoriBS.Get(x => x.KategoriID == KategoriId);
            if (kategori == null)
            {
                return Json(new { result = true, Mesaj = Messages.HataMesaji });
            }


            List<Kategori> kategoriler = KategoriBS.GetAll(x => x.AktifMi == true);

            List<SelectListItem> selectLists = kategoriler.Select(x => new SelectListItem() { Text = x.KategoriAdi, Value = x.KategoriID.ToString() }).ToList();
            selectLists.Insert(0, new SelectListItem("Üst Kategori Seçiniz", "-1"));

            KategoriViewModel model = new KategoriViewModel();
            model.KategoriSelectList = selectLists;


            
            model.KategoriListesi = kategoriler;



            return Json(new { result = true, model = model, kategori = kategori });

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult KategoriGuncelle(Kategori kat)
        {

            
            Kategori k = KategoriBS.Get(x => x.KategoriID == kat.KategoriID);
            k.KategoriAdi = kat.KategoriAdi;
            k.Aciklama= kat.Aciklama;
            k.AktifMi = true;

            KategoriBS.Update(k);
            
            List<Kategori> kategoriler = KategoriBS.GetAll(x => x.AktifMi == true);

            List<SelectListItem> selectLists = kategoriler.Select(x => new SelectListItem() { Text = x.KategoriAdi, Value = x.KategoriID.ToString() }).ToList();
            selectLists.Insert(0, new SelectListItem("Üst Kategori Seçiniz", "-1"));

            KategoriViewModel model = new KategoriViewModel();
            model.KategoriSelectList = selectLists;


        
            model.KategoriListesi = kategoriler;


            return Json(new { result = true, model = model, kategori = k, mesaj = "Güncelleme Başarılı" });

        }


        public IActionResult KategoriSil(int key)
        {


            NorthwindContext ctx = new NorthwindContext();
            Kategori u = ctx.Kategoriler.Where(x => x.KategoriID == key).SingleOrDefault();
            ctx.Kategoriler.Remove(u);

            int sonuc = ctx.SaveChanges();
            if (sonuc > 0)
            {
                return Json(new { result = true, mesaj = "İşlem Başarılı", Kategoriler = ctx.Kategoriler.ToList() });
            }
            else
            {
                return Json(new { result = false, mesaj = "Hatalı İşlem" });
            }

        }
    }
}
