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
    public class tareasController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: tareas
        public async Task<ActionResult> Index()
        {
            var tarea = db.tarea.Include(t => t.caso).Include(t => t.persona);
            return View(await tarea.ToListAsync());
        }

        // GET: tareas/Details/5
        public async Task<ActionResult> Details(int? id)
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
            return View(tarea);
        }

        // GET: tareas/Create
        public ActionResult Create()
        {
            ViewBag.casoId = new SelectList(db.caso, "id", "referencia");
            ViewBag.responsableId = new SelectList(db.persona, "id", "dni");
            return View();
        }

        // POST: tareas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,tarea1,descripcion,estadoId,prioridadId,casoId,responsableId")] tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.tarea.Add(tarea);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.casoId = new SelectList(db.caso, "id", "referencia", tarea.casoId);
            ViewBag.responsableId = new SelectList(db.persona, "id", "dni", tarea.responsableId);
            return View(tarea);
        }

        // GET: tareas/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
            ViewBag.casoId = new SelectList(db.caso, "id", "referencia", tarea.casoId);
            ViewBag.responsableId = new SelectList(db.persona, "id", "dni", tarea.responsableId);
            return View(tarea);
        }

        // POST: tareas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,tarea1,descripcion,estadoId,prioridadId,casoId,responsableId")] tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarea).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.casoId = new SelectList(db.caso, "id", "referencia", tarea.casoId);
            ViewBag.responsableId = new SelectList(db.persona, "id", "dni", tarea.responsableId);
            return View(tarea);
        }

        // GET: tareas/Delete/5
        public async Task<ActionResult> Delete(int? id)
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
            return View(tarea);
        }

        // POST: tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tarea tarea = await db.tarea.FindAsync(id);
            db.tarea.Remove(tarea);
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
