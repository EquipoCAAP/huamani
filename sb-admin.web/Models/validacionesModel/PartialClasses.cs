using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sb_admin.web.Models
{
    [MetadataType(typeof(avanceMetadata))]
    public partial class avance { }

    [MetadataType(typeof(personaMetadata))]
    public partial class persona
    {
        public string NombreCompleto { get { return nombre + " " + apellido; } }
    }

    [MetadataType(typeof(telefonoMetadata))]
    public partial class telefono { }

    [MetadataType(typeof(casoMetadata))]
    public partial class caso { }

    [MetadataType(typeof(eventoMetadata))]
    public partial class evento { }

    [MetadataType(typeof(expedienteMetadata))]
    public partial class expediente { }

    [MetadataType(typeof(juzgadoMetadata))]
    public partial class juzgado { }

    [MetadataType(typeof(servicioMetadata))]
    public partial class servicio { }

    [MetadataType(typeof(tipo_eventoMetadata))]
    public partial class tipo_evento { }

    [MetadataType(typeof(tipo_juzgadoMetadata))]
    public partial class tipo_juzgado { }

  

    [MetadataType(typeof(ubicacionMetadata))]
    public partial class ubicacion { }

    [MetadataType(typeof(tipoExpedienteMetadata))]
    public partial class tipoExpediente { }

    [MetadataType(typeof(parte_casoMetadata))]
    public partial class parte_caso { }
    [MetadataType(typeof(tipo_personaMetadata))]
    public partial class tipo_persona { }
    [MetadataType(typeof(estadoExpedienteMetadata))]
    public partial class estadoExpediente { }

    [MetadataType(typeof(tareaMetadata))]
    public partial class tarea { }

}