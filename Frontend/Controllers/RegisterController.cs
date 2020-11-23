using Backend.DAL;
using Backend.Entities;
using Frontend.Models;
using System;
using System.IO;
using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class RegisterController : Controller
    {
        private User Convert(UserViewModel user)
        {
            return new User
            {
                ID = user.UserID,
                FirtName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserPassword = user.UserPassword,
                ProfileImage = user.ProfileImage,
                UserRol=user.UserRol=2,
            };
        }

        private UserViewModel Convert(User userViewModel)
        {
            return new UserViewModel
            {
                UserID = userViewModel.ID,
                FirstName = userViewModel.FirtName,
                LastName = userViewModel.LastName,
                Email = userViewModel.Email,
                UserPassword = userViewModel.UserPassword,
                ProfileImage = userViewModel.ProfileImage,
                UserRol = (int)userViewModel.UserRol,
            };
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
            /*string fileName = Path.GetFileName(userViewModel.ProfileImageFile.FileName);
            userViewModel.ProfileImage = "~/Media/Users/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Media/Images/"), fileName);
            userViewModel.ProfileImageFile.SaveAs(fileName);*/

            User user = this.Convert(userViewModel);
            using (UnitOfWork<User> unit = new UnitOfWork<User>(new BDContext()))
            {
                unit.genericDAL.Add(user);
                unit.Complete();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index","News");
            }

        }

        public ActionResult Edit(int id)
        {
            User user;
            using (UnitOfWork<User> unit = new UnitOfWork<User>(new BDContext()))
            {
                user = unit.genericDAL.Get(id);
            }

            return View();
        }

        public ActionResult Delete(User user)
        {
            using (UnitOfWork<User> unit = new UnitOfWork<User>(new BDContext()))
            {
                unit.genericDAL.Remove(user);
                unit.Complete();
            }

            return View();
        }
    }
}