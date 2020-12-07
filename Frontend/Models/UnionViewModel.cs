using Backend.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frontend.Models
{
    public class UnionViewModel
    {
        public News News { get; set; }
        public User User { get; set; }
    }
}