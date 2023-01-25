using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Model.Entity
{
    public class Satis : IBaseDomain
    {
        [Key]
        public int SatisID { get; set; }
        public string MusteriID { get; set; }
        public Nullable<int> PersonelID { get; set; }
        public Nullable<System.DateTime> SatisTarihi { get; set; }
        public Nullable<System.DateTime> OdemeTarihi { get; set; }
        public Nullable<System.DateTime> SevkTarihi { get; set; }
        public Nullable<int> ShipVia { get; set; }
        public Nullable<decimal> NakliyeUcreti { get; set; }
        public string SevkAdi { get; set; }
        public string SevkAdresi { get; set; }
        public string SevkSehri { get; set; }
        public string SevkBolgesi { get; set; }
        public string SevkPostaKodu { get; set; }
        public string SevkUlkesi { get; set; }

        // -------------NAVIGATION PROP------------------------

        public Personel Personeller { get; set; }

    }
}
