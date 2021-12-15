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

    }

    //Concrete Implementation
    public class EnquiryModel : IEnquiryModel
    {
        IDatabaseCreateQueries create;
        Enquiry enquiry;

        public EnquiryModel(IDatabaseCreateQueries create) 
        {
            this.create = create;
        }

        #region "Code for creation for item type"

        /*

        //used to create a sword item in the order
        //i'm not entirely happy with how this works - the coupling between the classes seems quite high (but atm it works), rework later if possible.
        public void createSword(string name, int quantity, byte[] referenceImage)
        {
            OrderItemsModel orderItems = ItemFactory.Singleton.GetItemTypes(OrderType.Sword, name, quantity, referenceImage);
            orderItemsList.Add(orderItems);
        }

        public void createArmour(string name, int quantity, byte[] referenceImage)
        {
            OrderItemsModel orderItems = ItemFactory.Singleton.GetItemTypes(OrderType.Armour, name, quantity, referenceImage);
            orderItemsList.Add(orderItems);
        }

        public void createCeremonialSword(string name, int quantity, byte[] referenceImage)
        {
            OrderItemsModel orderItems = ItemFactory.Singleton.GetItemTypes(OrderType.CeremonialSword, name, quantity, referenceImage);
            orderItemsList.Add(orderItems);
        }
        */

        #endregion


        #region "Code used for the orderItemsList (count, get, calc)"

        /*
        //primarly useful for testing
        public int countItemInOrder()
        {
            return orderItemsList.Count();
        }

        //gets the item in an order at an index, could be ran with a loop to get all
        public OrderItemsModel getItemInOrder(int index)
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
                minTime += getItemInOrder(i).GetMinTime() * getItemInOrder(i).GetQuantity();
                maxTime += getItemInOrder(i).GetMaxTime() * getItemInOrder(i).GetQuantity();
            }
        }
        */

        #endregion

        /*
        public void getSavedEnquiry()
        {
            foreach (var i in read.GetAllEnquiries())
            {
                int order = i.orderID;
                System.Windows.Forms.MessageBox.Show(order.ToString());
            }
        }
        */

        public void SaveEnquiry(Enquiry enquiry)
        {
            create.SaveEnquiry(enquiry);
        }
    }
}
