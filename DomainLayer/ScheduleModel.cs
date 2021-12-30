using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DomainLayer
{
    public interface IScheduleModel
    {
        List<Order> GetAllOrdersWithinTwoMonths();
        Enquiry GetEnquiryFromOrder(Order order);
        List<OrderItems> GetOrderItemsFromOrder(Order order);
        bool updateOrder(Order order);
    }

    public class ScheduleModel : IScheduleModel
    {
        IOrderGateway orderCRUD;
        IEnquiryGateway enquiryCRUD;
        IOrderItemGateway orderItemsCRUD;

        public ScheduleModel(IOrderGateway orderCRUD)
        {
            this.orderCRUD = orderCRUD;
        }

        #region "Order reads"
        public List<Order> GetAllOrdersWithinTwoMonths()
        {
            List<Order> ordersWithinTheNextTwoMonths = new List<Order>();
            DateTime twoMonths = DateTime.Now.AddMonths(2);
            foreach (Order order in orderCRUD.GetAllOrders())
            {
                if (order.confirmedDeadline < twoMonths && order.progressCompleted < 100){ ordersWithinTheNextTwoMonths.Add(order); }
            }
            return ordersWithinTheNextTwoMonths;
        }

        public Enquiry GetEnquiryFromOrder(Order order)
        {
            return enquiryCRUD.GetEnquiry(orderCRUD.FindEnquiryIDinOrder(order));
        }

        public List<OrderItems> GetOrderItemsFromOrder(Order order)
        {
            return orderItemsCRUD.GetOrderItemsInEnquiry(orderCRUD.FindEnquiryIDinOrder(order));
        }
        #endregion

        public bool OnTarget(Order order)
        {
            /*
             * This method gets the range between the startdate and deadline (hours), divides it by 4 (into quaters)
             * then adds the date minus the deadline
             * 
             * for example:
             * an order will take 96 hours. muliplyed by 3 (24 / 8 = 3) = 288 hours (12 days)
             *
             *  288 / 4 = 72 (hours). (3 days)
             *  
             *  onequater through the deadline is 9 days. 72 * 3 = 9 days
             *  if there is 9 days to go to the deadline, progress should be equal to that.
             */

            //24 hours / 3 = 8 (split into quaters)
            DateTime startdate = order.scheduledStartDate;
            DateTime deadline = order.confirmedDeadline;
            double hours = (deadline - startdate).TotalHours / 4;

            DateTime now = DateTime.Now;

            DateTime onequater = deadline.AddHours(-hours * 3);
            DateTime half = deadline.AddHours(-hours * 2);
            DateTime threequaters = deadline.AddHours(-hours * 3);

            if ((order.progressCompleted >= 25 && order.progressCompleted < 50) && now < onequater)
            { return true; }
            else if ((order.progressCompleted >= 50 && order.progressCompleted < 75) && now < half)
            { return true; }
            else if ((order.progressCompleted >= 75 && order.progressCompleted < 100) && now < threequaters)
            { return true; }
            else { return false; }
        }

        //this method can be used for requirement 5, "Allows a percentage complete to be recorded against an order".
        public bool updateOrder(Order order)
        {
            try { orderCRUD.UpdateOrder(order); return true; }
            catch { return false; }  
        }
    }
}
