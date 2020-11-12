using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            //Obtener publicaciones favoritas
            //Obtener mis comentarios
            return View();
        }
    }
}