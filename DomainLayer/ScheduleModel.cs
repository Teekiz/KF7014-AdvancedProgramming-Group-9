using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DomainLayer
{
    /* 
     * - Shared - some of the methods were create by Sai Pavan Madala, others by Callum
     * - on some of the methods that had some problems, a note has been added where it was updated.
     */

    public interface IScheduleModel
    {
        //Interface implemented by Callum Rossiter.
        List<Order> GetAllOrdersWithinTwoMonths();
        Order GetOrder(int id);
        Enquiry GetEnquiryFromOrder(Order order);
        List<OrderItems> GetOrderItemsFromOrder(Order order);
        bool OnTarget(Order order);
        bool updateOrder(Order order);
    }

    public class ScheduleModel : IScheduleModel
    {
        IOrderGateway orderCRUD;
        IEnquiryGateway enquiryCRUD;
        IOrderItemGateway orderItemsCRUD;

        public ScheduleModel(IOrderGateway orderCRUD, IEnquiryGateway enquiryCRUD, IOrderItemGateway orderItemsCRUD)
        {
            this.orderCRUD = orderCRUD;
            this.enquiryCRUD = enquiryCRUD;
            this.orderItemsCRUD = orderItemsCRUD;
        }

        #region "Order reads"
        //Initially created by Sai Pavan Madala, updated by Callum Rossiter
        public List<Order> GetAllOrdersWithinTwoMonths()
        {
            List<Order> ordersWithinTheNextTwoMonths = new List<Order>();
            DateTime twoMonths = DateTime.Now.AddMonths(2);
            try
            {
                foreach (Order order in orderCRUD.GetAllOrders())
                {
                    if (order.confirmedDeadline < twoMonths && order.progressCompleted < 100) { ordersWithinTheNextTwoMonths.Add(order); }
                }
                return ordersWithinTheNextTwoMonths;
            }
            catch (NullReferenceException) { System.Windows.Forms.MessageBox.Show("There are no orders (Is there a database connection?)"); return ordersWithinTheNextTwoMonths; throw; }  
        }

        //Initially created by Sai Pavan Madala, updated by Callum Rossiter
        public Order GetOrder(int id) 
        { 
            return orderCRUD.GetOrder(id); 
        }

        //Initially created by Sai Pavan Madala, updated by Callum Rossiter
        public Enquiry GetEnquiryFromOrder(Order order)
        {
            return enquiryCRUD.GetEnquiry(orderCRUD.FindEnquiryIDinOrder(order));
        }

        //Initially created by Sai Pavan Madala, updated by Callum Rossiter
        public List<OrderItems> GetOrderItemsFromOrder(Order order)
        {
            return orderItemsCRUD.GetOrderItemsInEnquiry(orderCRUD.FindEnquiryIDinOrder(order));
        }
        #endregion

        //Created by Callum Rossiter
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

            if (order.progressCompleted <= 25 && now > onequater)
            { return false; }
            else if (order.progressCompleted <= 50 && now > half)
            { return false; }
            else if (order.progressCompleted <= 75 && now > threequaters)
            { return false; }
            else if (order.progressCompleted <= 100 && now >= deadline)
            { return false; }
            else { return true; }
        }

        //this method can be used for requirement 5, "Allows a percentage complete to be recorded against an order".
        ////Initially created by Sai Pavan Madala, updated by Callum Rossiter
        public bool updateOrder(Order order)
        {
            try { orderCRUD.UpdateOrder(order); return true; }
            catch { return false;}  
        }
    }
}
