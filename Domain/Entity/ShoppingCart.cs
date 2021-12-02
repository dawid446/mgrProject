using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entity
{
    public partial class ShoppingCart
    {
        public int IdShoppingCart { get; set; }
        public int QuantityCart { get; set; }
        public float PriceEach { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int IdProductFk { get; set; }
        public int IdCartFk { get; set; }

        public virtual Cart IdCartFkNavigation { get; set; }
    }
}
