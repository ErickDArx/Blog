using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBackend
{
    public class CommentsDALImplementacion : ICommentsDAL 
    {
        private BDContext context;



        public bool Add(Comment comment)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.Comments.Add(comment);
                    context.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Delete(int idComments)
        {
            try
            {
                Comment comment = this.Get(idComments);
                using (context = new BDContext())
                {
                    context.Comments.Attach(comment);
                    context.Comments.Remove(comment);
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

        public List<Comment> Get()
        {
            List<Comment> result;
            using (context = new BDContext())
            {
                result = (from c in context.Comments

                          select c).ToList();
            }
            return result;
        }

        public Comment Get(int idComments)
        {

            Comment result;
            using (context = new BDContext())
            {
                result = (from c in context.Comments
                          where c.ID == idComments
                          select c).FirstOrDefault();
            }
            return result;
        }

        public bool Update(Comment comment)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.Entry(comment).State = System.Data.Entity.EntityState.Modified;
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
