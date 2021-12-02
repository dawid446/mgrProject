using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity.DTO
{
    public class ShipmentDetailDTO
    {
        public int IdShipmentDetails { get; set; }
        public string ProviderName { get; set; }
        public string Status { get; set; }
        public string TrackingNumber { get; set; }
        public string BarcodeProvider { get; set; }
        public string StatusProvider { get; set; }
        public DateTime? ShipmentDate { get; set; }
    }
}
