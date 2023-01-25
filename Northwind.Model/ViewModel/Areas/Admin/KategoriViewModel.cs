using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Model.Entity;

namespace Northwind.Model.ViewModel.Areas.Admin
{
    public class KategoriViewModel
    {
        public string KategoriAdi { get; set; }

        public string GKategoriAdi { get; set; }

        public string Aciklama { get; set; }
        public string GAciklama { get; set; }

        public string KategoriGorunum { get; set; }
        public int? UstKategoriId { get; set; }
        public bool? AktifMi { get; set; }
        public int? GUstKategoriId { get; set; }
        public List<SelectListItem> KategoriSelectList { get; set; }
        public List<Kategori> KategoriListesi { get; set; }


    }
}
