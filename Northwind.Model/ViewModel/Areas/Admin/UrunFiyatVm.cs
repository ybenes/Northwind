using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Model.Entity;

namespace Northwind.Model.ViewModel.Areas.Admin
{
    public class UrunFiyatVm
    {
        public int? UrunId { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public decimal? Fiyat { get; set; }

        public virtual Urun Urun { get; set; }

    }
}
