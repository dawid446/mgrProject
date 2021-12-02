using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entity
{
    public partial class ShipmentDetail
    {
        public ShipmentDetail()
        {
            Orders = new HashSet<Order>();
        }

        public int IdShipmentDetails { get; set; }
        public string ProviderName { get; set; }
        public string Status { get; set; }
        public string TrackingNumber { get; set; }
        public string BarcodeProvider { get; set; }
        public string StatusProvider { get; set; }
        public DateTime? ShipmentDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
