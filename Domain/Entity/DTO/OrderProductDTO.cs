using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity.DTO
{
    public class OrderProductDTO
    {
        public int IdOrderProduct { get; set; }
        public int QuantityOrder { get; set; }
        public float PriceEach { get; set; }
        public int IdOrderFk { get; set; }
        public int IdProductFk { get; set; }
    }
}
