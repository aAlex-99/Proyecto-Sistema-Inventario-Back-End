using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaInvApi.Models;

public partial class InventarioTicsContext : DbContext
{
    public InventarioTicsContext()
    {
    }

    public InventarioTicsContext(DbContextOptions<InventarioTicsContext> options)
        : base(options)
    {
    }


    public static List<Usuario> LoginDetails(DbContext dbContext, Login login)
    {
        try
        {
            var usuarios = dbContext.Set<Usuario>()
                .Where(u => u.Correo == login.Correo && u.Password == login.Password)
                .ToList();

            return usuarios;
        }
        catch (Exception)
        {

            return new List<Usuario>();
        }
    }




    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-F2FMKFS; DataBase=Inventario-Tics; User Id=sa;Password=18361093; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.IdArea).HasName("PK__Areas__750ECEA450EE00D2");

            entity.Property(e => e.IdArea).HasColumnName("idArea");
            entity.Property(e => e.DireccionArea)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccionArea");
            entity.Property(e => e.NombreArea)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombreArea");
            entity.Property(e => e.NumSucursal)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Responsable)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.IdPersonal).HasName("PK__Personal__D840C9FD2CFC2C16");

            entity.ToTable("Personal");

            entity.Property(e => e.IdPersonal).HasColumnName("idPersonal");
            entity.Property(e => e.Extencion).HasColumnName("extencion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.IdArea).HasColumnName("idArea");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdArea)
                .HasConstraintName("FK__Personal__idArea__45F365D3");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Personal__idRol__44FF419A");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__3C872F76490C9C57");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__645723A6A66DEB2A");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.IdArea).HasColumnName("idArea");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdArea)
                .HasConstraintName("FK__Usuarios__idArea__412EB0B6");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuarios__idRol__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
