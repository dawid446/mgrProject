using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entity
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int IdOrderStatus { get; set; }
        public string NameStatus { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
