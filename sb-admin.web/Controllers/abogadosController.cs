using sb_admin.web.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace sb_admin.web.Controllers
{
    public class abogadosController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: abogados
        public async Task<ActionResult> Index()
        {
            var persona = db.persona.Include(p => p.tipo_persona).Include(p => p.User).Where(p=>p.tipo==1);
            return View(await persona.ToListAsync());
        }

        // GET: abogados/Details/5
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

        // GET: abogados/Create
        public ActionResult Create()
        {
            
            ViewBag.tipo = new SelectList(db.tipo_persona.Where(P=>P.id==1), "id", "tipo_persona1");
            ViewBag.usuarioId = new SelectList(db.User.Where(u=>u.Id==1), "Id", "user1");
            return View();
        }

        // POST: abogados/Create
      
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

            ViewBag.tipo = new SelectList(db.tipo_persona.Where(P => P.id == 1), "id", "tipo_persona1", persona.tipo);
            ViewBag.usuarioId = new SelectList(db.User.Where(u => u.Id == 1), "Id", "user1", persona.usuarioId);
            return View(persona);
        }

        // GET: abogados/Edit/5
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
            ViewBag.tipo = new SelectList(db.tipo_persona.Where(P => P.id == 1), "id", "tipo_persona1", persona.tipo);
            ViewBag.usuarioId = new SelectList(db.User.Where(u => u.Id == 1), "Id", "user1", persona.usuarioId);
            return View(persona);
        }

        // POST: abogados/Edit/5
     
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
            ViewBag.tipo = new SelectList(db.tipo_persona, "id", "tipo_persona1", persona.tipo);
            ViewBag.usuarioId = new SelectList(db.User, "Id", "user1", persona.usuarioId);
            return View(persona);
        }

        // GET: abogados/Delete/5
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

        // POST: abogados/Delete/5
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
