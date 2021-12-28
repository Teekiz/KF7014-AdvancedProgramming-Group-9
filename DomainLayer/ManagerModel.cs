using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DomainLayer
{
    /*
     * This model is used to cover functional requirement #2
     * 
     * 2.Production estimates: The contracts manager will quickly assess the time needed to complete the order this will be in hours, 
     * and price the work accordingly. The system will then check to see if the work can be scheduled.
     * 
     */

    public interface IManagerModel
    {
        List<OrderItems> GetItemsInEnquiry(int enquiryID);
        List<Enquiry> GetEnquiries();
        Enquiry GetEnquiry(int enquiryID);
        void UpdateEnquiry(Enquiry enquiry);
        void CalculateEstimatedTime(out int minTime, out int maxTime, out double minCost, out double maxCost, List<OrderItems> orderItems);
        bool CheckSchedule(DateTime checkStartDate, Enquiry enquiry);
    }

    public class ManagerModel
    {
        IEnquiryGateway enquiryCRUD;
        ICustomerGateway customerCRUD;
        IOrderItemGateway orderItemsCRUD;

        public ManagerModel(IEnquiryGateway enquiryCRUD, ICustomerGateway customerCRUD, IOrderItemGateway orderItemsCRUD)
        {
            this.enquiryCRUD = enquiryCRUD;
            this.customerCRUD = customerCRUD;
            this.orderItemsCRUD = orderItemsCRUD;
        }

        public void UpdateEnquiry(Enquiry enquiry)
        {
            enquiryCRUD.UpdateEnquiry(enquiry);
        }

        #region "Enquiry Reads"
        public List<Enquiry> GetEnquiries()
        {
            return enquiryCRUD.GetAllEnquiries();
        }

        public List<OrderItems> GetItemsInEnquiry(int enquiryID)
        {
            return orderItemsCRUD.GetOrderItemsInEnquiry(enquiryID);
        }
        #endregion

        public Enquiry GetEnquiry(int enquiryID)
        {
            return enquiryCRUD.GetEnquiry(enquiryID);
        }

        //This current version will be "dumb" - as in it it just checks an order against a time. -this can be changed later on.
        //UNTESTED
        public bool CheckSchedule(DateTime checkStartDate, Enquiry enquiry)
        {
            for (int i = 0; i < read.GetAllOrders().Count(); i++)
            {
                DateTime orderStartDate = read.GetAllOrders()[i].scheduledStartDate;
                int percentComplete = read.GetAllOrders()[i].progressCompleted;

                //look for all orders that are not completed and start before the deadline
                if (orderStartDate < enquiry.deadline && percentComplete < 100)
                {
                    DateTime orderDeadline = enquiryCRUD.GetEnquiry(read.GetAllOrders()[i].Enquiry.orderID).deadline;
                    //if the date to start falls between the start date of another order and the deadline then the space is taken. 
                    if (checkStartDate > orderStartDate && enquiry.deadline < orderDeadline)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void CalculateEstimatedTime(out int minTime, out int maxTime, out double minCost, out double maxCost, List<OrderItems> orderItems)
        {
            minTime = 0;
            maxTime = 0;
            minCost = 0;
            maxCost = 0;

            for (int i = 0; i < orderItems.Count(); i++)
            {
                orderItems[i].getItemTime(out int minCalcTime, out int maxCalcTime);
                orderItems[i].getItemCost(out double minCalcCost, out double maxCalcCost);
                minTime += minCalcTime;
                maxTime += maxCalcTime;
                minCost += minCalcCost;
                maxCost += maxCalcCost;
            }
        }
    }
}
