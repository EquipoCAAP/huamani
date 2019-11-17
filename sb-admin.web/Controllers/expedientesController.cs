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
    public class expedientesController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: expedientes
        public async Task<ActionResult> Index()
        {
            var expediente = db.expediente.Include(e =>e.estadoExpediente).Include(e => e.caso).Include(e => e.ubicacion).Include(e => e.claseExpediente).Include(e => e.persona).Include(e => e.tipoExpediente);
            return View(await expediente.ToListAsync());
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
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
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
