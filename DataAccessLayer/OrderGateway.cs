using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IOrderGateway
    {
        bool SaveOrder(Order order);
        bool UpdateOrder(Order order);
        int FindEnquiryIDinOrder(Order order);
        List<Order> GetAllOrders();
        Order GetOrder(int id);
        bool DeleteOrder(int order);
        bool DeleteAllOrders();
    }

    //Created by Ian Kenny, some updates (and design pattern implementation) made by Callum Rossiter

    //1) For this method I used the answer by the user Slauma (2013)
    //https://stackoverflow.com/questions/20710178/entity-framework-creates-new-duplicate-entries-for-associated-objects
    //using it for context.Enquiries.Attach(order.Enquiry); to fix duplication issues

    //2) I used the website entityframeworktutorial to understand eager loading
    //https://www.entityframeworktutorial.net/eager-loading-in-entity-framework.aspx
    //this was to find the enquiry id in orders, due to the lateness in the project, this is only used in this method
    //however, I would've used this method more often.

    //3) Some of this code is based on https://docs.microsoft.com/en-us/ef/core/querying/ for the get methods
    //I've put this in the methods relevent

    //4) reformated to use simple thread-saftey - this code mostly comes from
    //C# in Depth "Implementing the Singleton Pattern in C#" https://csharpindepth.com/articles/singleton
    //it has been changed from the version found in the presentation (week 6).

    //the explanation for using the singleton pattern for the gateways is because there only needs to be one instance of these
    //while the program will at some point need all the gateways, it doesn't make sense to create multiple versions of these objects.

    public sealed class OrderGateway : IOrderGateway
    {
        //Design Pattern implemented by Callum Rossiter
        //Copied from URL: https://csharpindepth.com/articles/singleton
        //code for reference 4
        private static OrderGateway instance = null;
        private static readonly object padlock = new object();
        OrderGateway() { }

        public static OrderGateway Instance
        {
            get { lock (padlock) { if (instance == null) { instance = new OrderGateway(); } return instance; } }
        }
        //reference 4 ends here.

        //Method for 1) reference - Updated by Callum Rossiter
        //Copied from URL: https://stackoverflow.com/questions/20710178/entity-framework-creates-new-duplicate-entries-for-associated-objects
        public bool SaveOrder(Order order)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    context.Enquiries.Attach(order.Enquiry);
                    context.Orders.Add(order);
                    context.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

        //Created by - Ian Kenny
        public Order GetOrder(int id)
        {
            try
            {
                //Copied from URL: https://docs.microsoft.com/en-us/ef/core/querying/
                using (var context = new DatabaseEntities())
                {
                    var OrderQuery = context.Orders.Where(o => o.orderID == id).SingleOrDefault();
                    return OrderQuery;
                }
            }

            catch { return null; }
        }

        //Created by - Ian Kenny
        public bool UpdateOrder(Order order)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    //Copied from URL: https://docs.microsoft.com/en-us/ef/core/querying/
                    var orderQuery = context.Orders.Where(o => o.orderID == order.orderID).SingleOrDefault();
                    orderQuery.scheduledStartDate = order.scheduledStartDate;
                    orderQuery.confirmedDeadline = order.confirmedDeadline;
                    orderQuery.progressCompleted = order.progressCompleted;
                    context.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

        //Created by - Ian Kenny
        public List<Order> GetAllOrders()
        {
            try
            {
                //Copied from URL: https://docs.microsoft.com/en-us/ef/core/querying/
                using (var context = new DatabaseEntities())
                {
                    var OrderQuery = context.Orders.ToList();
                    return OrderQuery;
                }
            }
            catch
            { return null; }
        }

        //Method for 2) reference -  //Created by - Ian Kenny, updated by Callum Rossiter
        public int FindEnquiryIDinOrder(Order order)
        {
            try
            {
                //Copied from URL: https://docs.microsoft.com/en-us/ef/core/querying/
                using (var context = new DatabaseEntities())
                {
                    var OrderQuery = context.Orders.Include("Enquiry").Where(o => o.orderID == order.orderID).SingleOrDefault();
                    return OrderQuery.Enquiry.orderID;
                }
            }
            catch
            { return 0; }
        }

        //Created by - Ian Kenny
        public bool DeleteOrder(int order)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var OrderGetQuery = context.Orders.Where(o => o.orderID == order).SingleOrDefault();
                    var OrderQuery = context.Orders.Remove(OrderGetQuery);
                    context.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

        //Created by - Ian Kenny
        public bool DeleteAllOrders()
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var OrderGetQuery = context.Orders.ToList();

                    foreach (Order o in OrderGetQuery)
                    {
                        context.Orders.Remove(o);
                        context.SaveChanges();
                    }

                    context.SaveChanges();

                    var newOrderGetQuery = context.Orders.ToList();
                    if (newOrderGetQuery.Count() == 0)
                    {
                        return true;
                    }

                    return false;
                }
            }

            catch { return false; }
        }
    }
}

