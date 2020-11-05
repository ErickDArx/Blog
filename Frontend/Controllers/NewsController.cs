using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Frontend.Models;
using System.Web.Mvc;
using Backend.Entities;
using Backend.DAL;

namespace Frontend.Controllers
{
    public class NewsController : Controller
    {
        private NewsViewModel Convert(News news)
        {
            NewsViewModel newsViewModel = new NewsViewModel
            {
                NewsId = news.ID,
                NewsTitle = news.Title,
                NewsBody = news.Body,
                NewsBannerImage = news.BannerImage,
                NewsDate = news.PublishDate,
                UserId = (int)news.UserID
            };

            return newsViewModel;
        }

        private News Convert(NewsViewModel newsViewModel)
        {
            News news = new News
            {
                ID = newsViewModel.NewsId,
                Title = newsViewModel.NewsTitle,
                Body = newsViewModel.NewsBody,
                BannerImage = newsViewModel.NewsBannerImage,
                PublishDate = newsViewModel.NewsDate,
                UserID = newsViewModel.UserId
            };

            return news;
        }

        // GET: News
        public ActionResult Index()
        {

            List<News> news;
            using (UnitOfWork<News> unit = new UnitOfWork<News>(new BDContext()))
            {
                news = unit.genericDAL.GetAll().ToList();
            }

            return View(news);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsViewModel newsViewModel)
        {
            News news = this.Convert(newsViewModel);

            using (UnitOfWork<News> unit = new UnitOfWork<News>(new BDContext()))
            {
                unit.genericDAL.Add(news);
                unit.Complete();
            }

            return RedirectToAction("Index");
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
    }
}