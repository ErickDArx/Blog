using Backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Frontend.Models
{
    public class NewsViewModel
    {
        [Display(Name = "ID")]
        [Key]
        public int NewsId { get; set; }

        [Display(Name = "Titulo")]
        public string NewsTitle { get; set; }

        [Display(Name = "Cuerpo")]
        public string NewsBody { get; set; }

        [Display(Name = "Fecha de publicación")]
        public DateTime NewsDate { get; set; }

        [Display(Name = "Imagen del Banner")]
        public string NewsBannerImage { get; set; }

        public int UserId { get; set; }
        public IEnumerable<User> users { get; set; }
        public User User { get; set; }
    }
}