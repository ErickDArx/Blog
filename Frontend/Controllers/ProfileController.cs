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
            User user = new User { };

            using (UnitOfWork<Favorite> unit = new UnitOfWork<Favorite>(new BDContext()))
            {
                user.Favorites = unit.genericDAL.GetAll().ToList();
            }

            using (UnitOfWork<Comment> unit = new UnitOfWork<Comment>(new BDContext()))
            {
                user.Comments = unit.genericDAL.GetAll().ToList();
            }

            return View(user);
        }
    }
}