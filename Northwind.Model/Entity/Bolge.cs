using Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model.Entity
{
    public partial class Bolge : IBaseDomain
    {
        [Key]
        public int BolgeID { get; set; }
        public string BolgeTanimi { get; set; }
    
      
    }
}
