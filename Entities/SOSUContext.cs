using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities;

public partial class SOSUContext : DbContext
{
    public SOSUContext()
    {
    }

    public SOSUContext(DbContextOptions<SOSUContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Tenent> Tenents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SOSU5000;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Assignme__3214EC0765344EB6");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.SosuId)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Titel).HasMaxLength(100);

            entity.HasOne(d => d.Sosu).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.SosuId)
                .HasConstraintName("FK_Assignments_Employee");

            entity.HasOne(d => d.Tenent).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.TenentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assignments_Tenent");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07E64B7F2E");

            entity.ToTable("Employee");

            entity.Property(e => e.Id)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Tenent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07418D63D2");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
