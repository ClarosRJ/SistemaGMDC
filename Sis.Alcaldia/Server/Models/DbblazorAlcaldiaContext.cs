using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sis.Alcaldia.Server.Models;

public partial class DbblazorAlcaldiaContext : DbContext
{
    public DbblazorAlcaldiaContext(DbContextOptions<DbblazorAlcaldiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<CliColaboradore> CliColaboradores { get; set; }

    public virtual DbSet<CliFactura> CliFacturas { get; set; }

    public virtual DbSet<CliPago> CliPagos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ConfContabilidad> ConfContabilidads { get; set; }

    public virtual DbSet<EstadoHabitacion> EstadoHabitacions { get; set; }

    public virtual DbSet<Habitacion> Habitacions { get; set; }

    public virtual DbSet<Piso> Pisos { get; set; }

    public virtual DbSet<Recepcion> Recepcions { get; set; }

    public virtual DbSet<RolUsuario> RolUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A10806F6CDB");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<CliColaboradore>(entity =>
        {
            entity.HasKey(e => e.Idcolaborador).HasName("PK__Colabora__701807A5E288C1C4");

            entity.ToTable("CLI_Colaboradores");

            entity.Property(e => e.Idcolaborador).HasColumnName("IDColaborador");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ci)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CI");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Departamento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EstadoEmpleado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaContratacion).HasColumnType("date");
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nit)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NIT");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CliFactura>(entity =>
        {
            entity.HasKey(e => e.Idfactura).HasName("PK__CLI_Fact__492FE939A7E7AC10");

            entity.ToTable("CLI_Facturas");

            entity.Property(e => e.Idfactura).HasColumnName("IDFactura");
            entity.Property(e => e.Concepto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaEmision).HasColumnType("date");
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.Idcolaborador).HasColumnName("IDColaborador");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdcolaboradorNavigation).WithMany(p => p.CliFacturas)
                .HasForeignKey(d => d.Idcolaborador)
                .HasConstraintName("FK_CLI_Facturas_CLI_Colaboradores");
        });

        modelBuilder.Entity<CliPago>(entity =>
        {
            entity.HasKey(e => e.Idpago).HasName("PK__CLI_Pago__8A5C3DEED71356E4");

            entity.ToTable("CLI_Pagos");

            entity.Property(e => e.Idpago).HasColumnName("IDPago");
            entity.Property(e => e.Afp)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AFP");
            entity.Property(e => e.Bonos).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descuentos).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Detalle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaPago).HasColumnType("date");
            entity.Property(e => e.Idcolaborador).HasColumnName("IDColaborador");
            entity.Property(e => e.Idfactura).HasColumnName("IDFactura");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MontoPago).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Rciva)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("RCIVA");
            entity.Property(e => e.SeguroM).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdfacturaNavigation).WithMany(p => p.CliPagos)
                .HasForeignKey(d => d.Idfactura)
                .HasConstraintName("FK_CLI_Pagos_CLI_Facturas");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D5946642BC5CEA5A");

            entity.ToTable("Cliente");

            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Documento)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ConfContabilidad>(entity =>
        {
            entity.HasKey(e => e.IdConfig);

            entity.ToTable("Conf_Contabilidad");

            entity.Property(e => e.Afp).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Caja).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DetConfig)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gestion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rciva)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("RCiva");
            entity.Property(e => e.SueldoBas).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<EstadoHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdEstadoHabitacion).HasName("PK__EstadoHa__EBF610CEE17105D8");

            entity.ToTable("EstadoHabitacion");

            entity.Property(e => e.IdEstadoHabitacion).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__8BBBF9015FDFC3DE");

            entity.ToTable("Habitacion");

            entity.Property(e => e.Detalle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Habitacio__IdCat__5165187F");

            entity.HasOne(d => d.IdEstadoHabitacionNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdEstadoHabitacion)
                .HasConstraintName("FK__Habitacio__IdEst__4F7CD00D");

            entity.HasOne(d => d.IdPisoNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdPiso)
                .HasConstraintName("FK__Habitacio__IdPis__5070F446");
        });

        modelBuilder.Entity<Piso>(entity =>
        {
            entity.HasKey(e => e.IdPiso).HasName("PK__Piso__F2823D8AA28D914D");

            entity.ToTable("Piso");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Recepcion>(entity =>
        {
            entity.HasKey(e => e.IdRecepcion).HasName("PK__RECEPCIO__83F935CA891E6895");

            entity.ToTable("RECEPCION");

            entity.Property(e => e.Adelanto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CostoPenalidad)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FechaEntrada)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");
            entity.Property(e => e.FechaSalidaConfirmacion).HasColumnType("datetime");
            entity.Property(e => e.Observacion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PrecioInicial).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrecioRestante).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalPagado)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Recepcions)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__RECEPCION__IdCli__5629CD9C");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Recepcions)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__RECEPCION__IdHab__571DF1D5");
        });

        modelBuilder.Entity<RolUsuario>(entity =>
        {
            entity.HasKey(e => e.IdRolUsuario).HasName("PK__RolUsuar__3FC7F91FFC7045C0");

            entity.ToTable("RolUsuario");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF9771C34C8F");

            entity.ToTable("Usuario");

            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRolUsuario)
                .HasConstraintName("FK__Usuario__IdRolUs__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
