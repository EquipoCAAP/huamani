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
    public class NavbarsController : Controller
    {
        private GAHEContext db = new GAHEContext();

        // GET: Navbars
        public async Task<ActionResult> Index()
        {
            var parent = db.Navbar.Include(p => p.nameOption);
            return View(await db.Navbar.ToListAsync());
        }

        // GET: Navbars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navbar navbar = await db.Navbar.FindAsync(id);
            if (navbar == null)
            {
                return HttpNotFound();
            }
            return View(navbar);
        }

        // GET: Navbars/Create
        public ActionResult Create()
        {
            LlenarparienteDropDownList();
            return View();
        }

        // POST: Navbars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nameOption,controller,action,area,imageClass,estatus,activeli,parentId")] Navbar navbar)
        {
            if (ModelState.IsValid)
            {
                db.Navbar.Add(navbar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(navbar);
        }

        // GET: Navbars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navbar navbar = await db.Navbar.FindAsync(id);
            if (navbar == null)
            {
                return HttpNotFound();
            }
            LlenarparienteDropDownList(navbar);
            return View(navbar);
        }

        // POST: Navbars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nameOption,controller,action,area,imageClass,estatus,activeli,parentId")] Navbar navbar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(navbar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            LlenarparienteDropDownList(navbar.parentId);
            return View(navbar);
        }

        // GET: Navbars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navbar navbar = await db.Navbar.FindAsync(id);
            if (navbar == null)
            {
                return HttpNotFound();
            }
            return View(navbar);
        }

        // POST: Navbars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Navbar navbar = await db.Navbar.FindAsync(id);
            db.Navbar.Remove(navbar);
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
        private void LlenarparienteDropDownList(object selectedParent = null)
        {
            var parentQuery = from p in db.Navbar
                            orderby p.nameOption
                            select p;
            

            List<SelectListItem> items = new SelectList(
                                      parentQuery,
                                      "id", "nameOption"
                                       ).ToList();

            items.Insert(0, (new SelectListItem
            {
           Text = "Padre",
                Value = "",
                Selected = true
            }));

           

            ViewBag.parentId = items;
        }
    }
    }
