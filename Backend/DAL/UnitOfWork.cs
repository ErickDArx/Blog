using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    class UnitOfWork<T> : IDisposable where T : class
    {
        private readonly BDContext context;
        public IDALGeneric<T> genericDAL;

        public UnitOfWork(BDContext _context)
        {
            context = _context;
            genericDAL = new DALGenericImplementation<T>(context);
        }

        public bool Complete()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }

        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
