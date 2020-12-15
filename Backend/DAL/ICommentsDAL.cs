using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBackend
{
    public interface ICommentsDAL : IDisposable
    {
        bool Add(Comment comment);
        bool Delete(int idComment);
        bool Update(Comment comment);
        List<Comment> Get();
        Comment Get(int idComment);
    }
}