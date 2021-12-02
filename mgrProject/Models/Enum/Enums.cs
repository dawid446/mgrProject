using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgrProject.Models.Enum
{
    enum StatusShipping
    {
        ShippingSoon,
        Shipped,
        OnTheWay,
        OutForDelivery,
        Delivered
    }
    enum StatusProvider
    {
        OK,
        BadRequest,
        NoAuth
    }

}
