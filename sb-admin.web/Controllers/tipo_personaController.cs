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
    public class tipo_personaController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: tipo_persona
        public async Task<ActionResult> Index()
        {
            return View(await db.tipo_persona.ToListAsync());
        }

        // GET: tipo_persona/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_persona tipo_persona = await db.tipo_persona.FindAsync(id);
            if (tipo_persona == null)
            {
                return HttpNotFound();
            }
            return View(tipo_persona);
        }

        // GET: tipo_persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipo_persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,tipo_persona1")] tipo_persona tipo_persona)
        {
            if (ModelState.IsValid)
            {
                db.tipo_persona.Add(tipo_persona);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipo_persona);
        }

        // GET: tipo_persona/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_persona tipo_persona = await db.tipo_persona.FindAsync(id);
            if (tipo_persona == null)
            {
                return HttpNotFound();
            }
            return View(tipo_persona);
        }

        // POST: tipo_persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,tipo_persona1")] tipo_persona tipo_persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_persona).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipo_persona);
        }

        // GET: tipo_persona/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_persona tipo_persona = await db.tipo_persona.FindAsync(id);
            if (tipo_persona == null)
            {
                return HttpNotFound();
            }
            return View(tipo_persona);
        }

        // POST: tipo_persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tipo_persona tipo_persona = await db.tipo_persona.FindAsync(id);
            db.tipo_persona.Remove(tipo_persona);
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
