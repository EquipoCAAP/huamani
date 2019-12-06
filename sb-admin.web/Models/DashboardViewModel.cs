using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sb_admin.web.Models
{
    public class DashboardViewModel
    {
        public int expedientes_count { get; set; }
        public int casos_count { get; set; }
        public int eventos_count { get; set; }
        public int tareas_count { get; set; }
        public IEnumerable<caso> casos { get; set; }
      public IEnumerable<persona> personas { get; set; }
        public IEnumerable<expediente> Expedientes { get; set; }
       
    }

}