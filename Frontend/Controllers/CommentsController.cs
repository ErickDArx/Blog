using Backend.DAL;
using Backend.Entities;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace Frontend.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
<<<<<<< HEAD
        private CommentViewModel Convert(Comment comment)
=======
        /*private CommentsViewModel Convert(Comment comment)
>>>>>>> aadd54f04d2c602bf164e3d82c54aa76b8ff1080
        {
            CommentViewModel commentsViewModel = new CommentViewModel
            {
                ID = comment.ID,
                Content = comment.Content,
                CommentDate = comment.CommentDate,
<<<<<<< HEAD
                UserID = (int)comment.UserID,
=======
                UserID = comment.UserID,
                User = comment.User,
>>>>>>> aadd54f04d2c602bf164e3d82c54aa76b8ff1080

            };

            return commentsViewModel;
        }

        private Comment Convert(CommentViewModel commentsViewModel)
        {
            Comment comment = new Comment
            {
                ID = commentsViewModel.ID,
                Content = commentsViewModel.Content,
                CommentDate = commentsViewModel.CommentDate,
                UserID = commentsViewModel.UserID,
            };

            return comment;
        }

        // GET: Comments
        public ActionResult Index()
        {

            List<Comment> comments;
            using (UnitOfWork<Comment> unit = new UnitOfWork<Comment>(new BDContext()))
            {
                comments = unit.genericDAL.GetAll().ToList();
            }

            return View(comments);
        }

        public ActionResult Create()
        {

            CommentViewModel comment = new CommentViewModel { };

            using (UnitOfWork<User> unit = new UnitOfWork<User>(new BDContext()))
            {
                comment.User = unit.genericDAL.GetAll().ToList();

            }
            return View(comment);
        }

        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            using (UnitOfWork<Comment> unit = new UnitOfWork<Comment>(new BDContext()))
            {
                unit.genericDAL.Add(comment);
                unit.Complete();
            }

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            Comment commentEntity;
            using (UnitOfWork<Comment> unit = new UnitOfWork<Comment>(new BDContext()))
            {
                commentEntity = unit.genericDAL.Get(id);

            }

            CommentViewModel comments = this.Convert(commentEntity);

            User user;
            List<User> users;

            using (UnitOfWork<User> unit = new UnitOfWork<User>(new BDContext()))
            {
                users = unit.genericDAL.GetAll().ToList();
                user = unit.genericDAL.Get(comments.UserID);
            }
            users.Insert(0, user);
<<<<<<< HEAD
            //comments.Users = users;
=======
            comments.Users = users;

>>>>>>> aadd54f04d2c602bf164e3d82c54aa76b8ff1080

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            using (UnitOfWork<Comment> unit = new UnitOfWork<Comment>(new BDContext()))
            {
                unit.genericDAL.Update(comment);
                unit.Complete();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Comment commentEntity;
            using (UnitOfWork<Comment> unidad = new UnitOfWork<Comment>(new BDContext()))
            {
                commentEntity = unidad.genericDAL.Get(id);

            }

            CommentViewModel comment = this.Convert(commentEntity);

            using (UnitOfWork<User> unit = new UnitOfWork<User>(new BDContext()))
            {

                //comment.User = unit.genericDAL.Get(comment.UserID);
            };

            return View(comment);
        }

        public ActionResult Delete(int id)
        {
            Comment commentEntity;
            using (UnitOfWork<Comment> unit = new UnitOfWork<Comment>(new BDContext()))
            {
                commentEntity = unit.genericDAL.Get(id);

            }

            CommentViewModel comment = this.Convert(commentEntity);

            using (UnitOfWork<User> unit = new UnitOfWork<User>(new BDContext()))
            {

                //comment.User = unit.genericDAL.Get(comment.UserID);
            };

            return View(comment);
        }

        [HttpPost]
        public ActionResult Delete(Comment comment)
        {
            using (UnitOfWork<Comment> unit = new UnitOfWork<Comment>(new BDContext()))
            {
                unit.genericDAL.Remove(comment);
                unit.Complete();
            }

            return RedirectToAction("Index");
<<<<<<< HEAD
        }
=======
        }*/

>>>>>>> aadd54f04d2c602bf164e3d82c54aa76b8ff1080
    }
}

