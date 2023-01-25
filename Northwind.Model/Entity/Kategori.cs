using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Model.Entity
{
   
    public partial class Kategori : IBaseDomain
    {

      

       [Key]
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public byte[] Resim { get; set; }
        public bool AktifMi { get; set; }
        //-------------------NAVIGATION PROP--------------------------
        public List<Urun> Urunlers { get; set; }

    }
}
