using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace proje.Models;

public partial class ProjeDbContext : DbContext
{
    public ProjeDbContext()
    {
    }

    public ProjeDbContext(DbContextOptions<ProjeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblPersonal> TblPersonals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MEMRE35;Database=projeDB;Trusted_Connection=True;TrustServerCertificate=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblPersonal>(entity =>
        {
            entity.ToTable("tblPersonal");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Mail).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PersonalNumber).HasMaxLength(10);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            entity.Property(e => e.Surname).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
