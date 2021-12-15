using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using DataAccessLayer;

namespace PresentationLayer
{
    public class Presentation
    {
        private ICustomerModel customerModel;
        private IEnquiryModel enqiryModel;
        private IOrderCust screen;
        Customer Customer;
        Enquiry Enquiry;

        public Presentation(ICustomerModel model, IOrderCust screen, IEnquiryModel enqiryModel)
        {
            customerModel = model;
            this.screen = screen;
            this.enqiryModel = enqiryModel;
            screen.register(this);
            Customer = customerModel.GetCustomer();
        }

        public Customer createCustomer()
        {
            Customer.name = screen.name;
            Customer.addressline1 = screen.addressline1;
            Customer.county = screen.county;
            Customer.country = screen.country;
            Customer.townCity = screen.townCity;
            Customer.birthdate = screen.birthdate;
            Customer.addressline2 = screen.addressline2;
            Customer.postcode = screen.postcode;
            Customer.phone = screen.phone;
            Customer.type = screen.getRadioButton();
           

            return Customer;
        }
        
        public Enquiry createEnquiry()
        {
            Enquiry.orderNotes = screen.orderNotes;

            return Enquiry;
        } 

        public void saveEnquiry()
        {
            Enquiry e = new Enquiry();
            e.receivedDate = DateTime.Now;
            e.deadline = screen.deadline;
            e.orderNotes = screen.orderNotes;
            enqiryModel.SaveEnquiry(e);
        }

        public void saveCustomer()
        {
            Customer c = new Customer();
            c.name = screen.name;
            c.addressline1 = screen.addressline1;
            c.county = screen.county;
            c.country = screen.country;
            c.townCity = screen.townCity;
            c.birthdate = screen.birthdate;
            c.addressline2 = screen.addressline2;
            c.postcode = screen.postcode;
            c.phone = screen.phone;
            c.type = screen.getRadioButton();
            
            customerModel.SaveCustomer(c);
        }
    }
}
