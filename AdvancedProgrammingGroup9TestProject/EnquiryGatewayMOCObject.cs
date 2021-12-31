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
            storedEnquiry.orderID = 1;
            storedEnquiry.orderNotes = "Order notes";
            storedEnquiry.receivedDate = new DateTime(2020/20/12);
            storedEnquiry.deadline = new DateTime(2020/30/12);
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
            if (id == 1) { return storedEnquiry; }
            else { return null; } 
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
