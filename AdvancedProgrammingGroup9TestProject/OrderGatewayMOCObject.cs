using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace AdvancedProgrammingGroup9TestProject
{
    //Created by Callum Rossiter
    public class OrderGatewayMOCObject : IOrderGateway
    {
        public Order storedOrder;
        List<Order> OrderList;

        public OrderGatewayMOCObject()
        {
            OrderList = new List<Order>();
            //so that testing doesn't break
            Enquiry en = new Enquiry();
            en.orderID = 1;
            storedOrder = new Order();
            storedOrder.orderID = 1;
            storedOrder.progressCompleted = 0;
            storedOrder.scheduledStartDate = new DateTime(20/12/2021);
            storedOrder.confirmedDeadline = new DateTime(30/12/2021);
            storedOrder.Enquiry = en;
            OrderList.Add(storedOrder);

            //these are used for the later methods
            //28/01/2021 - 01/01/2022
            Enquiry enquiry2 = new Enquiry();
            enquiry2.orderID = 2;
            Order order2 = new Order();
            order2.orderID = 2;
            order2.progressCompleted = 0;
            order2.scheduledStartDate = new DateTime(2021, 12, 28); 
            order2.confirmedDeadline = new DateTime(2022, 1, 1);
            order2.Enquiry = enquiry2;
            OrderList.Add(order2);

            Enquiry enquiry3 = new Enquiry();
            enquiry3.orderID = 3;
            Order order3 = new Order();
            order3.orderID = 3;
            order3.progressCompleted = 100;
            order3.scheduledStartDate = new DateTime(2022, 1, 2);
            order3.confirmedDeadline = new DateTime(2022, 1, 9);
            order3.Enquiry = enquiry3;
            OrderList.Add(order3);

            Enquiry enquiry4 = new Enquiry();
            enquiry4.orderID = 4;
            Order order4 = new Order();
            order4.orderID = 4;
            order4.progressCompleted = 0;
            order4.scheduledStartDate = new DateTime(2022, 1, 14);
            order4.confirmedDeadline = new DateTime(2022, 1, 20);
            order4.Enquiry = enquiry4;
            OrderList.Add(order4);

            Enquiry enquiry5 = new Enquiry();
            enquiry5.orderID = 5;
            Order order5 = new Order();
            order5.orderID = 5;
            order5.progressCompleted = 0;
            order5.scheduledStartDate = new DateTime(2022, 1, 21);
            order5.confirmedDeadline = new DateTime(2022, 2, 21);
            order5.Enquiry = enquiry5;
            OrderList.Add(order5);

            //for the schedule -- this are past the two months
            Enquiry enquiry6 = new Enquiry();
            enquiry6.orderID = 6;
            Order order6 = new Order();
            order6.orderID = 6;
            order6.progressCompleted = 0;
            order6.scheduledStartDate = new DateTime(2022, 4, 21);
            order6.confirmedDeadline = new DateTime(2022, 5, 21);
            order6.Enquiry = enquiry6;
            OrderList.Add(order6);

            Enquiry enquiry7 = new Enquiry();
            enquiry7.orderID = 7;
            Order order7 = new Order();
            order7.orderID = 7;
            order7.progressCompleted = 0;
            order7.scheduledStartDate = new DateTime(2022, 5, 22);
            order7.confirmedDeadline = new DateTime(2022, 5, 28);
            order7.Enquiry = enquiry7;
            OrderList.Add(order7);
        }

        public bool SaveOrder(Order order)
        {
            storedOrder = order;
            return true;
        }

        public bool UpdateOrder(Order order)
        {
            return true;
        }

        public bool DeleteAllOrders()
        {
            return true;
        }

        public bool DeleteOrder(int id)
        {
            return true;
        }

        public int FindEnquiryIDinOrder(Order order)
        {
            foreach (Order o in OrderList)
            { 
                if (order.orderID == o.orderID) { return o.Enquiry.orderID; }
            }
            return 0;
        }

        public List<Order> GetAllOrders()
        {   
            return OrderList;
        }

        public Order GetOrder(int id)
        {
            foreach (Order o in OrderList)
            {
                if (o.orderID == id) { return o; }
            }
            return null;
        }
    }
}
