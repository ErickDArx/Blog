using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Backend.Entities;
using Backend.DAL;
using Frontend.Models;

namespace Frontend.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            UserViewModel users = new UserViewModel { };

            using (UnitOfWork<Favorite> unit = new UnitOfWork<Favorite>(new BDContext()))
            {
                users.Favorites = unit.genericDAL.GetAll().ToList();
            }

            using (UnitOfWork<Comment> unit = new UnitOfWork<Comment>(new BDContext()))
            {
                users.Comments = unit.genericDAL.GetAll().ToList();
            }

            return View(users);
        }
    }
}