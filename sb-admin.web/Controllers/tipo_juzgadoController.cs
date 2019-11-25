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
    public class tipo_juzgadoController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: tipo_juzgado
        public async Task<ActionResult> Index()
        {
            return View(await db.tipo_juzgado.ToListAsync());
        }

        // GET: tipo_juzgado/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_juzgado tipo_juzgado = await db.tipo_juzgado.FindAsync(id);
            if (tipo_juzgado == null)
            {
                return HttpNotFound();
            }
            return View(tipo_juzgado);
        }

        // GET: tipo_juzgado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_juzgado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,tipo_j")] tipo_juzgado tipo_juzgado)
        {
            if (ModelState.IsValid)
            {
                db.tipo_juzgado.Add(tipo_juzgado);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipo_juzgado);
        }

        // GET: tipo_juzgado/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_juzgado tipo_juzgado = await db.tipo_juzgado.FindAsync(id);
            if (tipo_juzgado == null)
            {
                return HttpNotFound();
            }
            return View(tipo_juzgado);
        }

        // POST: tipo_juzgado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,tipo_j")] tipo_juzgado tipo_juzgado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_juzgado).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipo_juzgado);
        }

        // GET: tipo_juzgado/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_juzgado tipo_juzgado = await db.tipo_juzgado.FindAsync(id);
            if (tipo_juzgado == null)
            {
                return HttpNotFound();
            }
            return View(tipo_juzgado);
        }

        // POST: tipo_juzgado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tipo_juzgado tipo_juzgado = await db.tipo_juzgado.FindAsync(id);
            db.tipo_juzgado.Remove(tipo_juzgado);
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
