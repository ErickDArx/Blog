using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frontend.Models
{
    public class CommentViewModel
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }

        public int UserID { get; set; }
        public IEnumerable<User> User { get; set; }
    }
}