using Microsoft.EntityFrameworkCore;
using StajyerTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StajyerTakip
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
                
        }

        public DbSet<Stajyer> Stajyerler { get; set; }
        public DbSet<Gunluk> Gunlukler { get; set; }

        public DbSet<BirimKoordinatoru> BirimKoordinatorleri { get; set; }

        public DbSet<Profil> Hesaplar { get; set; }
        public DbSet<Moderator> Moderatorler { get; set; }
        public DbSet<Birim> Birimler { get; set; }
        public DbSet<Proje> Projeler { get; set; }
        public DbSet<StajyerProje> StajyerProjeler { get; internal set; }
        public DbSet<ProjeBirim> ProjeBirim { get; internal set; }
        public DbSet<Devamsizlik> Devamsizlik { get;  set; }
        public DbSet<BirimveStajyer> BirimveStajyer { get; internal set; }
        public DbSet<BirimveKoordinator> BirimveKoordinator { get; internal set; }
        public DbSet<SistemYoneticisi> SistemYoneticisi { get; set; }
        public DbSet<Duyuru> Duyurular { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Chat> Mesajlar { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //StajyerProje
            modelBuilder.Entity<StajyerProje>().HasKey(bc => new { bc.StajyerID, bc.ProjeID });

            modelBuilder.Entity<StajyerProje>().HasOne(bc => bc.Stajyer).WithMany(b => b.Projeler).HasForeignKey(bc => bc.StajyerID);

            modelBuilder.Entity<StajyerProje>().HasOne(bc => bc.Proje).WithMany(b => b.Stajyerler).HasForeignKey(bc => bc.ProjeID);

            //End

            //ProjeBirim


            modelBuilder.Entity<ProjeBirim>().HasKey(bc => new { bc.ProjeID, bc.BirimKoordinatoruID });

            modelBuilder.Entity<ProjeBirim>().HasOne(bc => bc.Proje).WithMany(b => b.BirimKoordinatorleri).HasForeignKey(bc => bc.ProjeID);

            modelBuilder.Entity<ProjeBirim>().HasOne(bc => bc.BirimKoordinatoru).WithMany(b => b.Projeler).HasForeignKey(bc => bc.BirimKoordinatoruID);

            //End


            //End

            modelBuilder.Entity<BirimveKoordinator>().HasKey(bc => new { bc.BirimID, bc.BirimKoordinatoruID });
            modelBuilder.Entity<BirimveKoordinator>().HasOne(bc => bc.BirimKoordinatoru).WithMany(b => b.Birimler).HasForeignKey(bc => bc.BirimKoordinatoruID);

            modelBuilder.Entity<BirimveStajyer>().HasKey(bc => new { bc.BirimID, bc.StajyerID });

            modelBuilder.Entity<BirimveStajyer>().HasOne(bc => bc.Stajyer).WithMany(b => b.Birimler).HasForeignKey(bc => bc.StajyerID);


            modelBuilder.Entity<Profil>().HasIndex(u=>u.Email).IsUnique(true);
            modelBuilder.Entity<Profil>().HasIndex(u=>u.KullaniciAdi).IsUnique(true);

        }
    }
}
