using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Backend.Entities;
using Backend.DAL;

namespace Frontend.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            List<Favorite> favorites;
            using (UnitOfWork<Favorite> unit = new UnitOfWork<Favorite>(new BDContext()))
            {
                favorites = unit.genericDAL.GetAll().ToList();
            }

            List<Comment> comments;
            using (UnitOfWork<Comment> unit = new UnitOfWork<Comment>(new BDContext()))
            {
                comments = unit.genericDAL.GetAll().ToList();
            }

            return View();
        }
    }
}