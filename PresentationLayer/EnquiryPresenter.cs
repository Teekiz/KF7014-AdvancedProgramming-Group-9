using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using DataAccessLayer;

//Developed by Lewis Barton and Callum Rossiter.
//Handles data for the Customer Form.
//Identifies if the required forms are filled, if not, notify the user of this.
//If all forms are filled then pass data into the database, create new enquiry.

namespace PresentationLayer
{
    public class EnquiryPresenter
    {
        private IEnquiryModel enqiryModel;
        private IOrderCust screen;
        Customer c;
        Enquiry e;
        List<OrderItems> oi;

        public EnquiryPresenter(IOrderCust screen, IEnquiryModel enqiryModel)
        {
            this.screen = screen;
            this.enqiryModel = enqiryModel;
            screen.register(this);
            c = new Customer();
            e = new Enquiry();
            oi = new List<OrderItems>();
        }

        //If required info is missing in the form, display message informing user to enter this data.
        public void missingInfo(string missingVariable)
        {
            System.Windows.Forms.MessageBox.Show("NOTICE - You must fill in the " + missingVariable + " to continue");

        }
        //Checks if required forms are blank. If so, notify user. If not, create query.
        public void saveEnquiry()
        {
            
            if (screen.name == "")
            { missingInfo("name"); }
            else if (screen.addressline1 == "")
            { missingInfo("address"); }
            else if (screen.county == "")
            { missingInfo("county"); }
            else if (screen.country == "")
            { missingInfo("country"); }
            else if (screen.townCity == "")
            { missingInfo("town/City"); }
            else if (screen.postcode == "")
            { missingInfo("postcode"); }
            else if (screen.phone == "")
            { missingInfo("phone"); }
            else if (screen.termsChecked() != true)
            { missingInfo("terms and conditions"); }
            else if (screen.getRadioButton() == null)
            { missingInfo("customer type"); }
            else if ((screen.CerimonialSwordChecked() == false) && (screen.SwordChecked() == false) && (screen.ArmourChecked() == false))
            {
                System.Windows.Forms.MessageBox.Show("You must select an item to purchase");
            }
            else if ((screen.itemQuant1 == "") && (screen.itemQuant2 == "") && (screen.itemQuant3 == ""))
            { 
                System.Windows.Forms.MessageBox.Show("You must enter the quantity of the item"); 
            }
            else if ((screen.CerimonialSwordChecked() == true) && (screen.itemQuant1 ==""))
            {
                System.Windows.Forms.MessageBox.Show("You must enter the quantity of the item");
            }
            else if ((screen.SwordChecked() == true) && (screen.itemQuant2 == ""))
            {
                System.Windows.Forms.MessageBox.Show("You must enter the quantity of the item");
            }
            else if ((screen.ArmourChecked() == true) && (screen.itemQuant3 == ""))
            {
                System.Windows.Forms.MessageBox.Show("You must enter the quantity of the item");
            }
            
            else if ((screen.name != "") && (screen.addressline1 != "") && (screen.county != "") && (screen.country != "") && (screen.townCity != "") && (screen.postcode != "") && (screen.phone != "") && (screen.termsChecked() == true) && (screen.getRadioButton() != null))
            {
                c.name = screen.name;
                c.addressline1 = screen.addressline1;
                c.county = screen.county;
                c.country = screen.country;
                c.townCity = screen.townCity;
                c.postcode = screen.postcode;
                c.phone = screen.phone;
                c.birthdate = screen.birthdate;
                c.addressline2 = screen.addressline2;
                c.type = screen.getRadioButton();

                e.receivedDate = DateTime.Now;
                e.deadline = screen.deadline;
                e.orderNotes = screen.orderNotes;                
                
                //Checks for items checked on the form (swords and/or armour) If found, save enquiry.
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

                System.Windows.Forms.MessageBox.Show("Request Proccessed Successfully");

                
            }
          
        }
    }
}
