using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgrProject.Models.Dictionary
{
    public class NodeRelationship : INodeRelationship
    {
        public Dictionary<string, int>  getDictionary()
        {
            var nodeRelationship = new Dictionary<string, int>();

            nodeRelationship.Add("Cart", 5);
            nodeRelationship.Add("Category", 4);
            nodeRelationship.Add("Order", 15);
            nodeRelationship.Add("OrderStatus", 3);
            nodeRelationship.Add("PaymentDetail", 6);
            nodeRelationship.Add("Product", 11);
            nodeRelationship.Add("ShipmentAdress", 10);
            nodeRelationship.Add("ShipmentDetail", 8);
            nodeRelationship.Add("User", 11);
            nodeRelationship.Add("ORDER_PRODUCT", 3);
            nodeRelationship.Add("ORDER_STATUS", 1);
            nodeRelationship.Add("CATEGORY", 1);
            nodeRelationship.Add("PAYMENT_DETAILS", 1);
            nodeRelationship.Add("SHIPMENT_ADRESS", 1);
            nodeRelationship.Add("SHIPMENT_DETAILS", 1);
            nodeRelationship.Add("SHOPPING_CART", 5);
            nodeRelationship.Add("USER", 1);

            return nodeRelationship;
        }

    }
}
