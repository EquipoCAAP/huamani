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
    public class RolesController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: Roles
        public async Task<ActionResult> Index()
        {
            var roles = db.Roles.Include(r => r.User).Include(r => r.Navbar);
            return View(await roles.ToListAsync());
        }

        // GET: Roles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roles roles = await db.Roles.FindAsync(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.User, "Id", "user1");
            ViewBag.MenuId = new SelectList(db.Navbar, "id", "nameOption");
            return View();
        }

        // POST: Roles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,userId,MenuId,status")] Roles roles)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(roles);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.User, "Id", "user1", roles.userId);
            ViewBag.MenuId = new SelectList(db.Navbar, "id", "nameOption", roles.MenuId);
            return View(roles);
        }

        // GET: Roles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roles roles = await db.Roles.FindAsync(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.User, "Id", "user1", roles.userId);
            ViewBag.MenuId = new SelectList(db.Navbar, "id", "nameOption", roles.MenuId);
            return View(roles);
        }

        // POST: Roles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,userId,MenuId,status")] Roles roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roles).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.User, "Id", "user1", roles.userId);
            ViewBag.MenuId = new SelectList(db.Navbar, "id", "nameOption", roles.MenuId);
            return View(roles);
        }

        // GET: Roles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roles roles = await db.Roles.FindAsync(id);
            if (roles == null)
            {
                return HttpNotFound();
            }
            return View(roles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Roles roles = await db.Roles.FindAsync(id);
            db.Roles.Remove(roles);
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
