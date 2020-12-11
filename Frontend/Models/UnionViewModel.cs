using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frontend.Models
{
    public class UnionViewModel
    {
        public List<News> News { get; set;}
        public List<User> Users { get; set; }
        public List<Comment> comments { get; set;}
        public List<Tag> Tags { get; set; }
        public List<Favorite> Favorites { get; set; }

    }
}