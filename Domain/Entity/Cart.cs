using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entity
{
    public partial class Cart
    {
        public Cart()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int IdCart { get; set; }
        public string Token { get; set; }
        public string SessionId { get; set; }
        public sbyte Active { get; set; }
        public int? IdUserFk { get; set; }

        public virtual User IdUserFkNavigation { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
