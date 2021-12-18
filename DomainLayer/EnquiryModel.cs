using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DomainLayer
{
    //EnqeiuryInterface
    public interface IEnquiryModel
    {
        OrderItems createItem(string description, int quantity, byte[] referenceImage, OrderType orderType);
        List<OrderItems> GetItemsInEnquiry(int enquiryID);
        List<Enquiry> GetEnquiries(); 
        void SaveEnquiry(Enquiry enquiry, Customer customer, List<OrderItems> orderItems);
        void CalculateEstimatedTime(out int minTime, out int maxTime, out double minCost, out double maxCost, List<OrderItems> orderItems);
        bool CheckSchedule(DateTime checkStartDate, Enquiry enquiry);
    }

    //Concrete Implementation
    public class EnquiryModel : IEnquiryModel
    {
        IDatabaseCreateQueries create;
        IDatabaseReadQueries read;
        Enquiry enquiry;

        public EnquiryModel(IDatabaseCreateQueries create, IDatabaseReadQueries read) 
        {
            this.create = create;
            this.read = read;
        }

        public void SaveEnquiry(Enquiry enquiry, Customer customer, List<OrderItems> orderItems)
        {
            create.SaveEnquiry(enquiry, orderItems, customer);
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

        #region "OrderItems"
        //used to create a sword item in the order
        //i'm not entirely happy with how this works - the coupling between the classes seems quite high (but atm it works), rework later if possible.
        public OrderItems createItem(string description, int quantity, byte[] referenceImage, OrderType orderType)
        {
            OrderItems orderItems;

            if (orderType == OrderType.Sword)
            {
                orderItems = ItemFactory.Singleton.GetItemTypes(OrderType.Sword);
            }
            else if (orderType == OrderType.Armour)
            {
                orderItems = ItemFactory.Singleton.GetItemTypes(OrderType.Armour);
            }
            else
            {
                orderItems = ItemFactory.Singleton.GetItemTypes(OrderType.CeremonialSword);
            }

            orderItems.description = description;
            orderItems.quantity = quantity;
            orderItems.referenceImage = referenceImage;
            orderItems.Enquiry = enquiry;
            return orderItems;
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
        #endregion

    }
}
