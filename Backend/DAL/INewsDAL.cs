using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    public interface INewsDAL : IDisposable
    {
        bool Add(News news);
        bool Delete(int idNews);
        bool Update(News news);
        List<News> Get();
        News Get(int idNews);
    }
}
