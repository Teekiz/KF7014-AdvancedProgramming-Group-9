using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using DataAccessLayer;

namespace PresentationLayer

{
   /*
    public class SchedulePresenter
    {
        private IScheduleModel ScheduleModel;
        private IgetOrderDetails screen;
        Schedule Schedule;
        Customer customerorderdetails;
        List<OrderItems> orderItems;
        Order order;

        public SchedulePresenter(IgetOrderDetails screen, IScheduleModel Schedule)
        {
            this.screen = screen;
            this.Schedule = Schedule;
            screen.register(this);
        }

        public Schedule GetSchedule(int ScheduleID)
        {
            return Schedule.GetSchedule(ScheduleID);
        }

        public Customer GetCustomer(ScheduleID Schedule)
        {
            return Schedule.GetCustomerInSchedule(Schedule.orderID);
        }

        public List<OrderItems> GetOrderItems(Schedule Schedule)
        {
            return Schedule.GetItemsInSchedule(Schedule.orderID);
        }

        public void Schedule_load()
        {
            int ScheId = Int32.Parse(screen.orderNumber);
            Schedule = GetSchedule(ScheId);
            customerorderdetails = GetCustomer(Schedule);
            orderItems = GetOrderItems(Schedule);
            order = Schedule.GetOrder();
            UpdateFormView(Schedule, customerorderdetails, orderItems);
        }

        public void UpdateFormView(Schedule Schedule, Customer customerorderdetails, List<OrderItems> orderItems)
        {
            screen.orderNumber = Schedule.orderID.ToString();
            screen.DateReceived = Schedule.receivedDate;
            screen.customerName = customerorderdetails.name;
            screen.custPhone = customerorderdetails.phone;
            screen.custAddressline1 = customerorderdetails.addressline1;
            screen.custAddressline2 = customerorderdetails.addressline2;
            screen.custCountry = customerorderdetails.country;
            screen.custType = customerorderdetails.type;
            screen.deadline = Schedule.deadline;
            screen.custOrderNotes = Schedule.orderNotes;
            screen.price = Schedule.price.ToString();
            screen.timeHours = Schedule.hoursToComplete.ToString();

           

            List<string> itemsList = new List<string>();
            foreach (OrderItems item in orderItems)
            {
                string itype = "full order details and types ";
                if (item is SwordItem) itype = "Sword Item";
                else if (item is ArmourItem) itype = "Armour Item";
                else itype = "Ceremonial Sword";

                string itemstring = item.description + ", " + item.quantity + ", " + itype + ".";
                itemsList.Add(itemstring);
            }
            screen.orderItemListView(itemsList);
        }

        public void SaveUpdateonSchedule()
        {
            double orderID = Double.Parse(screen.orderID);
            int days = Int32.Parse(screen.timedays);
            if (Schedule.orderdaysCheck(orderID, days, orderItems) == true && Schedule.CheckIfDeadlineIsFeasible(days, screen.startDate,screen.deadline) == true)
            {
                if ((Schedule.CheckSchedule(screen.startDate, screen.deadline) == true) || (Schedule.CheckSchedule(screen.startDate, screen.deadline) == false) && (model.canOrderBeMoved(order, customerorderdetails) is null))
                {
                    Schedule.orderID = orderID;
                    Schedule.daysToComplete = days;
                    Schedule.UpdateSchedule(Schedule);

                    order.scheduledStartDate = screen.startDate;
                    order.confirmedDeadline = screen.deadline;
                    Schedule.SaveOrder(order, Schedule);
                }
                
                public IEnumerable<DateTime> GenerateDates(DateTime start, DateTime end)
                   {
                 var dates = new List<DateTime>();

                  var date = new DateTime(start.Year, start.Month, start.Day);
                while (date.Month <= end.Month && date.Year <= end.Year)
                 {
           date = date.Add1Months(1);
               dates.Add(date);
                 }

              return dates;
                 } 
            }
        }

 
    }

    */
}
