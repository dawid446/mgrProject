using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entity
{
    public partial class ShipmentAdress
    {
        public ShipmentAdress()
        {
            Orders = new HashSet<Order>();
        }

        public int IdShipmentAdress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public int? IdUserFk { get; set; }

        public virtual User IdUserFkNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
