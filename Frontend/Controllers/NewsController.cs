using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frontend.Models;
using System.Web.Mvc;
using Backend.Entities;
using Backend.DAL;
using System.IO;

namespace Frontend.Controllers
{
    public class NewsController : Controller
    {
        private NewsViewModel Convert(News news)
        {
            return new NewsViewModel
            {
                ID = news.ID,
                Title = news.Title,
                Body = news.Body,
                BannerImage = news.BannerImage,
                PublishDate = news.PublishDate,
                UserID = (int)news.UserID,        

            };

        }

        private News Convert(NewsViewModel newsViewModel)
        {
            return new News
            {
                Title = newsViewModel.Title,
                Body = newsViewModel.Body,
                BannerImage = newsViewModel.BannerImage,
                PublishDate = newsViewModel.PublishDate,
                UserID = newsViewModel.UserID,
                User = newsViewModel.User,
            };

        }


        // GET: News
        public ActionResult Index()
        {

            BDContext bd = new BDContext();
            UnionViewModel unionViewModel = new UnionViewModel();
            unionViewModel.News = bd.News.ToList();
            unionViewModel.comments = bd.Comments.ToList();
            unionViewModel.Users = bd.Users.ToList();

            return View(unionViewModel);
        }

        public ActionResult Create()
        {
            User user;
            using (UnitOfWork<User> unit = new UnitOfWork<User>(new BDContext()))
            {
                user = unit.genericDAL.Get(420);
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Create(NewsViewModel newsViewModel)
        {
            string fileName = Path.GetFileName(newsViewModel.BannerImageFile.FileName);
            newsViewModel.BannerImage = "~/Media/Images/" + fileName;
            //news.NewsBannerImage = "~/Media/Images/{BlogUrl}/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Media/Images/"), fileName);
            newsViewModel.BannerImageFile.SaveAs(fileName);

            News blogEntry = this.Convert(newsViewModel);
            using (UnitOfWork<News> unit = new UnitOfWork<News>(new BDContext()))
            {
                unit.genericDAL.Add(blogEntry);
                unit.Complete();
            }

            return RedirectToAction("Index", "News");
        }

        [HttpPost]
        public ActionResult Delete(News news)
        {
            using (UnitOfWork<News> unit = new UnitOfWork<News>(new BDContext()))
            {
                unit.genericDAL.Remove(news);
                unit.Complete();
            }

            return RedirectToAction("Index", "News");
        }

        public ActionResult Edit(int id)
        {
            News blog;
            using (UnitOfWork<News> unit = new UnitOfWork<News>(new BDContext()))
            {
                blog = unit.genericDAL.Get(id);
            }

            return View(this.Convert(blog));
        }

        public ActionResult Details()
        {

            NewsViewModel user = new NewsViewModel { };

            using (UnitOfWork<User> unit = new UnitOfWork<User>(new BDContext()))
            {
                user.Users = unit.genericDAL.GetAll();
            }

            return View(this.Convert(user));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            News blog;

            using (UnitOfWork<News> unit = new UnitOfWork<News>(new BDContext()))
            {
                blog = unit.genericDAL.Get(id);

            }


            return View(this.Convert(blog));
        }
    }
}