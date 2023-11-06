using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Aula_Banco_De_Dados.Model;

public partial class AulaBcContext : DbContext
{
    public AulaBcContext()
    {
    }

    public AulaBcContext(DbContextOptions<AulaBcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carro> Carros { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<Loja> Lojas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-001YW\\SQLEXPRESS;Initial Catalog=aulaBC;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carro__3214EC271E293176");

            entity.ToTable("Carro");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Placa)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Funciona__3214EC27603AC0AB");

            entity.ToTable("Funcionario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Edv).HasColumnName("EDV");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Loja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Loja__3214EC27EC210ECF");

            entity.ToTable("Loja");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Endereco)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CarroNavigation).WithMany(p => p.Lojas)
                .HasForeignKey(d => d.Carro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Loja__Carro__3B75D760");

            entity.HasOne(d => d.FuncionarioNavigation).WithMany(p => p.Lojas)
                .HasForeignKey(d => d.Funcionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Loja__Funcionari__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
