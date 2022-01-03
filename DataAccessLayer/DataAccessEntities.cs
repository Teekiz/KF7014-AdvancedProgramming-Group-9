using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    // Enquiry written by Callum Rossiter

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
            OrderItemsList = new List<OrderItems>();
        }

        private int OrderID;
        private DateTime ReceivedDate;
        private DateTime Deadline;
        private double Price;
        private int HoursToComplete;
        private string OrderStatus;
        private string OrderNotes;
        private Customer customer; //careful, this is inverted virtual
        private ICollection<OrderItems> OrderItemsList; //virtual

        [Key]
        public int orderID { get { return OrderID; } set { OrderID = value; } }
        public DateTime receivedDate { get { return ReceivedDate; } set { ReceivedDate = value; } }
        public DateTime deadline { get { return Deadline; } set { Deadline = value; } }
        public double price { get { return Price; } set { Price = value; } }
        public int hoursToComplete { get { return HoursToComplete; } set { HoursToComplete = value; } }
        public string orderStatus { get { return OrderStatus; } set { OrderStatus = value; } }
        public string orderNotes { get { return OrderNotes; } set { OrderNotes = value; } }
        public virtual Customer Customer { get { return customer; } set { customer = value; } }
        public virtual ICollection<OrderItems> orderItemsList { get { return OrderItemsList; } set { OrderItemsList = value; } }
    }

    // Order Items written by Callum Rossiter
    public abstract class OrderItems //changed to an abstract class
    {
        public OrderItems() {}

        private int ItemID;
        private string Description;
        private int Quantity;
        private byte[] ReferenceImage; //referenceImage is optional for the user - this code was modified based on stack overflow (#1).
        private int MaxTime;
        private int MinTime;
        private double MinCost;
        private double MaxCost;
        private Enquiry enquiry;

        [Key]
        public int itemID { get { return ItemID; } set { ItemID = value; } }
        public string description { get { return Description; } set { Description = value; } }
        public int quantity { get { return Quantity; } set { Quantity = value; } }
        public byte[] referenceImage { get { return ReferenceImage; } set { ReferenceImage = value; } }
        [NotMapped]
        public int maxTime { get { return MaxTime; } set { MaxTime = value; } }
        [NotMapped]
        public int minTime { get { return MinTime; } set { MinTime = value; } }
        [NotMapped]
        public double minCost { get { return MinCost; } set { MinCost = value; } }
        [NotMapped]
        public double maxCost { get { return MaxCost; } set { MaxCost = value; } }
        public virtual Enquiry Enquiry { get { return enquiry; } set { enquiry = value; } }

        public void getItemTime(out int minCalcTime, out int maxCalcTime)
        {
            minCalcTime = minTime * quantity;
            maxCalcTime = maxTime * quantity;
        }

        public void getItemCost(out double minCalcCost, out double maxCalcCost)
        {
            minCalcCost = minCost * Convert.ToDouble(quantity);
            maxCalcCost = maxCost * Convert.ToDouble(quantity);
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

    // Order written by Callum Rossiter

    public class Order
    {
        public Order() { }

        private int OrderID;
        private DateTime ScheduledStartDate;
        private DateTime ConfirmedDeadline;
        private int ProgressCompleted;
        private Enquiry enquiry;

        [Key]
        public int orderID { get { return OrderID; } set { OrderID = value; } }
        public DateTime scheduledStartDate { get { return ScheduledStartDate; } set { ScheduledStartDate = value; } }
        public DateTime confirmedDeadline { get { return ConfirmedDeadline; } set { ConfirmedDeadline = value; } }
        public int progressCompleted { get { return ProgressCompleted; } set { ProgressCompleted = value; } }
        public virtual Enquiry Enquiry { get { return enquiry; } set { enquiry = value; } }
    }

    //Developed by Ian Kenny
    public class Customer
    {
        public Customer() { }

        //these were previosuly public
        private int CustomerID;
        private string Name;
        private string Addressline1;
        private string Phone;
        private string Addressline2;
        private DateTime Birthdate;
        private string Postcode;
        private string TownCity;
        private string County;
        private string Country;
        private string Type;

        [Key]
        public int customerID { get { return CustomerID; } set { CustomerID = value; } }
        public string name { get { return Name; } set { Name = value; } }
        public string addressline1 { get { return Addressline1; } set { Addressline1 = value; } }
        public string addressline2 { get { return Addressline2; } set { Addressline2 = value; } }
        public string phone { get { return Phone; } set { Phone = value; } }
        public DateTime birthdate { get { return Birthdate; } set { Birthdate = value; } }
        public string postcode { get { return Postcode; } set { Postcode = value; } }
        public string townCity { get { return TownCity; } set { TownCity = value; } }
        public string county { get { return County; } set { County = value; } }
        public string country { get { return Country; } set { Country = value; } }
        public string type { get { return Type; } set { Type = value; } }
    }

    //Created by Sai Pavan Madala
    public class Staff
    {
        public Staff() {}

        private int StaffId;
        private string Firstname;
        private string Lastname;
        private string Username;
        private string Password;

        [Key]
        public int staffId { get { return StaffId; } set { StaffId = value; } }
        public string firstname { get { return Firstname; } set { Firstname = value; } }
        public string lastname { get { return Lastname; } set { Lastname = value; } }
        public string username { get { return Username; } set { Username = value; } }
        public string password { get { return Password; } set { Password = value; } }
    }
}
