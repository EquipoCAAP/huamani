﻿using sb_admin.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sb_admin.web.Domain
{
    public class Data
    {
        public IEnumerable<Navbar> navbarItems()
        {
            var menu = new List<Navbar>();
          
            menu.Add(new Navbar { id = 1, nameOption = "Inicio", controller = "Home", action = "Index", imageClass = "fa fa-fw fa-dashboard", estatus = true, activeli = true, parentId = null });
            menu.Add(new Navbar { id = 2, nameOption = "Casos", controller = "casos", action = "Index", imageClass = "fa fa-fw fa-bar-chart-o", estatus = true, activeli = true, parentId = null });
             menu.Add(new Navbar { id = 3, nameOption = "Expedientes", controller = "expedientes", action = "Index", imageClass = "fa fa-fw fa-bar-chart-o",estatus = true, activeli=true, parentId = null });
            menu.Add(new Navbar { id = 4, nameOption = "Documentos", controller = "documentos", action = "Index", imageClass = "fa fa-fw fa-edit",estatus = true, activeli=true, parentId = null });
             menu.Add(new Navbar { id = 5, nameOption = "Eventos", controller = "Home", action = "Charts", imageClass = "fa fa-fw fa-bar-chart-o",estatus = true, activeli=true, parentId = null });
              menu.Add(new Navbar { id = 6, nameOption = "Tareas", controller = "Home", action = "Forms", imageClass = "fa fa-fw fa-edit",estatus = true, activeli=true, parentId = null });
            menu.Add(new Navbar { id = 7, nameOption = "Clientes", controller = "Home", action = "BlankPage", imageClass = "fa fa-fw fa-file",estatus = true, activeli=true, parentId = null });
            menu.Add(new Navbar { id = 8, nameOption = "Servicios", controller = "servicios", action = "Index", imageClass = "fa fa-fw fa-dashboard",estatus = true, activeli=true, parentId = null });
            menu.Add(new Navbar { id = 9, nameOption = "Juzgado", controller = "juzgados", action = "Index", imageClass = "fa fa-fw fa-bar-chart-o",estatus = true, activeli=true, parentId = null });
            menu.Add(new Navbar { id = 10, nameOption = "Mantenimiento", controller = "", action = "", imageClass = "fa fa-fw fa-bar-chart-o",estatus = true, activeli=true, parentId = null });

            menu.Add(new Navbar { id = 11, nameOption = "Mantenimiento Ubicaciones", controller = "Home", action = "Tables", imageClass = "fa fa-fw fa-table",estatus = true, activeli=true, parentId = 9 });
            menu.Add(new Navbar { id = 12, nameOption = "Mantenimiento Tipo de Evento", controller = "tipo_evento", action = "Index", imageClass = "fa fa-fw fa-edit",estatus = true, activeli=true, parentId = 9 });
            menu.Add(new Navbar { id = 13, nameOption = "Mantenimiento Tipo Juzgado", controller = "tipo_juzgado", action = "Index", imageClass = "fa fa-fw fa-desktop",estatus = true, activeli=true, parentId = 9 });
            menu.Add(new Navbar { id = 14, nameOption = "Mantenimiento Tipo Persona", controller = "tipo_persona", action = "Index", imageClass = "fa fa-fw fa-person",estatus = true, activeli=true, parentId = 9 });
            menu.Add(new Navbar { id = 15, nameOption = "Mantenimiento Tipo Avances", controller = "avances", action = "Index", imageClass = "fa fa-fw fa-person", estatus = true, activeli = true, parentId = 9 });
            menu.Add(new Navbar { id = 16, nameOption = "Mantenimiento Menu", controller = "Home", action = "BlankPage", imageClass = "fa fa-fw fa-file",estatus = true, activeli=true, parentId = null });
            menu.Add(new Navbar { id = 17, nameOption = "Seguridad Roles", controller = "Home", action = "Index", imageClass = "fa fa-fw fa-dashboard",estatus = true, activeli=true, parentId = null });
            menu.Add(new Navbar { id = 18, nameOption = "Seguridad Menu Roles", controller = "Home", action = "Charts", imageClass = "fa fa-fw fa-bar-chart-o",estatus = true, activeli=true, parentId = null });
            menu.Add(new Navbar { id = 19, nameOption = "Seguridad Personas", controller = "personas", action = "Index", imageClass = "fa fa-fw fa-table",estatus = true, activeli=true, parentId = null });

            //nu.Add(new Navbar { id = 18, nameOption = "Dashboard", controller = "Home", action = "Index", imageClass = "fa fa-fw fa-dashboard",estatus = true, activeli=true });
            //menu.Add(new Navbar { id = 19, nameOption = "Charts", controller = "Home", action = "Charts", imageClass = "fa fa-fw fa-bar-chart-o",estatus = true, activeli=true });
            //menu.Add(new Navbar { id = 20, nameOption = "Tables", controller = "Home", action = "Tables", imageClass = "fa fa-fw fa-table",estatus = true, activeli=true });
            //menu.Add(new Navbar { id = 21, nameOption = "Forms", controller = "Home", action = "Forms", imageClass = "fa fa-fw fa-edit",estatus = true, activeli=true });
            //menu.Add(new Navbar { id = 22, nameOption = "Bootstrap Elements", controller = "Home", action = "BootstrapElements", imageClass = "fa fa-fw fa-desktop",estatus = true, activeli=true });
            //menu.Add(new Navbar { id = 23, nameOption = "Bootstrap Grid", controller = "Home", action = "BootstrapGrid", imageClass = "fa fa-fw fa-wrench",estatus = true, activeli=true });
            //menu.Add(new Navbar { id = 24, nameOption = "Blank Page", controller = "Home", action = "BlankPage", imageClass = "fa fa-fw fa-file",estatus = true, activeli=true });
            return menu.ToList();
        }

        public IEnumerable<User> Users()
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, user1 = "admin", Password = "12345", status = true, RememberMe = false });
            users.Add(new User { Id = 2, user1 = "abogado", Password = "12345", status = true, RememberMe = false });
            users.Add(new User { Id = 3, user1 = "practicante", Password = "12345", status = true, RememberMe = false });
            users.Add(new User { Id = 4, user1 = "persona", Password = "1", status = true, RememberMe = false });
            return users.ToList();
        }

        public IEnumerable<Roles> Roles()
        {
            var roles = new List<Roles>();
            roles.Add(new Roles { id = 1, userId = 1, MenuId = 1, status = true });
            roles.Add(new Roles { id = 2, userId = 1, MenuId = 2, status = true });
            roles.Add(new Roles { id = 3, userId = 1, MenuId = 3, status = true });
            roles.Add(new Roles { id = 4, userId = 1, MenuId = 4, status = true });
            roles.Add(new Roles { id = 5, userId = 1, MenuId = 5, status = true });
            roles.Add(new Roles { id = 6, userId = 1, MenuId = 6, status = true });
            roles.Add(new Roles { id = 7, userId = 1, MenuId = 7, status = true });
            roles.Add(new Roles { id = 8, userId = 1, MenuId = 8, status = true });
            roles.Add(new Roles { id = 9, userId = 1, MenuId = 9, status = true });
            roles.Add(new Roles { id = 10, userId = 1, MenuId =10, status = true });
            roles.Add(new Roles { id = 11, userId = 1, MenuId = 11, status = true });
            roles.Add(new Roles { id = 12, userId = 1, MenuId = 12, status = true });
            roles.Add(new Roles { id = 13, userId = 1, MenuId = 13, status = true });
            roles.Add(new Roles { id = 14, userId = 1, MenuId = 14, status = true });
            roles.Add(new Roles { id = 15, userId = 1, MenuId = 15, status = true });
            roles.Add(new Roles { id = 16, userId = 1, MenuId = 16, status = true });
            roles.Add(new Roles { id = 17, userId = 1, MenuId = 17, status = true });
            roles.Add(new Roles { id = 18, userId = 1, MenuId = 18, status = true });
            roles.Add(new Roles { id = 19, userId = 1, MenuId = 19, status = true });
            roles.Add(new Roles { id = 20, userId = 1, MenuId = 20, status = true });
            roles.Add(new Roles { id = 21, userId = 1, MenuId = 21, status = true });
            roles.Add(new Roles { id = 22, userId = 2, MenuId = 1, status = true });
            roles.Add(new Roles { id = 23, userId = 2, MenuId = 2, status = true });
            roles.Add(new Roles { id = 24, userId = 2, MenuId = 3, status = true });
            roles.Add(new Roles { id = 25, userId = 2, MenuId = 4, status = true });
            roles.Add(new Roles { id = 26, userId = 2, MenuId = 5, status = true });
            roles.Add(new Roles { id = 27, userId = 2, MenuId = 6, status = true });
            roles.Add(new Roles { id = 28, userId = 2, MenuId = 7, status = true });
            roles.Add(new Roles { id = 29, userId = 2, MenuId = 8, status = true });
            roles.Add(new Roles { id = 30, userId = 2, MenuId = 9, status = true });
            roles.Add(new Roles { id = 31, userId = 2, MenuId = 10, status = true });
            roles.Add(new Roles { id = 32, userId = 3, MenuId = 1, status = true });
            roles.Add(new Roles { id = 32, userId = 3, MenuId = 3, status = true });
            roles.Add(new Roles { id = 33, userId = 3, MenuId = 7, status = true });
            roles.Add(new Roles { id = 34, userId = 3, MenuId = 12, status = true });

            return roles.ToList();
        }

        public IEnumerable<Navbar> ItemsPerUser(string controller, string action, string userName)
        {
            
            IEnumerable<Navbar> items = navbarItems();
            IEnumerable<Roles> rolesNav = Roles();
            IEnumerable<User> usersNav = Users();

            var navbar =  items.Where(p => p.controller == controller && p.action == action).Select(c => { c.activeli = true; return c; }).ToList();

            navbar = (from nav in items
                      join rol in rolesNav on nav.id equals rol.MenuId
                      join user in usersNav on rol.userId equals user.Id
                      where user.user1 == userName & user.status == true
                      

                      select new Navbar
                      {
                          id = nav.id,
                          nameOption = nav.nameOption,
                          controller = nav.controller,
                          action = nav.action,
                          imageClass = nav.imageClass,
                          estatus = nav.estatus,
                          activeli = nav.activeli,
                          parentId = nav.parentId
                      }).ToList();

            return navbar.ToList();
        }

    }
}