using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Frontend.Models
{
    public class UsersViewModel
    {
        [Key]
        public int UserID { get; set; }
    }
}