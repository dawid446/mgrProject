using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entity
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public float TotalPrice { get; set; }
        public float ShippingCost { get; set; }
        public DateTime OrderDate { get; set; }
        public string Comment { get; set; }
        public string Token { get; set; }
        public sbyte? Canceled { get; set; }
        public DateTime? CanceledDate { get; set; }
        public string CanceledComment { get; set; }
        public int IdOrderStatusFk { get; set; }
        public int IdPaymentDetailsFk { get; set; }
        public int IdShipmentAdressFk { get; set; }
        public int IdUserFk { get; set; }
        public int IdShipmentDetailsFk { get; set; }

        public virtual OrderStatus IdOrderStatusFkNavigation { get; set; }
        public virtual PaymentDetail IdPaymentDetailsFkNavigation { get; set; }
        public virtual ShipmentAdress IdShipmentAdressFkNavigation { get; set; }
        public virtual ShipmentDetail IdShipmentDetailsFkNavigation { get; set; }
        public virtual User IdUserFkNavigation { get; set; }
    }
}
