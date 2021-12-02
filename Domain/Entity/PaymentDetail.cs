using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entity
{
    public partial class PaymentDetail
    {
        public PaymentDetail()
        {
            Orders = new HashSet<Order>();
        }

        public int IdPaymentDetails { get; set; }
        public string Provider { get; set; }
        public string IdProvider { get; set; }
        public string StatusProvider { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
