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
    public class eventosController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: eventos
        public async Task<ActionResult> Index()
        {
            var evento = db.evento.Include(e => e.expediente).Include(e => e.servicio).Include(e => e.tipo_evento1);
            return View(await evento.ToListAsync());
        }

        // GET: eventos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = await db.evento.FindAsync(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: eventos/Create
        public ActionResult Create()
        {
            ViewBag.expedienteId = new SelectList(db.expediente, "id", "titulo");
            ViewBag.servicioId = new SelectList(db.servicio, "id", "descripcion");
            ViewBag.tipo_evento = new SelectList(db.tipo_evento, "id", "tipo_evento1");
            return View();
        }

        // POST: eventos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,tipo_evento,descripcion_evento,fecha_inicio,servicioId,expedienteId")] evento evento)
        {
            if (ModelState.IsValid)
            {
                db.evento.Add(evento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.expedienteId = new SelectList(db.expediente, "id", "titulo", evento.expedienteId);
            ViewBag.servicioId = new SelectList(db.servicio, "id", "descripcion", evento.servicioId);
            ViewBag.tipo_evento = new SelectList(db.tipo_evento, "id", "tipo_evento1", evento.tipo_evento);
            return View(evento);
        }

        // GET: eventos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = await db.evento.FindAsync(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.expedienteId = new SelectList(db.expediente, "id", "titulo", evento.expedienteId);
            ViewBag.servicioId = new SelectList(db.servicio, "id", "descripcion", evento.servicioId);
            ViewBag.tipo_evento = new SelectList(db.tipo_evento, "id", "tipo_evento1", evento.tipo_evento);
            return View(evento);
        }

        // POST: eventos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,tipo_evento,descripcion_evento,fecha_inicio,servicioId,expedienteId")] evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.expedienteId = new SelectList(db.expediente, "id", "titulo", evento.expedienteId);
            ViewBag.servicioId = new SelectList(db.servicio, "id", "descripcion", evento.servicioId);
            ViewBag.tipo_evento = new SelectList(db.tipo_evento, "id", "tipo_evento1", evento.tipo_evento);
            return View(evento);
        }

        // GET: eventos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evento evento = await db.evento.FindAsync(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            evento evento = await db.evento.FindAsync(id);
            db.evento.Remove(evento);
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
