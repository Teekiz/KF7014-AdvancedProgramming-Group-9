using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgrammingGroup9
{
    //EnqeiuryInterface
    public interface IEnquiry
    {
        DateTime GetReceivedDate();
        DateTime GetDeadline();
        void createSword(string name, int quantity, byte[] referenceImage);
        void createArmour(string name, int quantity, byte[] referenceImage);
        void createCeremonialSword(string name, int quantity, byte[] referenceImage);
        void CalculateEstimatedTime(out int minTime, out int maxTime);
    }

    //Concrete Implementation
    public class Enquiry : IEnquiry
    {
        public Enquiry(DateTime receivedDate, DateTime deadline)
        {
            this.receivedDate = receivedDate;
            this.deadline = deadline;

            orderItemsList = new List<OrderItems>();
        }

        #region "Entity Framework and variables"
        [Key]
        public int orderID { get; set; }
        //[Required]
        public DateTime receivedDate { get; set; }
        //[Required]
        public DateTime deadline { get; set; }

        //TODO - Change this from customer to ICustomer
        public ICustomer customer;

        //this was orignally a virtual ICollection named orderItemLists
        //https://stackoverflow.com/questions/47310922/how-to-get-index-of-an-item-in-icollectiont
        public virtual IList<OrderItems> orderItemsList { get; set; }

        public DateTime GetReceivedDate() { return receivedDate; }
        public DateTime GetDeadline() { return deadline; }
        #endregion

        #region "Code for creation for item type"

        //used to create a sword item in the order
        public void createSword(string name, int quantity, byte[] referenceImage)
        {
            OrderItems orderItems = ItemFactory.Singleton.GetItemTypes(OrderType.Sword, name, quantity, referenceImage);
            orderItemsList.Add(orderItems);
        }

        public void createArmour(string name, int quantity, byte[] referenceImage)
        {
            OrderItems orderItems = ItemFactory.Singleton.GetItemTypes(OrderType.Armour, name, quantity, referenceImage);
            orderItemsList.Add(orderItems);
        }

        public void createCeremonialSword(string name, int quantity, byte[] referenceImage)
        {
            OrderItems orderItems = ItemFactory.Singleton.GetItemTypes(OrderType.CeremonialSword, name, quantity, referenceImage);
            orderItemsList.Add(orderItems);
        }
        #endregion

        #region "Code used for the orderItemsList (count, get, calc)"
        //primarly useful for testing
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
                minTime += getItemInOrder(i).GetMinTime() * getItemInOrder(i).GetQuantity();
                maxTime += getItemInOrder(i).GetMaxTime() * getItemInOrder(i).GetQuantity();
            }
        }

        #endregion
    }
}
