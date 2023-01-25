using Northwind.Model.Entity;
using Northwind.Model.Statics;
using Northwind.WebCoreUI.Extensions;

namespace Northwind.WebCoreUI.Areas.Admin.Filter
{
    public class SessionManager : ISessionManager
    {
        IHttpContextAccessor _httpContextAccessor;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }



        public Kullanici AktifKullanici
        {
            get
            {
                return _httpContextAccessor.HttpContext.Session.GetObject<Kullanici>(Keys.AktifKullanici);
            }

            set
            {_httpContextAccessor.HttpContext.Session.SetObject(Keys.AktifKullanici, value);
            }

        }
        public Kullanici AktifYonetici
        {
            get
            {
                return _httpContextAccessor.HttpContext.Session.GetObject<Kullanici>(Keys.AktifYonetici);
            }

            set
            {
                _httpContextAccessor.HttpContext.Session.SetObject(Keys.AktifYonetici, value);
            }

        }
        public string GuvenlikKodu
        {
            get
            {
                return _httpContextAccessor.HttpContext.Session.GetObject<string>(Keys.GuvenlikKodu);
            }

            set
            {
                _httpContextAccessor.HttpContext.Session.SetObject(Keys.GuvenlikKodu, value);
            }

        }
    }
}