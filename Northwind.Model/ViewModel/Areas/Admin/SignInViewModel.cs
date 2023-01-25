using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model.ViewModel.Areas.Admin
{
    public class SignInViewModel
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }

        public string KullaniciAdi { get; set; }

        public string Email { get; set; }
        public string Sifre { get; set; }
        public string SifreTekrar { get; set; }

    }
}
