//using sb_admin.web.Domain;
using sb_admin.web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sb_admin.web.Controllers
{
    public class NavbarController : Controller
    {
        private GAHEContext db = new GAHEContext();
        // GET: Navbar
        public ActionResult Navbar(string controller,string action)
        {
            IEnumerable<Navbar> items = db.Navbar;
            IEnumerable<Roles> rolesNav = db.Roles;
            IEnumerable<User> usersNav =db.User;
            
                       // var data = new Data();

            //  var navbar = data.ItemsPerUser(controller, action, User.Identity.Name).Where(x =>x.parentId==null);
            var navbar = items.Where(p => p.controller == controller && p.action == action).Select(c => { c.activeli = true; return c; }).ToList();
             navbar = (from nav in items
                       join rol in rolesNav on nav.id equals rol.MenuId
                       join user in usersNav on rol.userId equals user.Id
                      
                       where user.user1 == User.Identity.Name & user.status == true 
                       select nav).ToList();
           
            // navbar = navbar.Where(p => p.parentId == null).ToList();
            return PartialView("_navbar",  navbar);
               

              
            

            
        }
    }
}