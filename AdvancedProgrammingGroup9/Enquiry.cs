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
        int GetOrderID();
        DateTime GetReceivedDate();
        DateTime GetDeadline();
    }

    //Concrete Implementation
    public class Enquiry : IEnquiry
    {
        public Enquiry(int orderID, DateTime receivedDate, DateTime deadline)
        {
            this.orderID = orderID;
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
        public Customer customer;

        //this was orignally a virtual ICollection named orderItemLists
        //https://stackoverflow.com/questions/47310922/how-to-get-index-of-an-item-in-icollectiont
        public virtual IList<OrderItems> orderItemsList { get; set; }

        public int GetOrderID() { return orderID; }
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

        public int countOrderItemsList()
        {
            return orderItemsList.Count();
        }

        #endregion

        //gets the item in an order at an index, could be ran with a loop to get all
        public OrderItems getItemInOrder(int index)
        {
            try { return orderItemsList[index]; }
            catch (Exception exception) { Console.WriteLine(exception); }
            return null;
        }
    }
}
