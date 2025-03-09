using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ZR_Banka.Models;

public partial class ZrBankaDbContext : DbContext
{
    public ZrBankaDbContext()
    {
    }

    public ZrBankaDbContext(DbContextOptions<ZrBankaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Korisnik> Korisnik { get; set; }

    public virtual DbSet<Kredit> Kredit { get; set; }

    public virtual DbSet<Uplata> Uplata { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=ZR_BankaDB;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.IdKorisnik).HasName("Korisnik_pkey");

            entity.ToTable("Korisnik");

            entity.Property(e => e.IdKorisnik).HasColumnName("id_korisnik");
            entity.Property(e => e.Ime)
                .HasMaxLength(20)
                .HasColumnName("ime");
            entity.Property(e => e.Mail)
                .HasMaxLength(100)
                .HasColumnName("mail");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.Prezime)
                .HasMaxLength(25)
                .HasColumnName("prezime");
            entity.Property(e => e.Uloga)
                .HasMaxLength(25)
                .HasColumnName("uloga");
            entity.Property(e => e.Username)
                .HasMaxLength(15)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Kredit>(entity =>
        {
            entity.HasKey(e => e.IdKredit).HasName("Kredit_pkey");

            entity.ToTable("Kredit");

            entity.Property(e => e.IdKredit).HasColumnName("id_kredit");
            entity.Property(e => e.DatumPozajmice).HasColumnName("datum_pozajmice");
            entity.Property(e => e.Glavnica).HasColumnName("glavnica");
            entity.Property(e => e.IdKorisnik).HasColumnName("id_korisnik");
            entity.Property(e => e.KamatnaStopa)
                .HasPrecision(4, 2)
                .HasColumnName("kamatna_stopa");
            entity.Property(e => e.StatusKredita).HasColumnName("status_kredita");
            entity.Property(e => e.VrijemeOtplate).HasColumnName("vrijeme_otplate");
            entity.Property(e => e.VrstaKredita)
                .HasMaxLength(50)
                .HasColumnName("vrsta_kredita");

            entity.HasOne(d => d.IdKorisnikNavigation).WithMany(p => p.Kredit)
                .HasForeignKey(d => d.IdKorisnik)
                .HasConstraintName("id_korisnik");
        });

        modelBuilder.Entity<Uplata>(entity =>
        {
            entity.HasKey(e => e.IdUplate).HasName("Uplata_pkey");

            entity.Property(e => e.IdUplate).HasColumnName("id_uplate");
            entity.Property(e => e.DatumUplate).HasColumnName("datum_uplate");
            entity.Property(e => e.IdKredit).HasColumnName("id_kredit");
            entity.Property(e => e.PreostaliDug)
                .HasPrecision(7, 2)
                .HasColumnName("preostali_dug");
            entity.Property(e => e.Uplata_novac)
                .HasPrecision(6, 2)
                .HasColumnName("uplata");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
