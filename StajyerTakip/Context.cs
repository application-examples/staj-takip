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

            //StajyerBirim
            modelBuilder.Entity<StajyerBirimK>().HasKey(bc => new { bc.StajyerID, bc.BirimKID });
            modelBuilder.Entity<StajyerBirimK>().HasOne(bc => bc.Stajyer).WithMany(b => b.BirimKoordinatorleri).HasForeignKey(bc => bc.StajyerID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StajyerBirimK>().HasOne(bc => bc.BirimK).WithMany(b => b.Stajyerler).HasForeignKey(bc => bc.BirimKID).OnDelete(DeleteBehavior.Restrict);


            //End

        }
    }
}
