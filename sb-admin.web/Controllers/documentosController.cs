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
    public class documentosController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: documentos
        public async Task<ActionResult> Index()
        {
            var documento = db.documento.Include(d => d.expediente);
            return View(await documento.ToListAsync());
        }

        // GET: documentos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documento documento = await db.documento.FindAsync(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // GET: documentos/Create
        public ActionResult Create()
        {
            ViewBag.expedienteIid = new SelectList(db.expediente, "id", "titulo");
            return View();
        }

        // POST: documentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,descripcion,fechacreacion,mime,nombre,extension,tamano,creado,expedienteIid")] documento documento)
        {
            if (ModelState.IsValid)
            {
                db.documento.Add(documento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.expedienteIid = new SelectList(db.expediente, "id", "titulo", documento.expedienteIid);
            return View(documento);
        }

        // GET: documentos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documento documento = await db.documento.FindAsync(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            ViewBag.expedienteIid = new SelectList(db.expediente, "id", "titulo", documento.expedienteIid);
            return View(documento);
        }

        // POST: documentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,descripcion,fechacreacion,mime,nombre,extension,tamano,creado,expedienteIid")] documento documento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.expedienteIid = new SelectList(db.expediente, "id", "titulo", documento.expedienteIid);
            return View(documento);
        }

        // GET: documentos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            documento documento = await db.documento.FindAsync(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // POST: documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            documento documento = await db.documento.FindAsync(id);
            db.documento.Remove(documento);
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
