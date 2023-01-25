using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Northwind.Model.Entity
{
    public partial class Urun : IBaseDomain
    {

      

        [Key]
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public Nullable<int> TedarikciID { get; set; }
        public Nullable<int> KategoriID { get; set; }
        public string BirimdekiMiktar { get; set; }
        public Nullable<decimal> BirimFiyati { get; set; }
        public Nullable<int> HedefStokDuzeyi { get; set; }
        public Nullable<short> YeniSatis { get; set; }
        public Nullable<short> EnAzYenidenSatisMikatari { get; set; }
        public bool Sonlandi { get; set; }
        public string? Aciklama { get; set; }
      
        //-------------NAV

        public Kategori? Kategoriler { get; set; }
        public Tedarikci Tedarikciler { get; set; }

    }
}
