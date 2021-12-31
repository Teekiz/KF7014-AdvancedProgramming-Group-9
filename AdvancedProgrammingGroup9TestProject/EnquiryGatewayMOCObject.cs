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
        List<Enquiry> enqlist;

        public EnquiryGatewayMOCObject()
        {
            enqlist = new List<Enquiry>();

            storedEnquiry = new Enquiry();
            storedEnquiry.orderID = 1;
            storedEnquiry.orderNotes = "Order notes";
            storedEnquiry.receivedDate = new DateTime(2020/20/12);
            storedEnquiry.deadline = new DateTime(2020/30/12);
            enqlist.Add(storedEnquiry);


            Customer customer2 = new Customer();
            customer2.customerID = 2;
            Enquiry enquiry2 = new Enquiry();
            enquiry2.orderID = 2;
            enquiry2.hoursToComplete = 20;
            enquiry2.Customer = customer2;
            enqlist.Add(enquiry2);

            Customer customer3 = new Customer();
            customer3.customerID = 3;
            Enquiry enquiry3 = new Enquiry();
            enquiry3.orderID = 3;
            enquiry3.hoursToComplete = 20;
            enquiry3.Customer = customer3;
            enqlist.Add(enquiry3);

            Customer customer4 = new Customer();
            customer4.customerID = 4;
            Enquiry enquiry4 = new Enquiry();
            enquiry4.orderID = 4;
            enquiry4.hoursToComplete = 20;
            enquiry4.Customer = customer4;
            enqlist.Add(enquiry4);

            Customer customer5 = new Customer();
            customer5.customerID = 5;
            Enquiry enquiry5 = new Enquiry();
            enquiry5.orderID = 5;
            enquiry5.hoursToComplete = 20;
            enquiry5.Customer = customer5;
            enqlist.Add(enquiry5);

            Customer customer6 = new Customer();
            customer6.customerID = 6;
            Enquiry enquiry6 = new Enquiry();
            enquiry6.orderID = 6;
            enquiry6.hoursToComplete = 200;
            enquiry6.Customer = customer6;
            enqlist.Add(enquiry6);

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
            foreach (Enquiry en in GetAllEnquiries()) 
            {
                if (enquiry.orderID == en.orderID) { return en.Customer.customerID; }
            } 
            return 1;
        }

        public List<Enquiry> GetAllEnquiries()
        {
            return enqlist;
        }

        public Enquiry GetEnquiry(int id)
        {
            foreach (Enquiry en in GetAllEnquiries())
            {
                if (en.orderID == id) { return en; }
            }
            return null;
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
