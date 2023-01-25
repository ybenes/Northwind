using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Model.Entity
{
    public partial class Satis_Detay : IBaseDomain
    {
        [Key]
        public int SatisID { get; set; }
        public int UrunID { get; set; }
        public decimal BirimFiyati { get; set; }
        public short Miktar { get; set; }
        public float İndirim { get; set; }
    
      
    }
}
