using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sb_admin.web.Models
{
    public class avanceMetadata
    {
        [Display(Name ="Tipo de avance")]
        public string tipo_avance;
    }
    public class personaMetadata
    {
        [StringLength(10)]
        [Display(Name = "Identificación")]
        public string dni;

        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string nombre;

        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string apellido;
        [StringLength(12)]
        [Display(Name = "Celular")]
        public string celular;

        [Display(Name = "Tipo de Persona")]
        public string tipo_persona;

        [Display(Name = "relacionada")]
        public Nullable<int> usuarioId;
    }

    public class telefonoMetadata
    {
        [Display(Name = "Tipo de teléfono")]
        public int tipo_telefono;
        [Display(Name = "Teléfono")]
        public string telefono1;
    }

    public class casoMetadata
    {
        [Required]
        public string referencia;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime fecha_creacion;
    }

    public class eventoMetadata
    {
        [Display(Name = "Descripción de Evento")]
        public string descripcion_evento;
        [Display(Name = "Fecha Inicial" )]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha_inicio;

    
    }
}