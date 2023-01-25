using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Model.Entity;

namespace Northwind.Model.ViewModel.Areas.Admin
{
    public  class UrunEkleViewModel
    {
        public string UrunAdi { get; set; }
        public int? KategoriId { get; set; }

        
        public string UrunKodu { get; set; }
        public decimal? BirimFiyati { get; set; }
        public int? Stok { get; set; }
        
        public int? Kdvorani { get; set; }

        public string Aciklama { get; set; }
        public List<string> UrunResimleri { get; set; }
        public List<UrunFiyatVm> UrunFiyatlari { get; set; }

        public List<SelectListItem> KategoriSelectList { get; set; }

        public List<SelectListItem> StokBirimSelectList { get; set; }

   

    }
}
