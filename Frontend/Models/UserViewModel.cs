using Backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Frontend.Models
{
    public class UserViewModel
    {
        [Key]
        public int UserID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string ProfileImage { get; set; }
        public int UserRol { get; set; }

        public int CommentID { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public Comment Comment { get; set; }

        public int FavoriteID { get; set; }
        public IEnumerable<Favorite> Favorites { get; set; }
        public Favorite Favorite { get; set; }
    }
}