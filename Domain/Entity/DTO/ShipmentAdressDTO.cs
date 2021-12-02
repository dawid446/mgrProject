using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity.DTO
{
    public class ShipmentAdressDTO
    {

        public int IdShipmentAdress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public int? UserIduser { get; set; }

    }
}
