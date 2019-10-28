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
    public class tipoExpedientesController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: tipoExpedientes
        public async Task<ActionResult> Index()
        {
            return View(await db.tipoExpediente.ToListAsync());
        }

        // GET: tipoExpedientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoExpediente tipoExpediente = await db.tipoExpediente.FindAsync(id);
            if (tipoExpediente == null)
            {
                return HttpNotFound();
            }
            return View(tipoExpediente);
        }

        // GET: tipoExpedientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoExpedientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,tipo")] tipoExpediente tipoExpediente)
        {
            if (ModelState.IsValid)
            {
                db.tipoExpediente.Add(tipoExpediente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoExpediente);
        }

        // GET: tipoExpedientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoExpediente tipoExpediente = await db.tipoExpediente.FindAsync(id);
            if (tipoExpediente == null)
            {
                return HttpNotFound();
            }
            return View(tipoExpediente);
        }

        // POST: tipoExpedientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,tipo")] tipoExpediente tipoExpediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoExpediente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoExpediente);
        }

        // GET: tipoExpedientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoExpediente tipoExpediente = await db.tipoExpediente.FindAsync(id);
            if (tipoExpediente == null)
            {
                return HttpNotFound();
            }
            return View(tipoExpediente);
        }

        // POST: tipoExpedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tipoExpediente tipoExpediente = await db.tipoExpediente.FindAsync(id);
            db.tipoExpediente.Remove(tipoExpediente);
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
