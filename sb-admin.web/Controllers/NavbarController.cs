﻿using sb_admin.web.Domain;
using sb_admin.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sb_admin.web.Controllers
{
    public class NavbarController : Controller
    {
        // GET: Navbar
        public ActionResult Navbar(string controller, string action)
        {
            var data = new Data();

            var navbar = data.ItemsPerUser(controller, action, User.Identity.Name).Where(x =>x.parentId==null);

            return PartialView("_navbar", navbar);
        }
    }
}