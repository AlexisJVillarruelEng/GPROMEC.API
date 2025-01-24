using System;
using System.Collections.Generic;
using GPROMEC.DOMAIN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GPROMEC.DOMAIN.Infrastructure.Data;

public partial class GdbContext : DbContext
{
    public GdbContext()
    {
    }

    public GdbContext(DbContextOptions<GdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArchivosGenerados> ArchivosGenerados { get; set; }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<DetalleIperc> DetalleIperc { get; set; }

    public virtual DbSet<FirmasMatrizIper> FirmasMatrizIper { get; set; }

    public virtual DbSet<Obras> Obras { get; set; }

    public virtual DbSet<Partidas> Partidas { get; set; }

    public virtual DbSet<Procesos> Procesos { get; set; }

    public virtual DbSet<Proyectos> Proyectos { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Tareas> Tareas { get; set; }

    public virtual DbSet<Trabajadores> Trabajadores { get; set; }

    public virtual DbSet<Ubigeo> Ubigeo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ALEXJH14;Database=gdb;User=sa;Pwd=12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArchivosGenerados>(entity =>
        {
            entity.HasKey(e => e.IdArchivo);

            entity.ToTable("Archivos_Generados");

            entity.Property(e => e.IdArchivo).HasColumnName("id_archivo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaGeneracion)
                .IsSparse()
                .HasColumnType("datetime")
                .HasColumnName("fecha_generacion");
            entity.Property(e => e.GeneradoPor)
                .HasMaxLength(250)
                .HasColumnName("generado_por");
            entity.Property(e => e.IdRelacion).HasColumnName("id_relacion");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_archivo");
            entity.Property(e => e.TablaRelacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tabla_relacion");
            entity.Property(e => e.TipoArchivo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_archivo");
            entity.Property(e => e.UrlArchivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url_archivo");

            entity.HasOne(d => d.IdRelacionNavigation).WithMany(p => p.ArchivosGenerados)
                .HasForeignKey(d => d.IdRelacion)
                .HasConstraintName("FK_Archivos_Generados_Proyectos");
        });

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.ContactoCliente)
                .HasMaxLength(50)
                .HasColumnName("contacto_cliente");
            entity.Property(e => e.CorreoCliente)
                .HasMaxLength(50)
                .HasColumnName("correo_cliente");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .HasColumnName("nombre_cliente");
            entity.Property(e => e.TelefonoCliente)
                .HasMaxLength(20)
                .HasColumnName("telefono_cliente");
        });

        modelBuilder.Entity<DetalleIperc>(entity =>
        {
            entity.HasKey(e => e.IdDetalle);

            entity.ToTable("DetalleIPERC");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.Capacitacion).HasColumnName("capacitacion");
            entity.Property(e => e.DescPeligros)
                .HasMaxLength(100)
                .HasColumnName("desc_peligros");
            entity.Property(e => e.ExpoRiesgo).HasColumnName("expo_riesgo");
            entity.Property(e => e.GradoRiesgo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("grado_riesgo");
            entity.Property(e => e.IdTarea).HasColumnName("id_tarea");
            entity.Property(e => e.MedidaControlDescrip)
                .HasColumnType("text")
                .HasColumnName("medida_control_descrip");
            entity.Property(e => e.NivielDeRiesgo).HasColumnName("niviel_de_riesgo");
            entity.Property(e => e.PersonasExpuestas).HasColumnName("personas_expuestas");
            entity.Property(e => e.Probabilidad).HasColumnName("probabilidad");
            entity.Property(e => e.ProcedimietntosExistentes).HasColumnName("procedimietntos_existentes");
            entity.Property(e => e.Riesgos)
                .HasMaxLength(200)
                .HasColumnName("riesgos");
            entity.Property(e => e.Severidad).HasColumnName("severidad");
            entity.Property(e => e.TipoPeligro)
                .HasMaxLength(10)
                .HasColumnName("tipo_peligro");
            entity.Property(e => e.TipoRiesgo)
                .HasMaxLength(10)
                .HasColumnName("tipo_riesgo");

            entity.HasOne(d => d.IdTareaNavigation).WithMany(p => p.DetalleIperc)
                .HasForeignKey(d => d.IdTarea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleIPERC_Tareas");
        });

        modelBuilder.Entity<FirmasMatrizIper>(entity =>
        {
            entity.HasKey(e => e.IdFirma);

            entity.ToTable("Firmas_matriz_iper");

            entity.Property(e => e.IdFirma).HasColumnName("id_firma");
            entity.Property(e => e.AprobadoPor).HasColumnName("aprobado_por");
            entity.Property(e => e.ElaboradoPor).HasColumnName("elaborado_por");
            entity.Property(e => e.FechaAprobado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_aprobado");
            entity.Property(e => e.FechaElaborado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_elaborado");
            entity.Property(e => e.FechaRevisado)
                .HasColumnType("datetime")
                .HasColumnName("fecha_revisado");
            entity.Property(e => e.FirmaAprobadoUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("firma_aprobado_url");
            entity.Property(e => e.FirmaElaboradoUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("firma_elaborado_url");
            entity.Property(e => e.FirmaRevisadoUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("firma_revisado_url");
            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.RevisadoPor).HasColumnName("revisado_por");

            entity.HasOne(d => d.AprobadoPorNavigation).WithMany(p => p.FirmasMatrizIperAprobadoPorNavigation)
                .HasForeignKey(d => d.AprobadoPor)
                .HasConstraintName("FK_Firmas_matriz_iper_Trabajadores2");

            entity.HasOne(d => d.ElaboradoPorNavigation).WithMany(p => p.FirmasMatrizIperElaboradoPorNavigation)
                .HasForeignKey(d => d.ElaboradoPor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Firmas_matriz_iper_Trabajadores");

            entity.HasOne(d => d.IdDetalleNavigation).WithMany(p => p.FirmasMatrizIper)
                .HasForeignKey(d => d.IdDetalle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Firmas_matriz_iper_DetalleIPERC");

            entity.HasOne(d => d.RevisadoPorNavigation).WithMany(p => p.FirmasMatrizIperRevisadoPorNavigation)
                .HasForeignKey(d => d.RevisadoPor)
                .HasConstraintName("FK_Firmas_matriz_iper_Trabajadores1");
        });

        modelBuilder.Entity<Obras>(entity =>
        {
            entity.HasKey(e => e.IdObra);

            entity.Property(e => e.IdObra).HasColumnName("id_obra");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
            entity.Property(e => e.NombreObra)
                .HasMaxLength(500)
                .HasColumnName("nombre_obra");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Obras)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Obras_Proyectos");
        });

        modelBuilder.Entity<Partidas>(entity =>
        {
            entity.HasKey(e => e.IdPartida);

            entity.Property(e => e.IdPartida).HasColumnName("id_partida");
            entity.Property(e => e.IdObra).HasColumnName("id_obra");
            entity.Property(e => e.NombrePartida)
                .HasMaxLength(200)
                .HasColumnName("nombre_partida");

            entity.HasOne(d => d.IdObraNavigation).WithMany(p => p.Partidas)
                .HasForeignKey(d => d.IdObra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Partidas_Obras");
        });

        modelBuilder.Entity<Procesos>(entity =>
        {
            entity.HasKey(e => e.IdProceso);

            entity.Property(e => e.IdProceso).HasColumnName("id_proceso");
            entity.Property(e => e.IdPartida).HasColumnName("id_partida");
            entity.Property(e => e.NombreProceso)
                .HasMaxLength(200)
                .HasColumnName("nombre_proceso");

            entity.HasOne(d => d.IdPartidaNavigation).WithMany(p => p.Procesos)
                .HasForeignKey(d => d.IdPartida)
                .HasConstraintName("FK_Procesos_Partidas");
        });

        modelBuilder.Entity<Proyectos>(entity =>
        {
            entity.HasKey(e => e.IdProyecto);

            entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(200)
                .HasColumnName("nombre_proyecto");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_Proyectos_Clientes");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .HasColumnName("nombre_rol");
        });

        modelBuilder.Entity<Tareas>(entity =>
        {
            entity.HasKey(e => e.IdTarea);

            entity.Property(e => e.IdTarea).HasColumnName("id_tarea");
            entity.Property(e => e.IdProceso).HasColumnName("id_proceso");
            entity.Property(e => e.NombreTarea)
                .HasMaxLength(500)
                .HasColumnName("nombre_tarea");
            entity.Property(e => e.TareaTipo)
                .HasMaxLength(5)
                .HasColumnName("tarea_tipo");

            entity.HasOne(d => d.IdProcesoNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdProceso)
                .HasConstraintName("FK_Tareas_Procesos");
        });

        modelBuilder.Entity<Trabajadores>(entity =>
        {
            entity.HasKey(e => e.IdTrabajador).HasName("PK_Trabajoders");

            entity.Property(e => e.IdTrabajador).HasColumnName("id_trabajador");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasColumnName("correo");
            entity.Property(e => e.Dni)
                .HasMaxLength(50)
                .HasColumnName("dni");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.IdUbigeo).HasColumnName("id_ubigeo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Trabajadores)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajoders_Roles");

            entity.HasOne(d => d.IdUbigeoNavigation).WithMany(p => p.Trabajadores)
                .HasForeignKey(d => d.IdUbigeo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trabajoders_Ubigeo");
        });

        modelBuilder.Entity<Ubigeo>(entity =>
        {
            entity.HasKey(e => e.IdUbigeo);

            entity.Property(e => e.IdUbigeo).HasColumnName("id_ubigeo");
            entity.Property(e => e.Departamento)
                .HasMaxLength(50)
                .HasColumnName("departamento");
            entity.Property(e => e.Distrito)
                .HasMaxLength(50)
                .HasColumnName("distrito");
            entity.Property(e => e.Provincia)
                .HasMaxLength(50)
                .HasColumnName("provincia");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
