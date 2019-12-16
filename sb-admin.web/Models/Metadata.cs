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
        public int id { get; set; }
        [Display(Name = "Telefono")]
        public string telefono1 { get; set; }
        [Display(Name = "Tipo Telefono")]
        public Nullable<tipotelefono> tipo_telefono { get; set; }
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
        public int id { get; set; }
        [Display(Name ="Tipo de Evento")]
        public int tipo_evento { get; set; }
        [Display(Name = "Descripción de Evento")]

        public string descripcion_evento;
        [Display(Name = "Fecha Inicial" )]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? fecha_inicio { get; set; }

       [Display(Name ="Servicio")]              
        public Nullable<int> servicioId { get; set; }

        [Display(Name = "Expediente")]
        public Nullable<int> expedienteId { get; set; }
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
        [DisplayFormat(DataFormatString = "{0:hh\\:mm tt}")]
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

    public class juzgadoMetadata
    {
        public int id { get; set; }
        [Display(Name = "Nombre Juzgado")]
        public string nombre { get; set; }
        [Display(Name = "lugar")]
        public string lugar { get; set; }
        [Display(Name = "No. Piso")]
        public Nullable<short> piso { get; set; }
        [Display(Name = "Ciudad")]
        public string ciudad { get; set; }
        [Display(Name = "Nombre Juez")]
        public string nombre_juez { get; set; }
        [Display(Name = "Apellido juez")]
        public string apellido_juez { get; set; }
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
        [Display(Name = "Tipo Juzgado")]
        public int tipoId { get; set; }
    }

    public class servicioMetadata {

        public int id { get; set; }
        [Display(Name = "Descripción de Servicio")]
        public string descripcion { get; set; }
    }

    public class tareasMetadata {
        public int id { get; set; }
        [Display(Name = "Tarea")]
        public string tarea1 { get; set; }
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
        [Display(Name = "Estado")]
        public string estado { get; set; }
        [Display(Name = "Prioridad")]
        public string prioridad { get; set; }
        [Display(Name = "Caso")]
        public Nullable<int> casoId { get; set; }
        [Display(Name = "Responsable")]
        public Nullable<int> responsableId { get; set; }

    }
    public class tipo_eventoMetadata {
        public int id { get; set; }
        [Display(Name = "Tipo de Evento")]
        public string tipo_evento1 { get; set; }
    }
    public class ubicacionMetadata {
        public int id { get; set; }
        [Display(Name = "Ubicación")]
        public string ubicacion1 { get; set; }
    }

    public class tipo_juzgadoMetadata{
         public int id { get; set; }
        [Display(Name = "Tipo Juzgado")]
        public string tipo_j { get; set; }
    }
    public class tipoExpedienteMetadata
    {
        public int id { get; set; }
        [Display(Name = "Tipo Expediente")]
        public string tipo { get; set; }
    }
    public class parte_casoMetadata {
        [Display(Name = "Caso")]
        public Nullable<int> casoId { get; set; }
        [Display(Name = "Persona")]
        public Nullable<int> personaId { get; set; }
    }
    public class tipo_personaMetadata
    {

        public int id { get; set; }
        [Display(Name = "Tipo de Persona")]
        public string tipo_persona1 { get; set; }
    }

}