using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Model.ViewModel.Front.ViewModel
{
    public class UrunEkleVm
    {
        public List<Kategori> Kategoriler { get; set; }

        public List<Tedarikci> Tedarikciler { get; set; }

        public List<Urun> Urunler { get; set; }
        public List<SelectListItem> KategorilerList { get; set; }

        public List<SelectListItem> TedarikcilerList { get; set; }


        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public int? TedarikciID { get; set; }
        public int? KategoriID { get; set; }
        public decimal? BirimFiyati { get; set; }
        public short? HedefStokDuzeyi { get; set; }



    }
}
