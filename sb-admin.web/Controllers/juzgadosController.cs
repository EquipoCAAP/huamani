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
using System.Data.Entity.Infrastructure;

namespace sb_admin.web.Controllers
{
    public class juzgadosController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: juzgados
        public async Task<ActionResult> Index()
        {
            var juzgado = db.juzgado.Include(j => j.tipo_juzgado);
            return View(await juzgado.ToListAsync());
        }

        // GET: juzgados/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            juzgado juzgado = await db.juzgado.FindAsync(id);
            if (juzgado == null)
            {
                return HttpNotFound();
            }
            return View(juzgado);
        }

        // GET: juzgados/Create
        public ActionResult Create()
        {
            LlenarTipoJuzgadoDropDownList();
            return View();
        }

        // POST: juzgados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nombre,lugar,piso,ciudad,nombre_juez,apellido_juez,descripcion,tipoId")] juzgado juzgado)
        {

            try {
            if (ModelState.IsValid)
            {
                db.juzgado.Add(juzgado);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "No se pudo grabar los cambios. Trate de nuevo, y si persiste el problema comunicarse con el administrador.");

            }

            LlenarTipoJuzgadoDropDownList(juzgado.tipoId);
            return View(juzgado);
        }

        // GET: juzgados/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            juzgado juzgado = await db.juzgado.FindAsync(id);
            if (juzgado == null)
            {
                return HttpNotFound();
            }
            LlenarTipoJuzgadoDropDownList(juzgado.tipoId);
            return View(juzgado);
        }

        // POST: juzgados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre,lugar,piso,ciudad,nombre_juez,apellido_juez,descripcion,tipoId")] juzgado juzgado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juzgado).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
           LlenarTipoJuzgadoDropDownList(juzgado.tipoId);
            return View(juzgado);
        }

        // GET: juzgados/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            juzgado juzgado = await db.juzgado.FindAsync(id);
            if (juzgado == null)
            {
                return HttpNotFound();
            }
            return View(juzgado);
        }

        // POST: juzgados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            juzgado juzgado = await db.juzgado.FindAsync(id);
            db.juzgado.Remove(juzgado);
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

        private void LlenarTipoJuzgadoDropDownList (object selectedTipo = null)
        {
            var tipoQuery = from tj in db.tipo_juzgado
                            orderby tj.tipo_j
                            select tj;
            ViewBag.tipoId = new SelectList(tipoQuery, "id", "tipo_j");
        }

    }
}
