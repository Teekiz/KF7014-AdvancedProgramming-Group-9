using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    /*
    Credit/References:

    #1 Image to Byte[] (Under class OrderItems): -
    Taken from user answer nima at https://stackoverflow.com/questions/4653095/how-to-store-images-using-entity-framework-code-first-ctp-5
    User suggested switching using byte array. my idea for referenceImage was to set as an Image class before suggestion. Used this code and the database accepted it.
    */

    public class Enquiry
    {
        public Enquiry()
        {
            orderItemsList = new List<OrderItems>();
        }

        [Key]
        public int orderID { get; set; }
        public DateTime receivedDate { get; set; }
        public DateTime deadline { get; set; }
        public double price { get; set; }
        public int hoursToComplete { get; set; }
        public string orderStatus { get; set; }
        public string orderNotes { get; set; }
        public string itemDesc1 { get; set; }
        public string itemDesc2 { get; set; }
        public string itemDesc3 { get; set; }
        public string itemQuant1 { get; set; }
        public string itemQuant2 { get; set; }
        public string itemQuant3 { get; set; }
        //[Required, ForeignKey("orderID")]
        //[Required]

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItems> orderItemsList { get; set; }
    }

    public class OrderItems
    {
        public OrderItems() {}

        [Key]
        public int itemID { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        //referenceImage is optional for the user - this code was modified based on stack overflow (#1).
        public byte[] referenceImage { get; set; }
        [NotMapped]
        public int maxTime { get; set; }
        [NotMapped]
        public int minTime { get; set; }
        [NotMapped]
        public double minCost { get; set; }
        [NotMapped]
        public double maxCost { get; set; }
        public virtual Enquiry Enquiry { get; set; }

        public void getItemTime(out int minCalcTime, out int maxCalcTime)
        {
            minCalcTime = minTime * quantity;
            maxCalcTime = maxTime * quantity;
        }
    }

    public class SwordItem : OrderItems
    {
        public SwordItem()
        {
           minTime = 80;
           maxTime = 120;
           minCost = 2000.00;
           maxCost = 10000.00;
        }
    }

    public class ArmourItem : OrderItems
    {
        public ArmourItem()
        {
            minTime = 80;
            maxTime = 300;
            minCost = 2000.00;
            maxCost = 10000.00;
        }
    }

    public class CeremonialSwordItem : OrderItems
    {
        public CeremonialSwordItem()
        {
            minTime = 20;
            maxTime = 30;
            minCost = 50.00;
            maxCost = 1000.00;
        }
    }

    public class Order
    {
        public Order() { }

        [Key]
        public int orderID { get; set; }
        public DateTime scheduledStartDate { get; set; }
        public int progressCompleted { get; set; }
        public virtual Enquiry Enquiry { get; set; }
    }

    public class Customer
    {
        public Customer() { }

        [Key]
        public int customerID { get; set; }
        public string name { get; set; }
        public string addressline1 { get; set; }
        public string phone { get; set; }
        public string addressline2 { get; set; }
        public DateTime birthdate { get; set; }
        public string postcode { get; set; }
        public string townCity { get; set; }
        public string county { get; set; }
        public string country { get; set; }
        public string type { get; set; }
        //public virtual Enquiry Enquiry { get; set; }
    }
    public class Staff
    {
        public Staff() {}

        [Key]
        public int staffId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int workinghours { get; set; }
        public string addressId { get; set; }
        //public virtual Enquiry Enquiry {get;set}
    }
}
