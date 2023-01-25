using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Newtonsoft.Json;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Business.MappingRule;
using Northwind.Business.ValidationRule.Admin;
using Northwind.Data.Abstract;
using Northwind.Data.Concrete;
using Northwind.Model.ViewModel.Areas.Admin;
using Northwind.WebCoreUI.Areas.Admin.Filter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddFluentValidation().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; }
      );

builder.Services.AddSingleton<IBolgelerBS, BolgelerlerBS>();
builder.Services.AddSingleton<IBolgeBS, BolgeBS>();
builder.Services.AddSingleton<IKategoriBS, KategoriBS>();
builder.Services.AddSingleton<IKullaniciBS, KullaniciBS>();
builder.Services.AddSingleton<IMusteriBS, MusteriBS>();
builder.Services.AddSingleton<INakliyeciBS, NakliyeciBS>();
builder.Services.AddSingleton<IPersonelBS, PersonelBS>();
builder.Services.AddSingleton<ISatisBS, SatisBS>();
builder.Services.AddSingleton<ISatisDetayBS, SatisDetayBS>();
builder.Services.AddSingleton<ITedarikciBS, TedarikciBS>();
builder.Services.AddSingleton<IUrunBS, UrunBS>();

builder.Services.AddSingleton<IBolgelerRepository, EfBolgelerRepository>();
builder.Services.AddSingleton<IBolgeRepository, EfBolgeRepository>();
builder.Services.AddSingleton<IKategoriRepository, EfKategoriRepository>();
builder.Services.AddSingleton<IKullaniciRepository, EfKullaniciRepository>();
builder.Services.AddSingleton<IMusteriRepository, EfMusteriRepository>();
builder.Services.AddSingleton<INakliyeciRepository, EfNakliyeciRepository>();
builder.Services.AddSingleton<IPersonelRepository, EfPersonelRepository>();
builder.Services.AddSingleton<ISatisDetayRepository, EfSatisDetayRepository>();
builder.Services.AddSingleton<ISatisRepository, EfSatisRepository>();
builder.Services.AddSingleton<ITedarikciRepository, EfTedarikciRepository>();
builder.Services.AddSingleton<IUrunRepository, EfUrunRepository>();





builder.Services.AddSingleton<ISessionManager, SessionManager>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


var mappingconfig = new MapperConfiguration(m =>
{
    m.AddProfile(new MappingProfile());

});

IMapper mapper = mappingconfig.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddSession();

builder.Services.AddSingleton<IValidator<LoginViewModel>, LoginViewModelValidator>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseCookiePolicy();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
       name: "areas",
       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
     );


    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Starter}/{id?}");


});

app.Run();