using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    public class NewsDALImplementacion : INewsDAL
    {
        private BDContext context;

        public bool Add(News news)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.News.Add(news);
                    context.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Delete(int idNews)
        {
            try
            {
                News news = this.Get(idNews);
                using (context = new BDContext())
                {
                    context.News.Attach(news);
                    context.News.Remove(news);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<News> Get()
        {
            List<News> result;
            using (context = new BDContext())
            {
                result = (from c in context.News

                          select c).ToList();
            }
            return result;
        }

        public News Get(int idNews)
        {

            News result;
            using (context = new BDContext())
            {
                result = (from c in context.News
                          where c.ID == idNews
                          select c).FirstOrDefault();
            }
            return result;
        }

        public bool Update(News news)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.Entry(news).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
