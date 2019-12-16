using sb_admin.web.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace sb_admin.web.Controllers
{
    public class expedientesController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: expedientes
        public async Task<ActionResult> Index()
        {
            var expediente = db.expediente.Include(e =>e.estadoExpediente).Include(e => e.caso).Include(e => e.ubicacion).Include(e => e.claseExpediente).Include(e => e.persona).Include(e => e.tipoExpediente);
            return View(await expediente.ToListAsync());
        }

     
        // GET: juzgado_evento/Create
        public async Task<ActionResult> CreateJuzgadoEvento(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = await db.evento.FindAsync(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            var juzgado_evento = db.juzgado_evento.Include(j => j.evento).Where(je => je.eventoId == id).Include(j => j.juzgado);
            var juzgado_eventoselectionado = new juzgado_evento { eventoId = evento.id };
           
            ViewBag.juzgadoId = new SelectList(db.juzgado, "id", "nombre");
            return View( juzgado_eventoselectionado);
        }

        // POST: juzgado_evento/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateJuzgadoEvento( juzgado_evento juzgado_evento)
        {
            if (ModelState.IsValid)
            {
                db.juzgado_evento.Add(juzgado_evento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.eventoId = new SelectList(db.evento, "id", "descripcion_evento", juzgado_evento.eventoId);
            ViewBag.juzgadoId = new SelectList(db.juzgado, "id", "nombre", juzgado_evento.juzgadoId);
            return View(juzgado_evento);
        }

        // GET: eventos/Edit/5
        public async Task<ActionResult> EditEvento(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = await db.evento.FindAsync(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
         
            ViewBag.servicioId = new SelectList(db.servicio, "id", "descripcion", evento.servicioId);
            ViewBag.tipo_evento = new SelectList(db.tipo_evento, "id", "tipo_evento1", evento.tipo_evento);
            return View(evento);
        }

        // POST: eventos/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditEvento(evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}", evento.expedienteId));
            }
          
            ViewBag.servicioId = new SelectList(db.servicio, "id", "descripcion", evento.servicioId);
            ViewBag.tipo_evento = new SelectList(db.tipo_evento, "id", "tipo_evento1", evento.tipo_evento);
            return View(evento);
        }
        // GET: eventos/Create
        public async Task<ActionResult> CreateEvento(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            expediente expediente = await db.expediente.FindAsync(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }



            var evento = new evento { expedienteId= expediente.id };
            ViewBag.juzgadoId = new SelectList(db.juzgado, "id", "nombre");
            ViewBag.servicioId = new SelectList(db.servicio, "id", "descripcion");
            ViewBag.tipo_evento = new SelectList(db.tipo_evento, "id", "tipo_evento1");
            return View(evento);
        }

        // POST: eventos/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateEvento(evento evento)
        {
            if (ModelState.IsValid)
            {
                db.evento.Add(evento);
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}",evento.expedienteId));
            }

          
            ViewBag.servicioId = new SelectList(db.servicio, "id", "descripcion", evento.servicioId);
            ViewBag.tipo_evento = new SelectList(db.tipo_evento, "id", "tipo_evento1", evento.tipo_evento);
            return View(evento);
        }

        // GET: eventos/Delete/5
        public async Task<ActionResult> DeleteEvento(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = await db.evento.FindAsync(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            var expedienteId = evento.expedienteId;
            db.evento.Remove(evento);
            await db.SaveChangesAsync();
            return RedirectToAction(string.Format("Details/{0}", expedienteId));
        }

        // GET: expedientes/Details/5
        public async Task<ActionResult> DetailsEvento(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            evento evento = await db.evento.FindAsync(id);


            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
      }
        // GET: juzgado/Create
        public async Task<ActionResult> CreateJuzgado(string id, string idjuzgado)
        {
            if(id!=null && idjuzgado != null)
            {
                var juzgado_eventoSeleccionado = new juzgado_evento { eventoId = int.Parse(id), juzgadoId = int.Parse(idjuzgado) };

                db.juzgado_evento.Add(juzgado_eventoSeleccionado);
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("DetailsEvento/{0}", juzgado_eventoSeleccionado.eventoId));
            }
            ViewBag.idEvento = id;
            var juzgado = db.juzgado.Include(j => j.tipo_juzgado);
            return View(await juzgado.ToListAsync());
        }

    
        // GET: telefonos/Edit/5
        public async Task<ActionResult> EditJuzgado(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var juzgado_evento = await db.juzgado_evento.FirstOrDefaultAsync(je => je.eventoId == id);
            if (juzgado_evento == null)
            {
                return HttpNotFound();
            }

            return View(juzgado_evento);
        }

        public async Task<ActionResult> DeleteJuzgado(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var juzgado_evento = await db.juzgado_evento.FirstOrDefaultAsync(je => je.juzgadoId == id);
            

            if (juzgado_evento == null)
            {
                return HttpNotFound();
            }
            var eventoId = juzgado_evento.eventoId;
            
            db.juzgado_evento.Remove(juzgado_evento);

            await db.SaveChangesAsync();
            return RedirectToAction(string.Format("DetailsEvento/{0}", eventoId));
        }
       

        // POST: juzgado/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditJuzgado(juzgado juzgado, juzgado_evento juzgado_evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juzgado).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("DetailsJuzgado/{0}", juzgado_evento.eventoId));
            }
            return View(juzgado_evento);
        }



        // GET: expedientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            expediente expediente = await db.expediente.FindAsync(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            return View(expediente);
        }

        // GET: expedientes/Create
        public ActionResult Create()
        {
            ViewBag.casoId = new SelectList(db.caso, "id", "referencia");
            ViewBag.ubicacionId = new SelectList(db.ubicacion, "id", "ubicacion1");
            ViewBag.claseId = new SelectList(db.claseExpediente, "Id", "Clase");
            ViewBag.responsableId = new SelectList(db.persona, "id", "nombre");
            ViewBag.tipoId = new SelectList(db.tipoExpediente, "id", "tipo");
            ViewBag.estadoId = new SelectList(db.estadoExpediente, "id", "estado");
            return View();
        }

        // POST: expedientes/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,titulo,fechacreacion,hora,descripcion,estadoid,tipoId,claseId,responsableId,ubicacionId,casoId")] expediente expediente)
        {
            if (ModelState.IsValid)
            {
                db.expediente.Add(expediente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.casoId = new SelectList(db.caso, "id", "referencia", expediente.casoId);
            ViewBag.ubicacionId = new SelectList(db.ubicacion, "id", "ubicacion1", expediente.ubicacionId);
            ViewBag.claseId = new SelectList(db.claseExpediente, "Id", "Clase", expediente.claseId);
            ViewBag.responsableId = new SelectList(db.persona, "id", "dni", expediente.responsableId);
            ViewBag.tipoId = new SelectList(db.tipoExpediente, "id", "tipo", expediente.tipoId);
            ViewBag.estadoId = new SelectList(db.estadoExpediente, "id", "estado", expediente.estadoid);
            return View(expediente);
        }

        // GET: expedientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            expediente expediente = await db.expediente.FindAsync(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            ViewBag.casoId = new SelectList(db.caso, "id", "referencia", expediente.casoId);
            ViewBag.ubicacionId = new SelectList(db.ubicacion, "id", "ubicacion1", expediente.ubicacionId);
            ViewBag.claseId = new SelectList(db.claseExpediente, "Id", "Clase", expediente.claseId);
            ViewBag.responsableId = new SelectList(db.persona, "id", "dni", expediente.responsableId);
            ViewBag.tipoId = new SelectList(db.tipoExpediente, "id", "tipo", expediente.tipoId);
            ViewBag.estadoId = new SelectList(db.estadoExpediente, "id", "estado", expediente.estadoid);
            return View(expediente);
        }

        // POST: expedientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,titulo,fechacreacion,hora,descripcion,estadoid,tipoId,claseId,responsableId,ubicacionId,casoId")] expediente expediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expediente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.casoId = new SelectList(db.caso, "id", "referencia", expediente.casoId);
            ViewBag.ubicacionId = new SelectList(db.ubicacion, "id", "ubicacion1", expediente.ubicacionId);
            ViewBag.claseId = new SelectList(db.claseExpediente, "Id", "Clase", expediente.claseId);
            ViewBag.responsableId = new SelectList(db.persona, "id", "dni", expediente.responsableId);
            ViewBag.tipoId = new SelectList(db.tipoExpediente, "id", "tipo", expediente.tipoId);
            ViewBag.estadoId = new SelectList(db.estadoExpediente, "id", "estado", expediente.estadoid);
            return View(expediente);
        }

        // GET: expedientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            expediente expediente = await db.expediente.FindAsync(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            return View(expediente);
        }

        // POST: expedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            expediente expediente = await db.expediente.FindAsync(id);
            db.expediente.Remove(expediente);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
