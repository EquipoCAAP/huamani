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
    public class clientesController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: telefonos/Create
        public async Task<ActionResult> CreateTelefono(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = await db.persona.FindAsync(id);
            if (persona == null)
            {
                return HttpNotFound();
            }

            var telefono_personaId = new telefono_persona { personaId = persona.id };

            return View(telefono_personaId);
        }

        // POST: telefonos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTelefono( telefono telefono,int id)
        {
            if (ModelState.IsValid)
            {
                db.telefono.Add(telefono);
                var telefono_Persona = new telefono_persona { personaId = id, telefonosId = telefono.id };

                db.telefono_persona.Add(telefono_Persona);
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}",telefono_Persona.personaId));
            }

            return View();
        }

        // GET: telefonos/Edit/5
        public async Task<ActionResult> EditTelefono(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var telefono_persona = await db.telefono_persona.FirstOrDefaultAsync(tp=>tp.telefonosId==id);
            if (telefono_persona == null)
            {
                return HttpNotFound();
            }
            return View(telefono_persona);
        }

        public async Task<ActionResult> DeleteTelefono(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var telefono_persona = await db.telefono_persona.FirstOrDefaultAsync(tp => tp.telefonosId == id);
            var telefono = await db.telefono.FirstOrDefaultAsync(t => t.id == id);
            if (telefono_persona == null)
            {
                return HttpNotFound();
            }
            db.telefono.Remove(telefono);
            db.telefono_persona.Remove(telefono_persona);
            
            await db.SaveChangesAsync();
            return RedirectToAction(string.Format("Details/{0}", telefono_persona.personaId));
        }


        // POST: telefonos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTelefono( telefono telefono,telefono_persona telefono_Persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction(string.Format("Details/{0}",telefono_Persona.personaId));
            }
            return View(telefono_Persona);
        }




        // GET: clientes
        public async Task<ActionResult> Index()
        {
            var persona = db.persona.Include(p => p.tipo_persona).Include(p => p.User).Where(p => p.tipo == 2);
            return View(await persona.ToListAsync());
        }

        // GET: clientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = await db.persona.FindAsync(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: clientes/Create
        public ActionResult Create()
        {
            ViewBag.tipo = new SelectList(db.tipo_persona.Where(P => P.id == 2), "id", "tipo_persona1");
            ViewBag.usuarioId = new SelectList(db.User.Where(P => P.Id == 2), "Id", "user1");
            return View();
        }

        // POST: clientes/Create
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,dni,nombre,apellido,celular,tipo,usuarioId")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.persona.Add(persona);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.tipo = new SelectList(db.tipo_persona.Where(P => P.id == 2), "id", "tipo_persona1", persona.tipo);
            ViewBag.usuarioId = new SelectList(db.User.Where(P => P.Id == 2), "Id", "user1", persona.usuarioId);
            return View(persona);
        }

        // GET: clientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = await db.persona.FindAsync(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipo = new SelectList(db.tipo_persona.Where(P => P.id == 2), "id", "tipo_persona1", persona.tipo);
            ViewBag.usuarioId = new SelectList(db.User.Where(P => P.Id == 2), "Id", "user1", persona.usuarioId);
            return View(persona);
        }

        // POST: clientes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,dni,nombre,apellido,celular,tipo,usuarioId")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.tipo = new SelectList(db.tipo_persona.Where(P => P.id == 2), "id", "tipo_persona1", persona.tipo);
            ViewBag.usuarioId = new SelectList(db.User.Where(P => P.Id == 2), "Id", "user1", persona.usuarioId);
            return View(persona);
        }

        // GET: clientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = await db.persona.FindAsync(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            persona persona = await db.persona.FindAsync(id);
            db.persona.Remove(persona);
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
