using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entity
{
    public partial class OrderProduct
    {
        public int IdOrderProduct { get; set; }
        public int QuantityOrder { get; set; }
        public float PriceEach { get; set; }
        public int IdOrderFk { get; set; }
        public int IdProductFk { get; set; }
    }
}
