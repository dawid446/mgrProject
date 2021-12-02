using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity.DTO
{
    public class PaymentDetailDTO
    {
        public int IdPaymentDetails { get; set; }
        public string Provider { get; set; }
        public string IdProvider { get; set; }
        public string StatusProvider { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
