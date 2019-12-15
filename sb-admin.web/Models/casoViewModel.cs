using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sb_admin.web.Models
{
    public class casoViewModel

    {
        public IEnumerable<caso> casos { get; set; }
        public IEnumerable<parte_caso> partes { get; set; }
        public IEnumerable<expediente> Expedientes { get; set; }
        public IEnumerable<persona> personas { get; set; }
        
        public int expedientes_count { get; set; }
        public int casos_count { get; set; }
        public persona personaApertura { get; set; }
        public persona personaResponsable { get; set; }


    }
}