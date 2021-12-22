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
        void CalculateEstimatedTime(out int minTime, out int maxTime, out double minCost, out double maxCost, List<OrderItems> orderItems);
        bool CheckSchedule(DateTime checkStartDate, Enquiry enquiry);

        //Need an update method
    }

    public class ManagerModel
    {
        IDatabaseReadQueries read;

        public ManagerModel(IDatabaseReadQueries read)
        {
            this.read = read;
        }

        #region "Enquiry Reads"
        public List<Enquiry> GetEnquiries()
        {
            return read.GetAllEnquiries();
        }

        public List<OrderItems> GetItemsInEnquiry(int enquiryID)
        {
            return read.GetOrderItemsInEnquiry(enquiryID);
        }
        #endregion

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
                    DateTime orderDeadline = read.GetEnquiry(read.GetAllOrders()[i].Enquiry.orderID).deadline;
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
                minTime += minCalcTime;
                maxTime += maxCalcTime;
                minCost += orderItems[i].minCost;
                maxCost += orderItems[i].maxCost;
            }
        }
    }
}
