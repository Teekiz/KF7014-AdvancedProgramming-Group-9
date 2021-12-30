using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using DataAccessLayer;

namespace PresentationLayer
{
    //#1 For Method UpdateFormView
    //item is (objectType) is from https://stackoverflow.com/questions/3561202/check-if-instance-is-of-a-type
    //answered by the user Jon Skeet (2010)

    public class ManagerPresenter
    {
        private IManagerModel model;
        private IOrderManager screen;
        Enquiry enquiry;
        Customer customer;
        List<OrderItems> orderItems;
        Order order;

        public ManagerPresenter(IOrderManager screen, IManagerModel model)
        {
            this.screen = screen;
            this.model = model;
            screen.register(this);
        }

        public Enquiry GetEnquiry(int EnquiryID)
        {
            return model.GetEnquiry(EnquiryID);
        }

        public Customer GetCustomer(Enquiry enquiry)
        {
           return model.GetCustomerInEnquiry(enquiry.orderID);
        }

        public List<OrderItems> GetOrderItems(Enquiry enquiry)
        {
            return model.GetItemsInEnquiry(enquiry.orderID);
        }

        public void EnquiryUpdate()
        {
            int enquId = Int32.Parse(screen.orderNumber);
            enquiry = GetEnquiry(enquId);
            customer = GetCustomer(enquiry);
            orderItems = GetOrderItems(enquiry);
            order = model.GetOrder();
            UpdateFormView(enquiry, customer, orderItems);
        }

        public void UpdateFormView(Enquiry enquiry, Customer customer, List<OrderItems> orderItems)
        {
            screen.orderNumber = enquiry.orderID.ToString();
            screen.DateReceived = enquiry.receivedDate;
            screen.customerName = customer.name;
            screen.custPhone = customer.phone;
            screen.custAddressline1 = customer.addressline1;
            screen.custAddressline2 = customer.addressline2;
            screen.custCountry = customer.country;
            screen.custType = customer.type;
            screen.deadline = enquiry.deadline;
            screen.custOrderNotes = enquiry.orderNotes;
            screen.price = enquiry.price.ToString();
            screen.timeHours = enquiry.hoursToComplete.ToString();

            //item is (objectType) is from https://stackoverflow.com/questions/3561202/check-if-instance-is-of-a-type
            //answered by the user Jon Skeet (2010)

            List<string> itemsList = new List<string>();
            foreach (OrderItems item in orderItems)
            {
                string itype = "";
                if (item is SwordItem) itype = "Sword Item";
                else if (item is ArmourItem) itype = "Armour Item";
                else itype = "Ceremonial Sword";

                string itemstring = item.description + ", " + item.quantity + ", " + itype + ".";
                itemsList.Add(itemstring);
            }
            screen.orderItemListView(itemsList);
        }

        //While the button will say save, all it does is update the query.
        public void SaveUpdateEnquiry()
        {
            double price = Double.Parse(screen.price);
            int hours = Int32.Parse(screen.timeHours);
            if (model.PriceHoursCheck(price, hours, orderItems) == true && model.CheckIfDeadlineIsFeasible(hours, screen.startDate,screen.deadline) == true)
            {
                if ((model.CheckSchedule(screen.startDate, screen.deadline) == true) || (model.CheckSchedule(screen.startDate, screen.deadline) == false) && (model.canOrderBeMoved(order, customer) is null))
                {
                    enquiry.price = price;
                    enquiry.hoursToComplete = hours;
                    model.UpdateEnquiry(enquiry);

                    order.scheduledStartDate = screen.startDate;
                    order.confirmedDeadline = screen.deadline;
                    model.SaveOrder(order, enquiry);
                }
            }
        }
    }
}
