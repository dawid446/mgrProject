using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity.DTO
{
    public class ShoppingCartDTO
    {
        public int IdShoppingCart { get; set; }
        public int QuantityCart { get; set; }
        public float PriceEach { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int IdCartFk { get; set; }
        public int IdProductFk { get; set; }

    }
}
