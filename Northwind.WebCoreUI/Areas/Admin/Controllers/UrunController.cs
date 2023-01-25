using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Model.Entity;
using Northwind.Model.ViewModel.Areas.Admin;
using Northwind.WebCoreUI.Areas.Admin.Filter;
using VektorelMarket.Core.Utility;
using Northwind.Core.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.Data.Concrete.EntityFramework.Context;

namespace Northwind.WebCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UrunController : Controller
    {

        IKategoriBS KategoriBS;
        IUrunBS UrunBS;

        ISessionManager session;
        IMapper mapper;

        public UrunController(IKategoriBS kategoriBS, ISessionManager _session, IUrunBS urunBS, IMapper _mapper)
        {
            KategoriBS = kategoriBS;
            UrunBS = urunBS;
            session = _session;
            mapper = _mapper;
        }
        public IActionResult Ekle()
        {

            UrunEkleViewModel model = new UrunEkleViewModel();
            model.KategoriSelectList = KategoriBS.GetAll(null).Select(x => new SelectListItem() { Text = x.KategoriAdi, Value = x.KategoriID.ToString() }).ToList();


            model.KategoriSelectList.Insert(0, new SelectListItem { Text = "Lütfen Kategori Seçiniz", Value = "-1" });


            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(UrunEkleViewModel vm)
        {

            
            Urun urun = new Urun();
            Kategori kategori = new Kategori();

            urun.UrunAdi = vm.UrunAdi;

            if (vm.Aciklama==null)
            {
                vm.Aciklama = kategori.Aciklama;
            }
            else
            {
                vm.Aciklama = vm.Aciklama.Replace("<scipt>", "").Replace("</script>", "");

                urun.Aciklama = $"{kategori.Aciklama}, {vm.Aciklama}";
            }
            
            
            if (vm.Stok!=null)
            {
                urun.HedefStokDuzeyi = vm.Stok;
            }
            else
            {
                return Json(new { result = false, urun = urun, mesaj = "Lütfen Adet Giriniz." });
            }


            if (vm.BirimFiyati!=null )
            {
                urun.BirimFiyati = vm.BirimFiyati;
            }
            else 
            {
                return Json(new { result = false, urun = urun, mesaj = "Lütfen Fiyat Giriniz." });
            }
           


            if (vm.KategoriId<1)
            {
                return Json(new { result = false, urun = urun, mesaj = "Lütfen Kategori Seçiniz." });
            }
            else
            {
                urun.KategoriID = vm.KategoriId;
                

            }
            UrunBS.Insert(urun);
         

            return Json(new { result = true, urun = urun });
        }

        public IActionResult Liste()
        {


            UrunListeViewModel model = new UrunListeViewModel();
            model.Urunler = UrunBS.GetAll(null, "Kategoriler");


            return View(model);
        }


        public IActionResult UrunBilgileriGetir(int urunid)
        {

            Urun urun = UrunBS.Get(x => x.UrunID == urunid);

            Kategori kategori = KategoriBS.Get(x => x.KategoriID == urun.KategoriID);


            return Json(new { result = true, u = urun, k = kategori });
        }

        public IActionResult UrunGetir(int key)
        {


            Urun urun = UrunBS.Get(x => x.UrunID == key);

            Kategori kategori = KategoriBS.Get(x => x.KategoriID == urun.KategoriID);

            List<SelectListItem> KategorilerList = KategoriBS.GetAll(null).Select(x => new SelectListItem { Text = x.KategoriAdi, Value = x.KategoriID.ToString() }).ToList();

            KategorilerList.Insert(0, new SelectListItem { Text = "Lütfen Kategori Seçiniz", Value = "-1" });



            return Json(new { result = true, u = urun, k = kategori, KategorilerList = KategorilerList });
        }


        [HttpPost]
        public IActionResult UrunGuncelle(Urun urun)
        {

            Urun u = UrunBS.Get(x => x.UrunID == urun.UrunID);

            u.UrunID = urun.UrunID;
            u.UrunAdi = urun.UrunAdi;
            u.KategoriID = urun.KategoriID;
            u.HedefStokDuzeyi = urun.HedefStokDuzeyi;
            u.BirimFiyati = urun.BirimFiyati;
            u.Aciklama = null;
            Kategori kategori= new Kategori();
            kategori.Aciklama=urun.Aciklama;
            UrunBS.Update(u);

            return Json(new { result = true, u = u });

        }


        public IActionResult UrunSil(int urunid)
        {

            Urun urun = UrunBS.Get(x => x.UrunID == urunid);


            if (urun.UrunID == null)
            {
                return Json(new { result = false, Mesaj = "Ürün Silinemedi." });
            }
           
            UrunBS.Delete(urun);

            return Json(new { result = true, Mesaj = "Silme İşlemi Başarılı" });
        }







    }
}
