using Backend.Entities;
using Backend.DAL;
using Frontend.Models;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace Frontend.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(UserViewModel userViewModel)
        {
            User user;
            using (UnitOfWork<User> unit = new UnitOfWork<User>(new BDContext()))
            {
                Expression<Func<User, bool>> query =
                    u => u.Email.Equals(userViewModel.Email) && u.UserPassword.Equals(userViewModel.UserPassword);
                user = unit.genericDAL.Find(query).ToList().FirstOrDefault();
            }

            if (user == null)
            {
                ModelState.AddModelError("loginError", "Correo o contraseña incorrectos");
                return View("Index", userViewModel);
            }
            else
            {
                Session["userId"] = user.ID;
                Session["Email"] = user.Email;
                Session["Name"] = user.FirtName;
                Session["LastName"] = user.LastName;

                var authTicket = new FormsAuthenticationTicket(user.Email, true, 100000);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));

                Response.Cookies.Add(cookie);
                var name = User.Identity.Name;
                return RedirectToAction("Index", "Profile");
            }
        }

        public ActionResult Logout()
        {
            int userId = (int)Session["userId"];
            Session.Clear();
            Session.Abandon();

            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            return RedirectToAction("Index", "Login");
        }
    }
}