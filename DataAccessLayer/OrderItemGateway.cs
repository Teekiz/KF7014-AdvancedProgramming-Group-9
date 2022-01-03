using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    //Created By Callum Rossiter
    public interface IOrderItemGateway
    {
        bool SaveOrderItems(List<OrderItems> orderItems, Enquiry enquiry);
        List<OrderItems> GetOrderItemsInEnquiry(int enquiryID);
        bool DeleteOrderItems(int id);
        bool DeleteOrderItemsInEnquiry(int id);
        bool DeleteAllOrderItems();
    }

    //1) For this method I used the answer by the user Slauma (2013)
    //https://stackoverflow.com/questions/20710178/entity-framework-creates-new-duplicate-entries-for-associated-objects
    //using it for context.Customers.Attach(enquiry.Customer); to fix duplication issues

    //2) reformated to use simple thread-saftey - this code mostly comes from
    //C# in Depth "Implementing the Singleton Pattern in C#" https://csharpindepth.com/articles/singleton
    //it has been changed from the version found in the presentation (week 6).

    //the explanation for using the singleton pattern for the gateways is because there only needs to be one instance of these
    //while the program will at some point need all the gateways, it doesn't make sense to create multiple versions of these objects.

    public sealed class OrderItemGateway : IOrderItemGateway
    {
        //code for reference 2
        //Copied from URL: https://csharpindepth.com/articles/singleton
        private static OrderItemGateway instance = null;
        private static readonly object padlock = new object();
        OrderItemGateway() { }

        public static OrderItemGateway Instance
        {
            get { lock (padlock) { if (instance == null) { instance = new OrderItemGateway(); } return instance; } }
        }
        //reference 2 ends here.

        //Method mentined in reference 1 
        //Copied from URL: https://stackoverflow.com/questions/20710178/entity-framework-creates-new-duplicate-entries-for-associated-objects
        public bool SaveOrderItems(List<OrderItems> orderItems, Enquiry enquiry)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    for (int i = 0; i < orderItems.Count(); i++)
                    {
                        orderItems[i].Enquiry = enquiry;
                        //adds all the of the items in the order to a database
                        context.Enquiries.Attach(orderItems[i].Enquiry);
                        context.OrderItems.Add(orderItems[i]);
                    }
                    context.SaveChanges();
                    return true;
                }
            }

            catch { return false;}
        }

        public List<OrderItems> GetOrderItemsInEnquiry(int enquiryID)
        {
            try 
            {
                using (var context = new DatabaseEntities())
                {
                    //Copied from URL: https://docs.microsoft.com/en-us/ef/core/querying/
                    var orderItemsQuery = context.OrderItems.Where(i => i.Enquiry.orderID == enquiryID).ToList();
                    return orderItemsQuery;
                }
            }
            catch { return null; }
        }

        public bool DeleteOrderItems(int id)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var itemGetEnquiry = context.OrderItems.Where(i => i.itemID == id).SingleOrDefault();
                    var itemEnquiry = context.OrderItems.Remove(itemGetEnquiry);
                    context.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

        public bool DeleteOrderItemsInEnquiry(int id)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var orderItemsQuery = context.OrderItems.Where(i => i.Enquiry.orderID == id).ToList();

                    if (orderItemsQuery.Count() > 0)
                    {
                        foreach (OrderItems i in orderItemsQuery)
                        {
                            var enquiryQuery = context.OrderItems.Remove(i);
                        }

                        context.SaveChanges();

                        var newOrderItemsQuery = context.OrderItems.Where(i => i.Enquiry.orderID == id).ToList();
                        if (newOrderItemsQuery.Count() == 0)
                        {
                            return true;
                        }
                    }
                    return false;
                }

            }
            catch { return false; }
        }
        public bool DeleteAllOrderItems()
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var orderItemsQuery = context.OrderItems.ToList();
                    foreach (OrderItems i in orderItemsQuery)
                    {
                        var enquiryQuery = context.OrderItems.Remove(i);
                    }

                    context.SaveChanges();

                    var newOrderItemsQuery = context.OrderItems.ToList();
                    if (newOrderItemsQuery.Count() == 0)
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
