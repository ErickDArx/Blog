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
    [TestClass]
    public class TestNewsDAL
    {

        private UnitOfWork<News> unit;
        [TestMethod]
        public void TestAdd()
        {
            INewsDAL NewsDAL = new NewsDALImplementacion();

            News news = new News
            {
                Title = "Prueba"
            };

            Assert.AreEqual(true, NewsDAL.Add(news));
        }

        [TestMethod]
        public void TestDelete()
        {
            INewsDAL newsDAL = new NewsDALImplementacion();



            Assert.AreEqual(true, newsDAL.Delete(13));
        }

        [TestMethod]
        public void TestUpdate()
        {
            INewsDAL newsDAL = new NewsDALImplementacion();


            News news = newsDAL.Get(1);
            news.Body = "News MOdificada";

            Assert.AreEqual(true, newsDAL.Update(news));
        }



        [TestMethod]
        public void TestAddGenerico()
        {

            News news = new News
            {
                Title = "Prueba"
            };



            using (unit = new UnitOfWork<News>(new BDContext()))
            {
                unit.genericDAL.Add(news);
                Assert.AreEqual(true, unit.Complete());
            }

        }


    }
}
