using sb_admin.web.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace sb_admin.web.Controllers
{
    public class casos1Controller : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: casos1
        public async Task<ActionResult> Index()
        {
            var caso = db.caso.Include(c => c.avance);
            return View(await caso.ToListAsync());
        }

        // GET: casos1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            caso caso = await db.caso.FindAsync(id);
            if (caso == null)
            {
                return HttpNotFound();
            }
            return View(caso);
        }

        // GET: casos1/Create
        public ActionResult Create()
        {
            ViewBag.avanceId = new SelectList(db.avance, "id", "tipo_avance");
            return View();
        }

        // POST: casos1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,referencia,fecha_creacion,responsableId,avanceId,aperturaPersonaId")] caso caso)
        {
            if (ModelState.IsValid)
            {
                db.caso.Add(caso);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.avanceId = new SelectList(db.avance, "id", "tipo_avance", caso.avanceId);
            return View(caso);
        }

        // GET: casos1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            caso caso = await db.caso.FindAsync(id);
            if (caso == null)
            {
                return HttpNotFound();
            }
            ViewBag.avanceId = new SelectList(db.avance, "id", "tipo_avance", caso.avanceId);
            return View(caso);
        }

        // POST: casos1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,referencia,fecha_creacion,responsableId,avanceId,aperturaPersonaId")] caso caso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caso).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.avanceId = new SelectList(db.avance, "id", "tipo_avance", caso.avanceId);
            return View(caso);
        }

        // GET: casos1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            caso caso = await db.caso.FindAsync(id);
            if (caso == null)
            {
                return HttpNotFound();
            }
            return View(caso);
        }

        // POST: casos1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            caso caso = await db.caso.FindAsync(id);
            db.caso.Remove(caso);
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
