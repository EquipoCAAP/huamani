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

        // GET: casos
        public ActionResult Index(int? id, int? casoId)
        {
            var casoviewModel = new casoViewModel();
            casoviewModel.casos = db.caso
                .Include(c => c.avance)
                .Include(c => c.parte_caso)
                .Include(c => c.expediente)
                .Include(c => c.tarea)
                .Select(c=>c).ToList();

  
            if (id != null)
            {
                ViewBag.casoId = id.Value;
                casoviewModel.partes = casoviewModel.casos.Where(
                    c => c.id == id.Value).Single().parte_caso.ToList();
            }

            if (casoId != null)
            {
                ViewBag.casoId = id.Value;
                casoviewModel.partes = casoviewModel.partes.Where(
                    x => x.casoId == casoId).ToList();
            }

            return View(casoviewModel);


        }

        // GET: casos/Details/5
        public async Task<ActionResult> Details(int? id)
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

        // GET: casos/Create
        public ActionResult Create()
        {
            
            ViewBag.avanceId = new SelectList(db.avance, "id", "tipo_avance");
            ViewBag.responsableId = new SelectList(db.persona,"id", "nombre");
            ViewBag.aperturaId = new SelectList(db.persona, "id", "nombre");
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
            ViewBag.responsableId = new SelectList(db.persona, "id", "nombre",caso.responsableId);
            ViewBag.aperturaId = new SelectList(db.persona, "id", "nombre",caso.aperturaPersonaId);
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
            ViewBag.responsableId = new SelectList(db.persona, "id", "nombre", caso.responsableId);
            ViewBag.aperturaPersonaId = new SelectList(db.persona, "id", "nombre",caso.aperturaPersonaId);
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
            ViewBag.responsableId = new SelectList(db.persona, "id", "nombre",caso.responsableId);
            ViewBag.aperturaId = new SelectList(db.persona, "id","nombre", caso.aperturaPersonaId);
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
