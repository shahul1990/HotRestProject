//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int id { get; set; }
        public string Itemname { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
}
