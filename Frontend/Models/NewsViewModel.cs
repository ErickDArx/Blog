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
        [Key]
        public int ID { get; set; }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "Debe ingresar un titulo")]
        public string Title { get; set; }

        [Display(Name = "Cuerpo")]
        [Required(ErrorMessage = "Debe digitar el Cuerpo")]
        public string Body { get; set; }

        [Display(Name = "Fecha de publicación")]
        [Required(ErrorMessage = "Debe digitar Fecha de publicación")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Imagen del Banner")]
        //[Required(ErrorMessage = "Debe agregar un banner")]
        public string BannerImage { get; set; }

        public HttpPostedFileBase BannerImageFile { get; set; }

        public int UserID { get; set; }
        public IEnumerable<User> Users { get; set; }
        public User User { get; set; }
    }
}