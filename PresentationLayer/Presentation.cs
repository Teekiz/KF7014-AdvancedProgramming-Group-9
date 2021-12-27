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
        private IEnquiryModel enqiryModel;
        private IOrderCust screen;
        Customer Customer;
        Enquiry Enquiry;

        public Presentation(IOrderCust screen, IEnquiryModel enqiryModel)
        {
            this.screen = screen;
            this.enqiryModel = enqiryModel;
            screen.register(this);
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
            Enquiry.itemDesc1 = screen.itemDesc1;
            Enquiry.itemDesc2 = screen.itemDesc2;
            Enquiry.itemDesc3 = screen.itemDesc3;
            Enquiry.itemQuant1 = screen.itemQuant1;
            Enquiry.itemQuant2 = screen.itemQuant2;
            Enquiry.itemQuant3 = screen.itemQuant3;
            return Enquiry;
        }

        public void saveEnquiry()
        {
            Customer c = enqiryModel.GetCustomer();
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


            Enquiry e = enqiryModel.GetEnquiry();
            e.receivedDate = DateTime.Now;
            e.deadline = screen.deadline;
            e.orderNotes = screen.orderNotes;
            e.itemDesc1 = screen.itemDesc1;
            e.itemDesc2 = screen.itemDesc2;
            e.itemDesc3 = screen.itemDesc3;
            e.itemQuant1 = screen.itemQuant1;
            e.itemQuant2 = screen.itemQuant2;
            e.itemQuant3 = screen.itemQuant3;
            List<OrderItems> oi = new List<OrderItems>();

            oi.Add(enqiryModel.createItem("Sword Sword", 2, null, OrderType.Sword));
            oi.Add(enqiryModel.createItem("Ar Sword", 10, null, OrderType.Armour));

            enqiryModel.SaveEnquiry(e, c, oi);
        }

        public void saveCustomer()
        {
            /*
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
            */
        }
    }
}
