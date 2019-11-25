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
    public class telefono_personaController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: telefono_persona
        public async Task<ActionResult> Index()
        {
            var telefono_persona = db.telefono_persona.Include(t => t.persona).Include(t => t.telefono);
            return View(await telefono_persona.ToListAsync());
        }

        // GET: telefono_persona/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono_persona telefono_persona = await db.telefono_persona.FindAsync(id);
            if (telefono_persona == null)
            {
                return HttpNotFound();
            }
            return View(telefono_persona);
        }

        // GET: telefono_persona/Create
        public ActionResult Create()
        {
            ViewBag.personaId = new SelectList(db.persona, "id", "dni");
            ViewBag.telefonosId = new SelectList(db.telefono, "id", "telefono1");
            return View();
        }

        // POST: telefono_persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,personaId,telefonosId")] telefono_persona telefono_persona)
        {
            if (ModelState.IsValid)
            {
                db.telefono_persona.Add(telefono_persona);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.personaId = new SelectList(db.persona, "id", "dni", telefono_persona.personaId);
            ViewBag.telefonosId = new SelectList(db.telefono, "id", "telefono1", telefono_persona.telefonosId);
            return View(telefono_persona);
        }

        // GET: telefono_persona/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono_persona telefono_persona = await db.telefono_persona.FindAsync(id);
            if (telefono_persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.personaId = new SelectList(db.persona, "id", "dni", telefono_persona.personaId);
            ViewBag.telefonosId = new SelectList(db.telefono, "id", "telefono1", telefono_persona.telefonosId);
            return View(telefono_persona);
        }

        // POST: telefono_persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,personaId,telefonosId")] telefono_persona telefono_persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono_persona).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.personaId = new SelectList(db.persona, "id", "dni", telefono_persona.personaId);
            ViewBag.telefonosId = new SelectList(db.telefono, "id", "telefono1", telefono_persona.telefonosId);
            return View(telefono_persona);
        }

        // GET: telefono_persona/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefono_persona telefono_persona = await db.telefono_persona.FindAsync(id);
            if (telefono_persona == null)
            {
                return HttpNotFound();
            }
            return View(telefono_persona);
        }

        // POST: telefono_persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            telefono_persona telefono_persona = await db.telefono_persona.FindAsync(id);
            db.telefono_persona.Remove(telefono_persona);
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
