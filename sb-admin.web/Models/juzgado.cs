
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
    
public partial class juzgado
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public juzgado()
    {

        this.juzgado_evento = new HashSet<juzgado_evento>();

    }


    public int id { get; set; }

    public string nombre { get; set; }

    public string lugar { get; set; }

    public Nullable<short> piso { get; set; }

    public string ciudad { get; set; }

    public string nombre_juez { get; set; }

    public string apellido_juez { get; set; }

    public string descripcion { get; set; }

    public int tipoId { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<juzgado_evento> juzgado_evento { get; set; }

    public virtual tipo_juzgado tipo_juzgado { get; set; }

}

}