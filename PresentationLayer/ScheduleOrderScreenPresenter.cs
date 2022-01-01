using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainLayer;

namespace PresentationLayer
{
    //#1 For Method UpdateFormView
    //item is (objectType) is from https://stackoverflow.com/questions/3561202/check-if-instance-is-of-a-type
    //answered by the user Jon Skeet (2010)

    public class ScheduleOrderScreenPresenter
    {
        private IScheduleModel model;
        private IScheduleOrderScreen screen;
        Order order;
        Enquiry enquiry;
        List<OrderItems> orderItems;

        public ScheduleOrderScreenPresenter(IScheduleOrderScreen screen, IScheduleModel model, Order order, Enquiry enquiry, List<OrderItems> orderItems)
        {
            this.screen = screen;
            this.model = model;
            this.order = order;
            this.enquiry = enquiry;
            this.orderItems = orderItems;

            screen.register(this);
            loadScreenData();
        }

        public void loadScreenData()
        {
            screen.orderNotes = enquiry.orderNotes;
            screen.progressCompleted = order.progressCompleted.ToString();

            //item is (objectType) is from https://stackoverflow.com/questions/3561202/check-if-instance-is-of-a-type
            //answered by the user Jon Skeet (2010)

            foreach (OrderItems item in orderItems)
            {
                string itype = "";
                if (item is SwordItem) itype = "Sword Item";
                else if (item is ArmourItem) itype = "Armour Item";
                else itype = "Ceremonial Sword";

                string itemdescription = "Description: " + item.description;
                string itemstring =  "Quantity: " + item.quantity + ". Type of item: " + itype + ".";
                screen.orderItemsList = itemdescription;
                screen.orderItemsList = itemstring;
                screen.orderItemsList = " "; //add a space between each item
            }
        }
        public void updateOrder()
        {
            //takes the progress completed from the screen.
            int progressCompleted = 0;
            try { progressCompleted = Int32.Parse(screen.progressCompleted); }  
            catch{ } //default is 0

            if (progressCompleted < 0 || progressCompleted > 100) { }
            else 
            { 
                //update the database
                order.progressCompleted = progressCompleted;
                model.updateOrder(order);
            }
            
        }
    }
}
