using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sb_admin.web.Models
{
  
        public partial class AbogadoViewModel
    {
             public AbogadoViewModel()
        {

            this.parte_caso = new HashSet<parte_caso>();

            this.tarea = new HashSet<tarea>();

            this.telefono_persona = new HashSet<telefono_persona>();

            this.expediente = new HashSet<expediente>();

        }


        public int id { get; set; }

        public string dni { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string celular { get; set; }

        public Nullable<int> tipo { get; set; }

        public Nullable<int> usuarioId { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<parte_caso> parte_caso { get; set; }

        public virtual tipo_persona tipo_persona { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<tarea> tarea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<telefono_persona> telefono_persona { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<expediente> expediente { get; set; }

    }

}