using Backend.DAL;
using Backend.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBackend
{
    public class TestCommentsDAL
    {
        private UnitOfWork<Comment> unit;
        [TestMethod]
        public void TestAdd()
        {
            ICommentsDAL CommentDAL = new CommentsDALImplementacion();

            Comment comment = new Comment
            {
                Content = "Prueba"
            };

            Assert.AreEqual(true, CommentDAL.Add(comment));
        }

        [TestMethod]
        public void TestDelete()
        {
            ICommentsDAL commentsDAL = new CommentsDALImplementacion();



            Assert.AreEqual(true, commentsDAL.Delete(13));
        }

        [TestMethod]
        public void TestUpdate()
        {
            ICommentsDAL commentsDAL = new CommentsDALImplementacion();


            Comment comment = commentsDAL.Get(1);
            comment.Content = "Comment MOdificada";

            Assert.AreEqual(true, commentsDAL.Update(comment));
        }



        [TestMethod]
        public void TestAddGenerico()
        {

            Comment comment = new Comment
            {
                Content = "Prueba"
            };



            using (unit = new UnitOfWork<Comment>(new BDContext()))
            {
                unit.genericDAL.Add(comment);
                Assert.AreEqual(true, unit.Complete());
            }

        }


    }
}
