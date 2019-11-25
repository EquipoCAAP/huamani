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
    public class tipo_eventoController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: tipo_evento
        public async Task<ActionResult> Index()
        {
            return View(await db.tipo_evento.ToListAsync());
        }

        // GET: tipo_evento/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_evento tipo_evento = await db.tipo_evento.FindAsync(id);
            if (tipo_evento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_evento);
        }

        // GET: tipo_evento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_evento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,tipo_evento1")] tipo_evento tipo_evento)
        {
            if (ModelState.IsValid)
            {
                db.tipo_evento.Add(tipo_evento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipo_evento);
        }

        // GET: tipo_evento/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_evento tipo_evento = await db.tipo_evento.FindAsync(id);
            if (tipo_evento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_evento);
        }

        // POST: tipo_evento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,tipo_evento1")] tipo_evento tipo_evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_evento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipo_evento);
        }

        // GET: tipo_evento/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_evento tipo_evento = await db.tipo_evento.FindAsync(id);
            if (tipo_evento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_evento);
        }

        // POST: tipo_evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tipo_evento tipo_evento = await db.tipo_evento.FindAsync(id);
            db.tipo_evento.Remove(tipo_evento);
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
