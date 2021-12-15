using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    /*
    Credit/References:

    #1 Image to Byte[]: -
    Taken from user answer nima at https://stackoverflow.com/questions/4653095/how-to-store-images-using-entity-framework-code-first-ctp-5
    User suggested switching using byte array. referenceImage was set as Image class before suggestion. Used this code and the database accepted it.
    */

    public class Enquiry
    {
        [Key]
        public int orderID { get; set; }
        public DateTime receivedDate { get; set; }
        public DateTime deadline { get; set; }
        public string orderStatus { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItems> orderItemsList { get; set; }
    }

    public class OrderItems
    {
        [Key]
        public int itemID { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int quantity { get; set; }
        //referenceImage is optional for the user - this code was modified based on stack overflow (#1).
        public byte[] referenceImage { get; set; }
        [Required]
        public virtual Enquiry Enquiry { get; set; }
    }

    public class Customer
    {
        [Key]
        public int customerID { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string postcode { get; set; }
        public string townCity { get; set; }
        public string stateCounty { get; set; }
        public string country { get; set; }
        public string type { get; set; }
        //public virtual Enquiry Enquiry { get; set; }
    }
}
