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
    public class juzgado_eventoController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: juzgado_evento
        public async Task<ActionResult> Index()
        {
            var juzgado_evento = db.juzgado_evento.Include(j => j.evento).Include(j => j.juzgado);
            return View(await juzgado_evento.ToListAsync());
        }

        // GET: juzgado_evento/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            juzgado_evento juzgado_evento = await db.juzgado_evento.FindAsync(id);
            if (juzgado_evento == null)
            {
                return HttpNotFound();
            }
            return View(juzgado_evento);
        }

        // GET: juzgado_evento/Create
        public ActionResult Create()
        {
            ViewBag.eventoId = new SelectList(db.evento, "id", "descripcion_evento");
            ViewBag.juzgadoId = new SelectList(db.juzgado, "id", "nombre");
            return View();
        }

        // POST: juzgado_evento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,juzgado_evento1,eventoId,juzgadoId")] juzgado_evento juzgado_evento)
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

        // GET: juzgado_evento/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            juzgado_evento juzgado_evento = await db.juzgado_evento.FindAsync(id);
            if (juzgado_evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.eventoId = new SelectList(db.evento, "id", "descripcion_evento", juzgado_evento.eventoId);
            ViewBag.juzgadoId = new SelectList(db.juzgado, "id", "nombre", juzgado_evento.juzgadoId);
            return View(juzgado_evento);
        }

        // POST: juzgado_evento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,juzgado_evento1,eventoId,juzgadoId")] juzgado_evento juzgado_evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juzgado_evento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.eventoId = new SelectList(db.evento, "id", "descripcion_evento", juzgado_evento.eventoId);
            ViewBag.juzgadoId = new SelectList(db.juzgado, "id", "nombre", juzgado_evento.juzgadoId);
            return View(juzgado_evento);
        }

        // GET: juzgado_evento/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            juzgado_evento juzgado_evento = await db.juzgado_evento.FindAsync(id);
            if (juzgado_evento == null)
            {
                return HttpNotFound();
            }
            return View(juzgado_evento);
        }

        // POST: juzgado_evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            juzgado_evento juzgado_evento = await db.juzgado_evento.FindAsync(id);
            db.juzgado_evento.Remove(juzgado_evento);
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
