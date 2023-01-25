
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Northwind.Model.Entity;
using Northwind.Model.ViewModel.Areas.Admin;

namespace Northwind.Business.MappingRule
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            CreateMap<Urun, UrunEkleViewModel>();
            CreateMap<UrunEkleViewModel, Urun>();

        }
    }
}
