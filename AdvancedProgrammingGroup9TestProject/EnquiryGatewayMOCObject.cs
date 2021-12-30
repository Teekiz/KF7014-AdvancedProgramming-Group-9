using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace AdvancedProgrammingGroup9TestProject
{
    public class EnquiryGatewayMOCObject : IEnquiryGateway
    {
        public Enquiry storedEnquiry;
        public List<Customer> allcustomers;

        public EnquiryGatewayMOCObject()
        {
            storedEnquiry = new Enquiry();
            storedEnquiry.orderNotes = "Order notes";
            storedEnquiry.receivedDate = DateTime.Now;
            storedEnquiry.deadline = DateTime.Now.AddDays(20);
        }

        public bool SaveEnquiryAll(Enquiry enquiry, List<OrderItems> orderItems, Customer customer)
        {
            return true;
        }

        public bool DeleteAllEnquiries()
        {
            return true;
        }

        public bool DeleteEnquiry(int id)
        {
            return true;
        }

        public int FindCustomerIDinEnquiry(Enquiry enquiry)
        {
            return 1;
        }


        public List<Enquiry> GetAllEnquiries()
        {
            List<Enquiry> enqlist = new List<Enquiry>();
            enqlist.Add(storedEnquiry);
            return enqlist;
        }

        public Enquiry GetEnquiry(int id)
        {
            return storedEnquiry;
        }

        public bool SaveEnquiry(Enquiry enquiry, Customer customer)
        {
            storedEnquiry = enquiry;
            return true;
        }

        public bool UpdateEnquiry(Enquiry enquiry)
        {
            return true;
        }
    }
}
