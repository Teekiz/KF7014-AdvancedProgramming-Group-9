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

        //System message notifying user that the order number could not be found
        public void missingInfo2()
        {
            System.Windows.Forms.MessageBox.Show("NOTICE - Order Number not found!");


        }

        //Second message to notify user to try again
        public void missingInfo3()
        {
            System.Windows.Forms.MessageBox.Show("NOTICE - Please try again!");

        }


        //Checks if the order number entered is present. If not, produce system message via missingInfo2().
        //If Order number is found, return enquiry.
        public Customer GetCustomer(Enquiry enquiry)
        {
            if (enquiry is null)
            { missingInfo2(); }

            else if (model.GetCustomerInEnquiry(enquiry.orderID) != null)
            { return model.GetCustomerInEnquiry(enquiry.orderID); }
            return null;
        }

        public List<OrderItems> GetOrderItems(Enquiry enquiry)
        {
            if (enquiry is null)
            { return null; }
            else
            {
                return model.GetItemsInEnquiry(enquiry.orderID);
            }
        }

        public Order GetOrder(Enquiry enquiry)
        {
            if (enquiry is null)
            { return null; }
            else
            {
                return model.GetOrder(enquiry.orderID);
            }
        }

        public void EnquiryUpdate()
        {
            int enquId = Int32.Parse(screen.orderNumber);
            enquiry = GetEnquiry(enquId);
            customer = GetCustomer(enquiry);
            orderItems = GetOrderItems(enquiry);
            order = GetOrder(enquiry);
            
            UpdateFormView(enquiry, customer, orderItems, order);
        }

        //Check if enquiry can be found. If so, update current data.
        public void UpdateFormView(Enquiry enquiry, Customer customer, List<OrderItems> orderItems, Order order)
        {
            if (enquiry is null)
            { missingInfo3(); }
            else if (enquiry != null)
            {
                //get rid of all the existing information first.
                screen.clearItemView();

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
                screen.startDate = order.scheduledStartDate;
                screen.confirmedDeadline = order.confirmedDeadline;
                


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
        }

        //While the button will say save, all it does is update the query.
        public void SaveUpdateEnquiry()
        {
            if (enquiry is null)
            { missingInfo2(); }
            else if (enquiry != null)
            {
                order = new Order();
                double price = Double.Parse(screen.price);
                int hours = Int32.Parse(screen.timeHours);
                order.scheduledStartDate = screen.startDate;
                order.confirmedDeadline = screen.confirmedDeadline;

                //as long as the price and hours is reasonable and if the deadline is feasible
                if (model.PriceHoursCheck(price, hours, orderItems) == true && model.CheckIfDeadlineIsFeasible(hours, screen.startDate, screen.confirmedDeadline) == true)
                {
                    //to update the enquiry, also means that it doesn't need to run more than once
                    List<Order> canBeMovedOrders = model.canOrderBeMoved(order, customer);
                    //if the schedule is clear or if the it is not clear but the order conflicting it is able to be moved.
                    if (model.CheckSchedule(screen.startDate, screen.confirmedDeadline) == true)
                    {
                        enquiry.price = price;
                        enquiry.hoursToComplete = hours;
                        model.UpdateEnquiry(enquiry);
                        model.UpdateOrder(order);
                        model.SaveOrder(order, enquiry);

                        System.Windows.Forms.MessageBox.Show("NOTICE - Enquiry Updated!");

                    }

                    //if the check shedule is not clear but there is an order that can be moved
                    else if (canBeMovedOrders.Count() == 2)
                    {
                        enquiry.price = price;
                        enquiry.hoursToComplete = hours;
                        model.UpdateEnquiry(enquiry);
                        showUpdateForm(hours, canBeMovedOrders, enquiry);

                    }
                    else
                    {
                        // can't be moved
                        System.Windows.Forms.MessageBox.Show("NOTICE - Item Cannot Be Moved!");
                    }
                }
            }
        }

        public void showUpdateForm(int hours, List<Order> ordersToChange, Enquiry enquiryToUse)
        {
            EnquiryGateway enquiryGateway = EnquiryGateway.Instance;
            OrderItemGateway orderItemGateway = OrderItemGateway.Instance;
            CustomerGateway customerGateway = CustomerGateway.Instance;
            OrderGateway orderGateway = OrderGateway.Instance;

            ManagerChanges newscreen = new ManagerChanges();
            IManagerModel model = new ManagerModel(enquiryGateway, customerGateway, orderItemGateway, orderGateway);
            ManagerChangesPresenter presentation = new ManagerChangesPresenter(newscreen, model, hours, ordersToChange, enquiryToUse);
            newscreen.ShowDialog();
        }
    }
}
