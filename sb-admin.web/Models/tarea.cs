
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
    using System.Collections.Generic;
    
public partial class tarea
{

    public int id { get; set; }

    public string tarea1 { get; set; }

    public string descripcion { get; set; }

    public string estado { get; set; }

    public string prioridad { get; set; }

    public Nullable<int> casoId { get; set; }

    public Nullable<int> responsableId { get; set; }



    public virtual caso caso { get; set; }

    public virtual persona persona { get; set; }

}

}
