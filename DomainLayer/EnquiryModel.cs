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
        /*
        void createSword(string name, int quantity, byte[] referenceImage);
        void createArmour(string name, int quantity, byte[] referenceImage);
        void createCeremonialSword(string name, int quantity, byte[] referenceImage);
        void CalculateEstimatedTime(out int minTime, out int maxTime);
        int countItemInOrder();
        OrderItemsModel getItemInOrder(int index);
        */

        void SaveEnquiry(Enquiry enquiry);
        void SaveAllOrderItems();
        //void createItem(string description, int quantity, byte[] referenceImage, OrderType orderType);
        OrderItems createItem(string description, int quantity, byte[] referenceImage, OrderType orderType);

        void SaveBoth(Enquiry enquiry, Customer customer, List<OrderItems> orderItems);

    }

    //Concrete Implementation
    public class EnquiryModel : IEnquiryModel
    {
        IDatabaseCreateQueries create;
        Enquiry enquiry;
        List<OrderItems> orderItemsList = new List<OrderItems>();

        public EnquiryModel(IDatabaseCreateQueries create) 
        {
            this.create = create;
        }

        public void SaveEnquiry(Enquiry enquiry)
        {
            create.SaveEnquiry(enquiry);
        }

        public void SaveAllOrderItems()
        {
            for (int i = 0; i < countItemInOrder(); i++)
            {
                create.SaveOrderItem(getItemInOrder(i));
            }
        }

        public void SaveBoth(Enquiry enquiry, Customer customer, List<OrderItems> orderItems)
        {
            create.SaveBoth(enquiry, orderItems, customer);
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
            orderItems.Enquiry = enquiry;
            return orderItems;

        }

        public int countItemInOrder()
        {
            return orderItemsList.Count();
        }

        //gets the item in an order at an index, could be ran with a loop to get all
        public OrderItems getItemInOrder(int index)
        {
            try { return orderItemsList[index]; }
            catch (Exception exception) { Console.WriteLine(exception); }
            return null;
        }

        //These methods are used to calculate the amount of time it would take for the total time.
        public void CalculateEstimatedTime(out int minTime, out int maxTime)
        {
            minTime = 0;
            maxTime = 0;

            for (int i = 0; i < countItemInOrder(); i++)
            {
                minTime += getItemInOrder(i).minTime * getItemInOrder(i).quantity;
                maxTime += getItemInOrder(i).maxTime * getItemInOrder(i).quantity;
            }
        }
        #endregion

    }
}
