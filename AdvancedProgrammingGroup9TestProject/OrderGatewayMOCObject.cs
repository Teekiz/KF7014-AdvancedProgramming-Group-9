using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace AdvancedProgrammingGroup9TestProject
{
    public class OrderGatewayMOCObject : IOrderGateway
    {
        public Order storedOrder;

        public OrderGatewayMOCObject()
        {
            storedOrder = new Order();
            storedOrder.progressCompleted = 0;
            storedOrder.scheduledStartDate = new DateTime(20/12/2021);
            storedOrder.confirmedDeadline = new DateTime(30/12/2021);
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
            return 1;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> OrderList = new List<Order>();
            OrderList.Add(storedOrder);
            return OrderList;
        }

        public Order GetOrder(int id)
        {
            return storedOrder;
        }
    }
}
