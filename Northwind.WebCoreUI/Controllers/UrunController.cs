using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Data.Concrete.EntityFramework.Context;
using Northwind.Model.Entity;
using Northwind.Model.ViewModel.Areas.Admin;
using Northwind.Model.ViewModel.Front.ViewModel;
using Northwind.WebCoreUI.Areas.Admin.Filter;

namespace Northwind.WebCoreUI.Controllers
{
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

        public IActionResult Index()
        {

           return View();
        }

        public IActionResult Kategori()
        {

            List<Kategori> kategoriler = KategoriBS.GetAll(x => x.AktifMi == true);

            List<SelectListItem> selectLists = kategoriler.Select(x => new SelectListItem() { Text = x.KategoriAdi, Value = x.KategoriID.ToString() }).ToList();
            selectLists.Insert(0, new SelectListItem("Üst Kategori Seçiniz", "-1"));

            KategoriViewModel model = new KategoriViewModel();
            model.KategoriSelectList = selectLists;


            model.KategoriListesi = kategoriler;


            return View(model);

        }

        public IActionResult Liste()
        {

            UrunListeViewModel model = new UrunListeViewModel();
            model.Urunler = UrunBS.GetAll(null, "Kategoriler");


            return View(model);

        }


    }
}
