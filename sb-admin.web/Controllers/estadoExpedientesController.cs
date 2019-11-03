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
    public class estadoExpedientesController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: estadoExpedientes
        public async Task<ActionResult> Index()
        {
            return View(await db.estadoExpediente.ToListAsync());
        }

        // GET: estadoExpedientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadoExpediente estadoExpediente = await db.estadoExpediente.FindAsync(id);
            if (estadoExpediente == null)
            {
                return HttpNotFound();
            }
            return View(estadoExpediente);
        }

        // GET: estadoExpedientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estadoExpedientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,estado")] estadoExpediente estadoExpediente)
        {
            if (ModelState.IsValid)
            {
                db.estadoExpediente.Add(estadoExpediente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(estadoExpediente);
        }

        // GET: estadoExpedientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadoExpediente estadoExpediente = await db.estadoExpediente.FindAsync(id);
            if (estadoExpediente == null)
            {
                return HttpNotFound();
            }
            return View(estadoExpediente);
        }

        // POST: estadoExpedientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,estado")] estadoExpediente estadoExpediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoExpediente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(estadoExpediente);
        }

        // GET: estadoExpedientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadoExpediente estadoExpediente = await db.estadoExpediente.FindAsync(id);
            if (estadoExpediente == null)
            {
                return HttpNotFound();
            }
            return View(estadoExpediente);
        }

        // POST: estadoExpedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            estadoExpediente estadoExpediente = await db.estadoExpediente.FindAsync(id);
            db.estadoExpediente.Remove(estadoExpediente);
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
