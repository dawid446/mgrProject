using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity.DTO
{
    public class OrderDTO
    {
        public int IdOrder { get; set; }
        public float TotalPrice { get; set; }
        public float ShippingCost { get; set; }
        public DateTime OrderDate { get; set; }
        public string Comment { get; set; }
        public string Token { get; set; }
        public bool? Canceled { get; set; }
        public DateTime? CanceledDate { get; set; }
        public string CanceledComment { get; set; }
        public int IdOrderStatusFk { get; set; }
        public int IdPaymentDetailsFk { get; set; }
        public int IdShipmentAdressFk { get; set; }
        public int IdUserFk { get; set; }
        public int IdShipmentDetailsFk { get; set; }
    }
}
