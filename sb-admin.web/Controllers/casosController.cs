using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sb_admin.web.Models;

namespace sb_admin.web.Controllers
{
    public class casosController : Controller
    {
        
        private GAHEContext db = new GAHEContext();

        // GET: tareas/Create
        public async Task<ActionResult> CreateTareaAsync(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            caso caso = await db.caso.FindAsync(id);
            if (caso == null)
            {
                return HttpNotFound();
            }

            var tarea = new tarea { casoId = caso.id };
            ViewBag.EstadoTareaId = new SelectList(db.tarea, "id", "");
            ViewBag.casoId = new SelectList(db.caso, "id", "referencia");
            ViewBag.responsableId = new SelectList(db.persona.Where(p=>p.tipo==1), "id", "NombreCompleto");
            return View(tarea);
        }

        // POST: tareas/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTareaAsync(tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.tarea.Add(tarea);
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}", tarea.casoId));
            }
            ViewBag.EstadoTareaId = new SelectList(db.tarea, "id", "Estado",tarea.estadoId);
            ViewBag.casoId = new SelectList(db.caso, "id", "Referencia", tarea.casoId);
            ViewBag.responsableId = new SelectList(db.persona.Where(p => p.tipo == 1), "id", "NombreCompleto", tarea.responsableId);

            return View(tarea);
        }

        // GET: tareas/Edit/5
        public async Task<ActionResult> EditTarea(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarea tarea = await db.tarea.FindAsync(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoTareaId = new SelectList(db.tarea, "id", "Estado", tarea.estadoId);
            ViewBag.casoId = new SelectList(db.caso, "id", "Referencia", tarea.casoId);
            ViewBag.responsableId = new SelectList(db.persona.Where(p => p.tipo == 1), "id", "NombreCompleto", tarea.responsableId);
            return View(tarea);
        }
      
        // POST: tareas/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTarea(tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarea).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}", tarea.casoId));
            }
            ViewBag.EstadoTareaId = new SelectList(db.tarea, "id", "Estado", tarea.estadoId);
            ViewBag.casoId = new SelectList(db.caso, "id", "Referencia", tarea.casoId);
            ViewBag.responsableId = new SelectList(db.persona.Where(p => p.tipo == 1), "id", "NombreCompleto", tarea.responsableId);
            return View(tarea);
        }

        // POST: personas/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPersona(persona persona, parte_caso parte_caso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}", parte_caso.casoId));
            }
            ViewBag.tipo = new SelectList(db.tipo_persona.Where(P => P.id != 2), "id", "tipo_persona1", persona.tipo);
            ViewBag.usuarioId = new SelectList(db.User.Where(P => P.Id == 1), "Id", "user1", persona.usuarioId);
            return View(parte_caso);
        }
        // GET: clientes/Create
        public async Task<ActionResult> CreatePersonaAsync(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            caso caso = await db.caso.FindAsync(id);
            if (caso == null)
            {
                return HttpNotFound();
            }
            var parte = new parte_caso { casoId = caso.id };
            
            ViewBag.tipo = new SelectList(db.tipo_persona.Where(P => P.id != 2), "id", "tipo_persona1");
            ViewBag.usuarioId = new SelectList(db.User.Where(P => P.Id == 1), "Id", "user1");
            return View(parte);
        }

        // POST: clientes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePersonaAsync( persona persona, int id)
        {
            if (ModelState.IsValid)
            {
                db.persona.Add(persona);
                await db.SaveChangesAsync();
                int lastidpersona = persona.id;
                var partes_caso = new parte_caso { personaId = lastidpersona, casoId = id };

                db.parte_caso.Add(partes_caso);
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}", partes_caso.casoId));
            }

            ViewBag.tipo = new SelectList(db.tipo_persona.Where(P => P.id != 2), "id", "tipo_persona1", persona.tipo);
            ViewBag.usuarioId = new SelectList(db.User.Where(P => P.Id == 1), "Id", "user1", persona.usuarioId);
            return View(persona);
        }

        // GET: personas/Edit/5
        public async Task<ActionResult> EditPersona(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var parte_caso = await db.parte_caso.FirstOrDefaultAsync(pc => pc.personaId == id);
           
            if (parte_caso == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipo = new SelectList(db.tipo_persona.Where(P => P.id != 2), "id", "tipo_persona1", parte_caso.persona.tipo);
            ViewBag.usuarioId = new SelectList(db.User.Where(P => P.Id == 1), "Id", "user1", parte_caso.persona.usuarioId);
            return View(parte_caso);
        }

        // POST: personas/Edit/5
      
     
        // GET: personas/Delete/5
        public async Task<ActionResult> DeletePersona(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  int casoId = Convert.ToInt32(HttpContext.Request.QueryString["casoId"]);
            parte_caso parte_caso = await db.parte_caso.FindAsync(id);
            if (parte_caso == null)
            {
                return HttpNotFound();
            }
            int? caso = parte_caso.casoId;
            db.parte_caso.Remove(parte_caso);
            await db.SaveChangesAsync();
            return RedirectToAction(string.Format("Details/{0}", caso));
        }
        public async Task<ActionResult> DeleteTelefono(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var telefono_persona = await db.telefono_persona.FirstOrDefaultAsync(tp => tp.telefonosId == id);
            var telefono = await db.telefono.FirstOrDefaultAsync(t => t.id == id);

            if (telefono_persona == null)
            {
                return HttpNotFound();
            }
            var personaId = telefono_persona.personaId;
            db.telefono.Remove(telefono);
            db.telefono_persona.Remove(telefono_persona);

            await db.SaveChangesAsync();
            return RedirectToAction(string.Format("Details/{0}", personaId));
        }

        // GET: expedientes/Details/5
        public async Task<ActionResult> DetailsExpediente(int? id)
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
            return RedirectToAction(string.Format("Details/{0}", expediente.id),"Expedientes"); ;
        }

        // GET: expedientes/Edit/5
        public async Task<ActionResult> EditExpediente(int? id)
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
            
            ViewBag.ubicacionId = new SelectList(db.ubicacion, "id", "ubicacion1", expediente.ubicacionId);
            ViewBag.claseId = new SelectList(db.claseExpediente, "Id", "Clase", expediente.claseId);
            ViewBag.responsableId = new SelectList(db.persona.Where(p=>p.tipo==2), "id", "NombreCompleto", expediente.responsableId);
            ViewBag.tipoId = new SelectList(db.tipoExpediente, "id", "tipo", expediente.tipoId);
            ViewBag.estadoId = new SelectList(db.estadoExpediente, "id", "estado", expediente.estadoid);
            return View(expediente);
        }

        // POST: expedientes/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditExpediente(expediente expediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expediente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}", expediente.casoId));
            }
           
            ViewBag.ubicacionId = new SelectList(db.ubicacion, "id", "ubicacion1", expediente.ubicacionId);
            ViewBag.claseId = new SelectList(db.claseExpediente, "Id", "Clase", expediente.claseId);
            ViewBag.responsableId = new SelectList(db.persona.Where(p=>p.tipo==2), "id", "NombreCompleto", expediente.responsableId);
            ViewBag.tipoId = new SelectList(db.tipoExpediente, "id", "tipo", expediente.tipoId);
            ViewBag.estadoId = new SelectList(db.estadoExpediente, "id", "estado", expediente.estadoid);
            return View(expediente);
        }
        // GET: Expedientes/Create
        public async Task<ActionResult> CreateExpediente(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            caso caso = await db.caso.FindAsync(id);
            if (caso == null)
            {
                return HttpNotFound();
            }
                        
            var expediente = new expediente { casoId = caso.id };
            ViewBag.casoId = new SelectList(db.caso, "id", "referencia");
            ViewBag.ubicacionId = new SelectList(db.ubicacion, "id", "ubicacion1");
            ViewBag.claseId = new SelectList(db.claseExpediente, "Id", "Clase");
            ViewBag.responsableId = new SelectList(db.persona.Where(p=>p.tipo==2), "id", "NombreCompleto");
            ViewBag.tipoId = new SelectList(db.tipoExpediente, "id", "tipo");
            ViewBag.estadoId = new SelectList(db.estadoExpediente, "id", "estado");
            return View(expediente);
        }

      
        // POST: expedientes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateExpediente( expediente expediente)
        {
            if (ModelState.IsValid)
            {
                db.expediente.Add(expediente);
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}", expediente.casoId));
            }

            ViewBag.casoId = new SelectList(db.caso, "id", "referencia", expediente.casoId);
            ViewBag.ubicacionId = new SelectList(db.ubicacion, "id", "ubicacion1", expediente.ubicacionId);
            ViewBag.claseId = new SelectList(db.claseExpediente, "Id", "Clase", expediente.claseId);
            ViewBag.responsableId = new SelectList(db.persona.Where(p=>p.tipo==2), "id", "NombreCompleto", expediente.responsableId);
            ViewBag.tipoId = new SelectList(db.tipoExpediente, "id", "tipo", expediente.tipoId);
            ViewBag.estadoId = new SelectList(db.estadoExpediente, "id", "estado", expediente.estadoid);
            return View(expediente);
        }

        public async Task<ActionResult> DeleteExpediente(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            expediente expediente = await db.expediente.FindAsync(id);
            var casoId = expediente.casoId;
            if (expediente == null)
            {
                return HttpNotFound();
            }

            db.expediente.Remove(expediente);
            await db.SaveChangesAsync();
            return RedirectToAction(string.Format("Details/{0}", casoId));
        }



        // GET: casos
        public async Task<ActionResult> Index()
        {
            casoViewModel casovm = new casoViewModel();

            casovm.casos = await db.caso.Include(c => c.avance)
                .Include(c => c.parte_caso)
                .Include(c => c.expediente)
                .Include(c => c.tarea)
                .Select(c => c).ToListAsync();
            casovm.personas = await db.persona.Include(p => p.parte_caso).ToListAsync();
            casovm.Expedientes = await db.expediente.ToListAsync();
            casovm.tareas = await db.tarea.Include(t => t.caso).Include(t => t.persona).ToListAsync();
            
            return View(casovm);
        }

        // GET: casos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            casoViewModel casovm = new casoViewModel();

            casovm.casos = await db.caso.Include(c => c.avance)
                .Include(c => c.parte_caso)
                .Include(c => c.expediente)
                .Include(c => c.tarea).Where(c=>c.id==id).ToListAsync();

            List<persona> personas = await db.persona.Where(pc=>pc.parte_caso.Any(c=>c.casoId==id)).ToListAsync();
            casovm.personas = personas;
            List<expediente> expedientes = await db.expediente.Where(c=>c.casoId==id).ToListAsync();
            casovm.Expedientes = expedientes;
            var idcliente = casovm.casos.First().responsableId;
            casovm.personaResponsable = db.persona.First(p => p.id == idcliente);
            var idencargado = casovm.casos.First().aperturaPersonaId;
            casovm.personaApertura = db.persona.First(p => p.id == idencargado);
            casovm.tareas = await db.tarea.Include(t => t.caso).Include(t => t.persona).Where(c => c.casoId == id).ToListAsync();

            if (casovm.casos == null)
            {
                return HttpNotFound();
            }
            return View(casovm);
        }

        // GET: casos/Create
        public ActionResult Create()
        {
            ViewBag.avanceId = new SelectList(db.avance, "id", "tipo_avance");
            ViewBag.responsableId = new SelectList(db.persona.Where(p=>p.tipo==2), "id", "NombreCompleto");
            ViewBag.aperturaPersonaId = new SelectList(db.persona.Where(p=>p.tipo==1), "id", "NombreCompleto");
            return View();
        }

        // POST: casos/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,referencia,fecha_creacion,responsableId,avanceId,aperturaPersonaId")] caso caso)
        {
            if (ModelState.IsValid)
            {
                db.caso.Add(caso);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.avanceId = new SelectList(db.avance, "id", "tipo_avance", caso.avanceId);
            ViewBag.responsableId = new SelectList(db.persona.Where(p=>p.tipo==2), "id", "NombreCompleto", caso.responsableId);
            ViewBag.aperturaPersonaId = new SelectList(db.persona.Where(p=>p.tipo==1), "id", "NombreCompleto", caso.aperturaPersonaId);
            return View(caso);
        }

        // GET: casos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            caso caso = await db.caso.FindAsync(id);
            if (caso == null)
            {
                return HttpNotFound();
            }
            ViewBag.avanceId = new SelectList(db.avance, "id", "tipo_avance", caso.avanceId);
            ViewBag.responsableId = new SelectList(db.persona.Where(p=>p.tipo==2), "id", "NombreCompleto", caso.responsableId);
            ViewBag.aperturaPersonaId = new SelectList(db.persona.Where(p=>p.tipo==1), "id", "NombreCompleto", caso.aperturaPersonaId);
            return View(caso);
        }

        // POST: casos/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,referencia,fecha_creacion,responsableId,avanceId,aperturaPersonaId")] caso caso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caso).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.avanceId = new SelectList(db.avance, "id", "tipo_avance", caso.avanceId);
            ViewBag.responsableId = new SelectList(db.persona.Where(p => p.tipo == 2), "id", "NombreCompleto", caso.responsableId);
            ViewBag.aperturaPersonaId = new SelectList(db.persona.Where(p => p.tipo == 1), "id", "NombreCompleto", caso.aperturaPersonaId);
            return View(caso);
        }

        // GET: casos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            caso caso = await db.caso.FindAsync(id);
            if (caso == null)
            {
                return HttpNotFound();
            }
            return View(caso);
        }

        // POST: casos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            caso caso = await db.caso.FindAsync(id);
            db.caso.Remove(caso);
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
