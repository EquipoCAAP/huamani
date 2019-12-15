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
        [Display(Name = "Responsable")]
        public int responsableId;
        [Display(Name = "Avance")]
        public int avanceId;
        [Display(Name = "Creador")]
        public int aperturaPersonaId;
        [Required]
        public string referencia;
        [Display(Name = "Fecha de Creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fecha_creacion;
    }

    public class eventoMetadata
    {
        [Display(Name = "Descripción de Evento")]
        public string descripcion_evento;
        [Display(Name = "Fecha Inicial" )]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fecha_inicio;
           
    }

    public class expedienteMetadata
    {
        
        public int id { get; set; }
        [Display(Name = "Título Expediente") ]
        public string titulo { get; set; }
        [Display(Name = "Fecha de Creación" )]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> fechacreacion { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora de Creación") ]
        public Nullable<System.TimeSpan> hora { get; set; }

        [Display(Name = "Descripción" )]
        public string descripcion { get; set; }
        [Display(Name = "Estado")]
        public Nullable<int> estadoid { get; set; }
        [Display(Name = "Tipo")]
        public Nullable<int> tipoId { get; set; }
        [Display(Name = "Clase")]
        public Nullable<int> claseId { get; set; }
        [Display(Name = "Responsable")]
        public Nullable<int> responsableId { get; set; }
        [Display(Name = "Ubicación")]
        public Nullable<int> ubicacionId { get; set; }
        [Display(Name = "Caso")]
        public int casoId { get; set; }
    }
}