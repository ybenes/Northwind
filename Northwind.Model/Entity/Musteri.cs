using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Model.Entity
{
    public partial class Musteri : IBaseDomain
    {

        [Key]
        public int MusteriID { get; set; }
        public string SirketAdi { get; set; }
        public string MusteriAdi { get; set; }
        public string MusteriUnvani { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Bolge { get; set; }
        public string PostaKodu { get; set; }
        public string Ulke { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
    
       
    }
}
