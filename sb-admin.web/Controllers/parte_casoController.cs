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
    public class parte_casoController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: parte_caso
        public async Task<ActionResult> Index()
        {
            var parte_caso = db.parte_caso.Include(p => p.caso).Include(p => p.persona);
            return View(await parte_caso.ToListAsync());
        }

        // GET: parte_caso/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parte_caso parte_caso = await db.parte_caso.FindAsync(id);
            if (parte_caso == null)
            {
                return HttpNotFound();
            }
            return View(parte_caso);
        }

        // GET: parte_caso/Create
        public ActionResult Create()
        {
            ViewBag.casoId = new SelectList(db.caso, "id", "referencia");
            ViewBag.personaId = new SelectList(db.persona, "id", "dni");
            return View();
        }

        // POST: parte_caso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,casoId,personaId")] parte_caso parte_caso)
        {
            if (ModelState.IsValid)
            {
                db.parte_caso.Add(parte_caso);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.casoId = new SelectList(db.caso, "id", "referencia", parte_caso.casoId);
            ViewBag.personaId = new SelectList(db.persona, "id", "dni", parte_caso.personaId);
            return View(parte_caso);
        }

        // GET: parte_caso/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parte_caso parte_caso = await db.parte_caso.FindAsync(id);
            if (parte_caso == null)
            {
                return HttpNotFound();
            }
            ViewBag.casoId = new SelectList(db.caso, "id", "referencia", parte_caso.casoId);
            ViewBag.personaId = new SelectList(db.persona, "id", "dni", parte_caso.personaId);
            return View(parte_caso);
        }

        // POST: parte_caso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,casoId,personaId")] parte_caso parte_caso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parte_caso).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.casoId = new SelectList(db.caso, "id", "referencia", parte_caso.casoId);
            ViewBag.personaId = new SelectList(db.persona, "id", "dni", parte_caso.personaId);
            return View(parte_caso);
        }

        // GET: parte_caso/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parte_caso parte_caso = await db.parte_caso.FindAsync(id);
            if (parte_caso == null)
            {
                return HttpNotFound();
            }
            return View(parte_caso);
        }

        // POST: parte_caso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            parte_caso parte_caso = await db.parte_caso.FindAsync(id);
            db.parte_caso.Remove(parte_caso);
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
