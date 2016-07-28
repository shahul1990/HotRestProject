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
    
    public partial class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int OrderId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public decimal Total { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public Nullable<int> GuestId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual GuestDetail GuestDetail { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
