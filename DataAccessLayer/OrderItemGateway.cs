using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IOrderItemGateway
    {
        bool SaveOrderItems(List<OrderItems> orderItems, Enquiry enquiry);
        List<OrderItems> GetOrderItemsInEnquiry(int enquiryID);
        bool DeleteOrderItems(int id);
        bool DeleteOrderItemsInEnquiry(int id);
        bool DeleteAllOrderItems();
    }

    //For this method I used the answer by the user Slauma (2013)
    //https://stackoverflow.com/questions/20710178/entity-framework-creates-new-duplicate-entries-for-associated-objects
    //using it for context.Customers.Attach(enquiry.Customer); to fix duplication issues

    public class OrderItemGateway : IOrderItemGateway
    {
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
            using (var context = new DatabaseEntities())
            {
                //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
                var orderItemsQuery = context.OrderItems.Where(i => i.Enquiry.orderID == enquiryID).ToList();
                return orderItemsQuery;
            }
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
