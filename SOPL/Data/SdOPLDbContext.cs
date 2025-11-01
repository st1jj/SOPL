using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SOPL.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SOPL.Web
{
    public class SdOPLDbContext : IdentityDbContext<Account>
    {
        public DbSet<Account>Accounts { get; set; }
        public DbSet<Pacjent> Pacjenci { get; set; }
        public DbSet<Lekarz> Lekarze { get; set; }
        public DbSet<Wizyta> Wizyty { get; set; }
        public DbSet<HistoriaChoroby> HistorieChorob { get; set; }
        public DbSet<Recepta> Recepty { get; set; }
        public DbSet<PozycjaRecepty> PozycjeRecept { get; set; }
        public DbSet<Lek> Leki { get; set; }

        public SdOPLDbContext(DbContextOptions<SdOPLDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pacjent>(entity =>
            {
                entity.ToTable("Pacjenci");
                entity.HasKey(p => p.Id);
                entity.HasIndex(p => p.Pesel).IsUnique();
                entity.HasIndex(p => p.Email).IsUnique();
            });


            modelBuilder.Entity<Lekarz>(entity =>
            {
                entity.ToTable("Lekarze");
                entity.HasKey(l => l.Id);
                entity.HasIndex(l => l.Email).IsUnique();
            });


            modelBuilder.Entity<Wizyta>(entity =>
            {
                entity.ToTable("Wizyty");
                entity.HasKey(w => w.Id);
                entity.HasOne(w => w.Pacjent)
                      .WithMany(p => p.Wizyty)
                      .HasForeignKey(w => w.PacjentId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(w => w.Lekarz)
                      .WithMany(l => l.Wizyty)
                      .HasForeignKey(w => w.LekarzId)
                      .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<HistoriaChoroby>(entity =>
            {
                entity.ToTable("HistorieChorob");
                entity.HasKey(h => h.Id);

                entity.HasOne(h => h.Pacjent)
                      .WithMany(p => p.HistorieChorob)
                      .HasForeignKey(h => h.PacjentId);

                entity.HasOne(h => h.Lekarz)
                      .WithMany(l => l.HistorieChorob)
                      .HasForeignKey(h => h.LekarzId);
            });


            modelBuilder.Entity<Recepta>(entity =>
            {
                entity.ToTable("Recepty");
                entity.HasKey(r => r.Id);

                entity.HasOne(r => r.HistoriaChoroby)
                      .WithMany(h => h.Recepty)
                      .HasForeignKey(r => r.HistoriaChorobyId);
            });


            modelBuilder.Entity<PozycjaRecepty>(entity =>
            {
                entity.ToTable("PozycjeRecepty");
                entity.HasKey(pr => pr.Id);

                entity.HasOne(pr => pr.Recepta)
                      .WithMany(r => r.Pozycje)
                      .HasForeignKey(pr => pr.ReceptaId);

                entity.HasOne(pr => pr.Lek)
                      .WithMany(l => l.PozycjeRecept)
                      .HasForeignKey(pr => pr.LekId);
            });


            modelBuilder.Entity<Lek>(entity =>
            {
                entity.ToTable("Leki");
                entity.HasKey(l => l.Id);
            });
        }
    }
}