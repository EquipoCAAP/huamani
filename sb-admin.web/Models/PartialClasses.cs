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

    [MetadataType(typeof(TelefonoMetadata))]
    public partial class Telefono { }
    [MetadataType(typeof(casoMetadata))]
    public partial class caso { }


}