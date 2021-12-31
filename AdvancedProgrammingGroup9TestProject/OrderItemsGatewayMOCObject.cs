using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainLayer;

namespace AdvancedProgrammingGroup9TestProject
{
    public class OrderItemsGatewayMOCObject : IOrderItemGateway
    {
        public List<OrderItems> storedItems;
        OrderItems itemOne;
        OrderItems itemTwo;

        public OrderItemsGatewayMOCObject()
        {
            storedItems = new List<OrderItems>();

            itemOne = ItemFactory.Singleton.GetItemTypes(OrderType.Sword);
            itemOne.description = "itemOne";
            itemOne.quantity = 4;
            itemOne.referenceImage = null;
            storedItems.Add(itemOne);

            itemTwo = ItemFactory.Singleton.GetItemTypes(OrderType.Armour);
            itemTwo.description = "itemTwo";
            itemTwo.quantity = 2;
            itemTwo.referenceImage = null;

            storedItems.Add(itemTwo);
        }

        public bool DeleteAllOrderItems()
        {
            return true;
        }

        public bool DeleteOrderItems(int id)
        {
            return true;
        }

        public bool DeleteOrderItemsInEnquiry(int id)
        {
            return true ;
        }

        public List<OrderItems> GetOrderItemsInEnquiry(int enquiryID)
        {
            if (enquiryID > 1) { return null; }
            else { return storedItems; }
        }

        public bool SaveOrderItems(List<OrderItems> orderItems, Enquiry enquiry)
        {
            return true;
        }
    }
}
