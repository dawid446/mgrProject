using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entity
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            ShipmentAdresses = new HashSet<ShipmentAdress>();
        }

        public int IdUser { get; set; }
        public string Email { get; set; }
        public sbyte? EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumer { get; set; }
        public sbyte? PhoneNumerConfirmed { get; set; }
        public sbyte? TwoFactoryEnabled { get; set; }
        public DateTime? LockoutDate { get; set; }
        public sbyte? Lockout { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ShipmentAdress> ShipmentAdresses { get; set; }
    }
}
