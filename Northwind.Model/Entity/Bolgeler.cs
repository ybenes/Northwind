using Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model.Entity
{
    public partial class Bolgeler : IBaseDomain
    {

        [Key]
        public string TerritoryID { get; set; }
        public string TerritoryTanimi { get; set; }
        public int BolgeID { get; set; }
    
   
    }
}
