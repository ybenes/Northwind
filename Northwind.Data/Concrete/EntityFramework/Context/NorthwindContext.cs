using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Northwind.Model.Entity;

namespace Northwind.Data.Concrete.EntityFramework.Context
{
    public partial class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.;Database=Northwind;Trusted_Connection=True;");
            }
        }

        
        public virtual DbSet<Bolge> Bolge { get; set; }
        public virtual DbSet<Bolgeler> Bolgeler { get; set; }

        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<Tedarikci> Tedarikciler { get; set; }
        public virtual DbSet<Personel> Personeller { get; set; }
        public virtual DbSet<Satis> Satislar { get; set; }
        
        public virtual DbSet<Satis_Detay> Satis_Detaylari { get; set; }
        public virtual DbSet<Kullanici> Kullaniciler { get; set; }
        public virtual DbSet<Musteri> Musteriler { get; set; }
        public virtual DbSet<Nakliyeci> Nakliyeciler { get; set; }
    }
}