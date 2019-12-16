using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sb_admin.web.Models
{
    public class EventoViewModel
    {
        public IEnumerable<evento> Eventos { get; set; }
        public IEnumerable<juzgado> juzgados { get; set; }
        public IEnumerable<juzgado_evento> juzgado_eventos { get; set; }

       


    }
}