using sb_admin.web.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace sb_admin.web.Controllers
{
    // aquí va  el [AuthActionFilter]

    public class HomeController : Controller
    {
        private GAHEContext db = new GAHEContext();
        public ActionResult Index()

        {
            DashboardViewModel dashboard = new DashboardViewModel();

            dashboard.casos_count = db.caso.Count();
            dashboard.expedientes_count = db.expediente.Count();
            dashboard.tareas_count = db.tarea.Count();
            dashboard.eventos_count = db.evento.Count();
            dashboard.casos=db.caso.Include(c => c.avance)
                .Include(c => c.parte_caso)
                .Include(c => c.expediente)
                .Include(c => c.tarea)
                .Select(c => c).ToList();
            dashboard.personas = db.persona.Include(p => p.parte_caso);
            dashboard.Expedientes = db.expediente.ToList();
            dashboard.Tareas = db.tarea.ToList();
            return View(dashboard);
        }

        public ActionResult Charts()
        {
            return View();
        }

        public ActionResult Tables()
        {
            return View();
        }

        public ActionResult Forms()
        {
            return View();
        }

        public ActionResult BootstrapElements()
        {
            return View();
        }

        public ActionResult BootstrapGrid()
        {
            return View();
        }

        public ActionResult BlankPage()
        {
            return View();
        }


    }
}