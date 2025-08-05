using System;
using System.Collections.Generic;
using DataBaseFirst.Models;
using DataBaseFirst.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst.Context;

public partial class PruebaTecnicaDbContext : DbContext
{
    public PruebaTecnicaDbContext()
    {
    }

    public PruebaTecnicaDbContext(DbContextOptions<PruebaTecnicaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<PeliculaSalaCine> PeliculaSalaCines { get; set; }

    public virtual DbSet<SalaCine> SalaCines { get; set; }

    public DbSet<SalaCineEstadoDto> SalaCineEstado { get; set; }

    public DbSet<FechaPublicacionDto> FechaPublicacion { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLSEXPRESS;Initial Catalog=PRUEBA_TECNICA;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.IdPelicula).HasName("PK__PELICULA__658881278EF40941");
        });

        modelBuilder.Entity<PeliculaSalaCine>(entity =>
        {
            entity.HasKey(e => e.IdPeliculaCine).HasName("PK__PELICULA__4EF9138A91C67932");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.PeliculaSalaCines).HasConstraintName("FK__PELICULA___ID_PE__4E88ABD4");

            entity.HasOne(d => d.IdSalaCineNavigation).WithMany(p => p.PeliculaSalaCines).HasConstraintName("FK__PELICULA___ID_SA__4D94879B");
        });

        modelBuilder.Entity<SalaCine>(entity =>
        {
            entity.HasKey(e => e.IdSala).HasName("PK__SALA_CIN__E8F6CE89EF22AD3E");
        });


        modelBuilder.Entity<SalaCineEstadoDto>().HasNoKey();

        modelBuilder.Entity<FechaPublicacionDto>().HasNoKey();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
