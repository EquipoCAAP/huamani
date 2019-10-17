using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sb_admin.web.Models
{
    [MetadataType(typeof(personaMetadata))]
    public partial class persona
    {
    }

    [MetadataType(typeof(telefonoMetadata))]
    public partial class telefono
    {
    }
}