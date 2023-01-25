using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Model.Entity
{
    public class Personel : IBaseDomain
    {

        [Key]
        public int PersonelID { get; set; }
        public string SoyAdi { get; set; }
        public string Adi { get; set; }
        public string Unvan { get; set; }
        public string UnvanEki { get; set; }
        public Nullable<System.DateTime> DogumTarihi { get; set; }
        public Nullable<System.DateTime> IseBaslamaTarihi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Bolge { get; set; }
        public string PostaKodu { get; set; }
        public string Ulke { get; set; }
        public string EvTelefonu { get; set; }
        public string Extension { get; set; }
        public byte[] Fotograf { get; set; }
        public string Notlar { get; set; }
        public int? BagliCalistigiKisi { get; set; }
        public string FotografPath { get; set; }
        // int? null alabilir int anlamındadır.



        // NAVIGATION PROPERTY

        public List<Satis> Satislar { get; set; }


    }
}
