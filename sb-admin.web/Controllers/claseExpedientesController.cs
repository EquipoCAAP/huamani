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
    public class claseExpedientesController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: claseExpedientes
        public async Task<ActionResult> Index()
        {
            return View(await db.claseExpediente.ToListAsync());
        }

        // GET: claseExpedientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            claseExpediente claseExpediente = await db.claseExpediente.FindAsync(id);
            if (claseExpediente == null)
            {
                return HttpNotFound();
            }
            return View(claseExpediente);
        }

        // GET: claseExpedientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: claseExpedientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Clase")] claseExpediente claseExpediente)
        {
            if (ModelState.IsValid)
            {
                db.claseExpediente.Add(claseExpediente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(claseExpediente);
        }

        // GET: claseExpedientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            claseExpediente claseExpediente = await db.claseExpediente.FindAsync(id);
            if (claseExpediente == null)
            {
                return HttpNotFound();
            }
            return View(claseExpediente);
        }

        // POST: claseExpedientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Clase")] claseExpediente claseExpediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claseExpediente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(claseExpediente);
        }

        // GET: claseExpedientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            claseExpediente claseExpediente = await db.claseExpediente.FindAsync(id);
            if (claseExpediente == null)
            {
                return HttpNotFound();
            }
            return View(claseExpediente);
        }

        // POST: claseExpedientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            claseExpediente claseExpediente = await db.claseExpediente.FindAsync(id);
            db.claseExpediente.Remove(claseExpediente);
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
