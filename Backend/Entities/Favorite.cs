//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Backend.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Favorite
    {
        public int ID { get; set; }
        public Nullable<int> NewsID { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual News News { get; set; }
        public virtual User User { get; set; }
    }
}
