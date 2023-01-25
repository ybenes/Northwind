using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.Model.Entity;

namespace Northwind.Model.ViewModel.Areas.Admin
{
    public  class UrunListeViewModel
    {
        public List<Urun> Urunler { get; set; }

        public List<SelectListItem> KategoriSelectList { get; set; }
        public List<Kategori> KategoriListesi { get; set; }

        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int? KategoriId { get; set; }
        public string KategoriAdi { get; set; }

        public string Aciklama { get; set; }

        public int HedefStokDüzeyi { get; set; }

        public decimal BirimFiyati { get; set; }



    }
}
