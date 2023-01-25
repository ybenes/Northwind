using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Model.Entity
{
    public  class Kullanici : IBaseDomain
    {
        [Key]
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
    }
}
