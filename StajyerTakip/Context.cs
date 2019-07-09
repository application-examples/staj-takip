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
        public DbSet<Gunluk> Gunluk { get; set; }
        public DbSet<BirimKoordinatoru> BirimKoordinatorleri { get; set; }
        public DbSet<Profil> Hesaplar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StajyerBirim>().HasKey(bc => new { bc.StajyerID, bc.BirimKoordinatoruID });

            modelBuilder.Entity<StajyerBirim>().HasOne(bc => bc.Stajyer).WithMany(b => b.BirimKoordinatorleri).HasForeignKey(bc => bc.BirimKoordinatoruID);

            modelBuilder.Entity<StajyerBirim>().HasOne(bc => bc.BirimKoordinatoru).WithMany(b => b.Stajyerler).HasForeignKey(bc => bc.StajyerID);


            modelBuilder.Entity<StajyerProje>().HasKey(bc => new { bc.StajyerID, bc.ProjeID });

            modelBuilder.Entity<ProjeBirim>().HasKey(bc => new { bc.ProjeID, bc.BirimKoordinatoruID });

        }
    }
}
