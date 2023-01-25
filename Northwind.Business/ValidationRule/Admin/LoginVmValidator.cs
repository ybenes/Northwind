using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Model.Entity;
using Northwind.Model.ViewModel.Areas.Admin;

namespace Northwind.Business.ValidationRule.Admin
{
    public  class LoginViewModelValidator:AbstractValidator<LoginViewModel>
    {


        IKullaniciBS KullaniciBS;
        public LoginViewModelValidator(IKullaniciBS _KullaniciBS)
        {
            KullaniciBS = _KullaniciBS;

            RuleFor(x=>x.Email).NotEmpty().WithMessage("Lütfen Email Griniz.");
            RuleFor(x => x.Email).Must(NotFoundEmail).WithMessage("Email Bulunamadı.");

            RuleFor(x => x.Sifre).NotEmpty().WithMessage("Lütfen Şifre Giriniz.");
        }

        private bool NotFoundEmail(string args)
        {

            Kullanici k =KullaniciBS.Get(x => x.Email == args);
            if (k==null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
