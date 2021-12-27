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
    /*
     * This model is used to cover functional requirement #1
     * 
     * 1.Initial enquiry:  Due to the sporadic nature of the demand there are times when the company needs to refuse orders it cannot complete.  
     * It should be able to provide honest estimates as to when a potential order can be completed.  
     * An initial form captures the key information so that an estimate can be given to the client, 
     * they are also recorded in the system as an enquiry so that the client can choose to turn the enquiry into an order at a later date.
     * 
     */

    //EnquiryInterface
    public interface IEnquiryModel
    {
        OrderItems createItem(string description, int quantity, byte[] referenceImage, OrderType orderType);
        void SaveEnquiry(Enquiry enquiry, Customer customer, List<OrderItems> orderItems);
        void CalculateEstimatedTime(out int minTime, out int maxTime, out double minCost, out double maxCost, List<OrderItems> orderItems);
        Customer GetCustomer();
        Enquiry GetEnquiry();
    }

    //Concrete Implementation
    public class EnquiryModel : IEnquiryModel
    {
        IDatabaseCreateQueries create;

        public EnquiryModel(IDatabaseCreateQueries create, IDatabaseReadQueries read) 
        {
            this.create = create;
        }

        public void SaveEnquiry(Enquiry enquiry, Customer customer, List<OrderItems> orderItems)
        {
            create.SaveEnquiry(enquiry, orderItems, customer);
        }


        public Customer GetCustomer()
        {
            return new Customer();
        }

        public Enquiry GetEnquiry()
        {
            return new Enquiry();
        }

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
            //orderItems.Enquiry = enquiry;
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
