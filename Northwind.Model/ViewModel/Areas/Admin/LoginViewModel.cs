using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model.ViewModel.Areas.Admin
{
    public class LoginViewModel
    {

        public string Email { get; set; }


       
        public string Sifre { get; set; }
        public bool BeniHatirla { get; set; }
        public string GuvenlikKodu { get; set; }
        

    }
}
