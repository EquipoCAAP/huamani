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
    
    public partial class expediente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public expediente()
        {
            this.documento = new HashSet<documento>();
            this.evento = new HashSet<evento>();
        }
    
        public int id { get; set; }
        public string titulo { get; set; }
        public Nullable<System.DateTime> fechacreacion { get; set; }
        public Nullable<System.TimeSpan> hora { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> estadoid { get; set; }
        public Nullable<int> tipoId { get; set; }
        public Nullable<int> claseId { get; set; }
        public Nullable<int> responsableId { get; set; }
        public Nullable<int> ubicacionId { get; set; }
        public int casoId { get; set; }
    
        public virtual caso caso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<documento> documento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<evento> evento { get; set; }
        public virtual persona persona { get; set; }
        public virtual tipoExpediente tipoExpediente { get; set; }
        public virtual ubicacion ubicacion { get; set; }
        public virtual claseExpediente claseExpediente { get; set; }
        public virtual estadoExpediente estadoExpediente { get; set; }
    }
}
