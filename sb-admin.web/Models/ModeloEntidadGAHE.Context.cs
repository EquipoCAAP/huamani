﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace sb_admin.web.Models
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class GAHEContext : DbContext
{
    public GAHEContext()
        : base("name=GAHEContext")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<avance> avance { get; set; }

    public virtual DbSet<caso> caso { get; set; }

    public virtual DbSet<documento> documento { get; set; }

    public virtual DbSet<evento> evento { get; set; }

    public virtual DbSet<expediente> expediente { get; set; }

    public virtual DbSet<juzgado_evento> juzgado_evento { get; set; }

    public virtual DbSet<Navbar> Navbar { get; set; }

    public virtual DbSet<parte_caso> parte_caso { get; set; }

    public virtual DbSet<persona> persona { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<servicio> servicio { get; set; }

    public virtual DbSet<tarea> tarea { get; set; }

    public virtual DbSet<telefono> telefono { get; set; }

    public virtual DbSet<telefono_persona> telefono_persona { get; set; }

    public virtual DbSet<tipo_evento> tipo_evento { get; set; }

    public virtual DbSet<tipo_persona> tipo_persona { get; set; }

    public virtual DbSet<ubicacion> ubicacion { get; set; }

    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<juzgado> juzgado { get; set; }

    public virtual DbSet<tipo_juzgado> tipo_juzgado { get; set; }

}

}
