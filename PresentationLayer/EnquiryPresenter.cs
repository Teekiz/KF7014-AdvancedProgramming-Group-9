using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using DataAccessLayer;

namespace PresentationLayer
{
    public class EnquiryPresenter
    {
        private IEnquiryModel enqiryModel;
        private IOrderCust screen;

        public EnquiryPresenter(IOrderCust screen, IEnquiryModel enqiryModel)
        {
            this.screen = screen;
            this.enqiryModel = enqiryModel;
            screen.register(this);
        }

        public void missingInfo(string missingVariable)
        {
            System.Windows.Forms.MessageBox.Show("Please ensure the " + missingVariable + " field is filled in correctly");
        }

        public void saveEnquiry()
        {
            Customer c = enqiryModel.GetCustomer();
            if (screen.name == "I") { c.name = screen.name; } else { missingInfo("name"); }
            if (screen.addressline1 == "") { c.addressline1 = screen.addressline1; } else { missingInfo("address"); }
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
            List<OrderItems> oi = new List<OrderItems>();

            if (screen.CerimonialSwordChecked() == true)
            {
                int quan1 = Int32.Parse(screen.itemQuant1);
                oi.Add(enqiryModel.createItem(screen.itemDesc1, quan1, null, OrderType.CeremonialSword));
            }

            if (screen.SwordChecked() == true)
            {
                int quan2 = Int32.Parse(screen.itemQuant2);
                oi.Add(enqiryModel.createItem(screen.itemDesc2, quan2, null, OrderType.Sword));
            }

            if (screen.ArmourChecked() == true)
            {
                int quan3 = Int32.Parse(screen.itemQuant3);
                oi.Add(enqiryModel.createItem(screen.itemQuant3, quan3, null, OrderType.Armour));
            }

            enqiryModel.SaveEnquiry(e, c, oi);
        }
    }
}
