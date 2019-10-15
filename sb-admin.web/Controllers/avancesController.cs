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
    public class avancesController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: avances
        public async Task<ActionResult> Index()
        {
            return View(await db.avance.ToListAsync());
        }

        // GET: avances/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            avance avance = await db.avance.FindAsync(id);
            if (avance == null)
            {
                return HttpNotFound();
            }
            return View(avance);
        }

        // GET: avances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: avances/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,tipo_avance")] avance avance)
        {
            if (ModelState.IsValid)
            {
                db.avance.Add(avance);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(avance);
        }

        // GET: avances/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            avance avance = await db.avance.FindAsync(id);
            if (avance == null)
            {
                return HttpNotFound();
            }
            return View(avance);
        }

        // POST: avances/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,tipo_avance")] avance avance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avance).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(avance);
        }

        // GET: avances/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            avance avance = await db.avance.FindAsync(id);
            if (avance == null)
            {
                return HttpNotFound();
            }
            return View(avance);
        }

        // POST: avances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            avance avance = await db.avance.FindAsync(id);
            db.avance.Remove(avance);
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
