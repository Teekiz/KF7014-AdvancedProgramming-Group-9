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
            populateComboBox();

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

        public void populateComboBox()
        {
            foreach (Enquiry enquiry in model.GetEnquiries())
            {
                screen.orderNumber = enquiry.orderID.ToString();
            }          
        }

        public void EnquiryUpdate()
        {
            int enquId;
            bool parse = int.TryParse(screen.orderNumber, out enquId);

            if (parse != true) { }
            else 
            {
                enquiry = GetEnquiry(enquId);
                customer = GetCustomer(enquiry);
                orderItems = GetOrderItems(enquiry);
                order = GetOrder(enquiry);

                UpdateFormView(enquiry, customer, orderItems, order);
            }
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
                if (model.DoesOrderExist(enquiry) != null) 
                { 
                    order = model.DoesOrderExist(enquiry);
                    screen.startDate = order.scheduledStartDate;
                    screen.confirmedDeadline = order.confirmedDeadline;
                }
     
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
                //if the order exists, set to true, update, else save ().
                if (model.DoesOrderExist(enquiry) is null) { order = new Order(); order.orderID = 0; }

                double price = Double.Parse(screen.price);
                int hours = Int32.Parse(screen.timeHours);
                order.scheduledStartDate = screen.startDate;
                order.confirmedDeadline = screen.confirmedDeadline;
                enquiry.price = price;
                enquiry.hoursToComplete = hours;

                
                //as long as the price and hours is reasonable and if the deadline is feasible
                if (model.PriceHoursCheck(price, hours, orderItems) == true && model.CheckIfDeadlineIsFeasible(hours, screen.startDate, screen.confirmedDeadline) == true)
                {
                    if (screen.acceptOrderRadioButton() == false) { model.UpdateEnquiry(enquiry); System.Windows.Forms.MessageBox.Show("NOTICE - Enquiry Updated! - Awaiting Customer Confirmation to Create Order."); }

                    //to update the enquiry, also means that it doesn't need to run more than once
                    List<Order> canBeMovedOrders = model.canOrderBeMoved(order, customer);
                    //if the schedule is clear or if the it is not clear but the order conflicting it is able to be moved.
  
                    //if it is the same order
                    if (canBeMovedOrders.Count() == 2 && canBeMovedOrders[0].orderID == order.orderID)
                    {
                        //if it is within the same slot
                        if (order.scheduledStartDate >= canBeMovedOrders[0].scheduledStartDate && order.confirmedDeadline <= canBeMovedOrders[0].confirmedDeadline)
                        {
                            model.UpdateEnquiry(enquiry);
                            model.UpdateOrder(order);
                            System.Windows.Forms.MessageBox.Show("NOTICE - Enquiry Updated!");
                        }
                    }

                    else if (model.CheckSchedule(screen.startDate, screen.confirmedDeadline) == true)
                    {
                        model.UpdateEnquiry(enquiry);
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
