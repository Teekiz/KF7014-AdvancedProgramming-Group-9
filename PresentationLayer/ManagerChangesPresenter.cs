using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using DataAccessLayer;

//Developed by Lewis Barton and Callum Rossiter.
//Data handling for ManagerChange form. Attempt to replace the start date and deadline of a conflicting order.

namespace PresentationLayer
{
    public class ManagerChangesPresenter
    {
        IOrderManagerChanges screen;
        IManagerModel model;
        Order conflictingOrder;
        Order existingOrder;
        List<Order> ordersToChange;
        Enquiry enquiryUsedToSave;
        int hours = 0;

        public ManagerChangesPresenter(IOrderManagerChanges screen, IManagerModel model, int hours, List<Order> ordersToChange, Enquiry enquiry)
        {
            this.screen = screen;
            this.model = model;
            this.hours = hours;
            this.ordersToChange = ordersToChange;
            this.enquiryUsedToSave = enquiry;
            screen.register(this);
            loadScreenValues();
        }

        //Try to load information for both the existing order and the conflicting order.
        //If not possible, notify user of the failure.
        public void loadScreenValues()
        {
            try
            {
                existingOrder = ordersToChange[0];
                conflictingOrder = ordersToChange[1];

                screen.existingOrderNumber = existingOrder.orderID.ToString(); //order to be replaced
                screen.existingStartDate = existingOrder.scheduledStartDate; //order to be replaced
                screen.existingDeadline = existingOrder.confirmedDeadline; //order to be replaced

                screen.conflictOrderNumber = conflictingOrder.orderID.ToString(); //order to be replaced
                screen.conflictStartDate = conflictingOrder.scheduledStartDate; //order to be replaced
                screen.conflictDeadline = conflictingOrder.confirmedDeadline; //order to be replaced
            }
            catch 
            {
                //do nothing, the screen values just won't update. EDIT (Lewis) - Use System boxes instead!
                System.Windows.Forms.MessageBox.Show("NOTICE - Changes not made!");
            }
        }

        //If the selected changes to the deadline are identified to be feasable, Push changes into database.
        public void saveChanges()
        {
            conflictingOrder.scheduledStartDate = screen.conflictStartDate;
            conflictingOrder.confirmedDeadline = screen.conflictDeadline;

            existingOrder.scheduledStartDate = screen.existingStartDate;
            existingOrder.confirmedDeadline = screen.existingDeadline;
            int enqid = model.GetEnquiryInOrder(existingOrder);
            int existingOrderHours = model.GetEnquiry(enqid).hoursToComplete;

            if (model.CheckIfDeadlineIsFeasible(hours, conflictingOrder.scheduledStartDate, conflictingOrder.confirmedDeadline) == true
                && model.CheckIfDeadlineIsFeasible(existingOrderHours, existingOrder.scheduledStartDate, existingOrder.confirmedDeadline) == true)
            {
                model.SaveOrder(conflictingOrder, enquiryUsedToSave);
                model.UpdateOrder(existingOrder);
                System.Windows.Forms.MessageBox.Show("NOTICE - Changes have been made!");
                screen.closeScreen();
            }
        }
    }
}
