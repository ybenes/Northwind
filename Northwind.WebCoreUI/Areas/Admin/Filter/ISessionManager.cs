using Northwind.Model.Entity;

namespace Northwind.WebCoreUI.Areas.Admin.Filter
{
    public interface ISessionManager
    {
        public Kullanici AktifKullanici { get; set; }

        public Kullanici AktifYonetici { get; set; }

        public string GuvenlikKodu { get; set; }
    }
}
