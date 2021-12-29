using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DomainLayer
{
    public class ScheduleModel
    {
        IOrderGateway orderCRUD;

        public ScheduleModel(IOrderGateway orderCRUD)
        {
            this.orderCRUD = orderCRUD;
        }
        public List<Order> GetAllOrders()
        {
            return orderCRUD.GetAllOrders();
        }
    }
}
