using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Model.Entity
{
   
    public partial class Nakliyeci : IBaseDomain
    {

        [Key]
        public int NakliyeciID { get; set; }
        public string SirketAdi { get; set; }
        public string Telefon { get; set; }
    
       
    }
}
