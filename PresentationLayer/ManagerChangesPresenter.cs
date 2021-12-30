using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using DataAccessLayer;

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
                //do nothing, the screen values just won't update.
            }
        }

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
                screen.closeScreen();
            }
        }
    }
}
