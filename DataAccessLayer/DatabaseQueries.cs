using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDatabaseCreateQueries
    {
        bool SaveCustomer(Customer customer);
        bool SaveEnquiry(Enquiry enquiry, List<OrderItems> orderItems, Customer customer); //List
    }

    public interface IDatabaseReadQueries
    {
        List<Enquiry> GetAllEnquiries();
        Enquiry GetEnquiry(int id);
        List<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        List<OrderItems> GetOrderItemsInEnquiry(int enquiryID);
        List<Order> GetAllOrders();
    }

    public interface IDatabaseDeleteQueries
    {
        bool DeleteCustomer(int customerID);
        bool DeleteAllCustomers();
        bool DeleteEnquiry(int id);
        bool DeleteAllEnquiries();
        bool DeleteOrderItems(int id);
        bool DeleteOrderItemsInEnquiry(int id);
        bool DeleteAllOrderItems();
    }

    public interface IDatabaseUpdateQueries
    {
        bool UpdateEnquiry(Enquiry enquiry);
    }


    //spliting the datebase class into seperate classes for CRUD operations.
    public class DatabaseCreateQueries : IDatabaseCreateQueries
    {
        public bool SaveCustomer(Customer customer)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        public bool SaveEnquiry(Enquiry enquiry, List<OrderItems> orderItems, Customer customer)
        {
            try 
            {
                using (var context = new DatabaseEntities())
                {
                    enquiry.Customer = customer;
                    context.Enquiries.Add(enquiry);
                    context.Customers.Add(customer);

                    for (int i = 0; i < orderItems.Count(); i++)
                    {
                        //adds all the of the items in the order to a database
                        orderItems[i].Enquiry = enquiry;
                        context.OrderItems.Add(orderItems[i]);
                    }
                    context.SaveChanges();
                    return true;
                }
            }

            catch
            {
                return false;
            }

        }
    }
    public class DatabaseReadQueries : IDatabaseReadQueries
    {
         /*
         *  some of this code is based on code the microsoft documenation for linq. To be on the safe side,
         *  I figured it would be better to mention this here, just in case using the documentation
         *  counts as plagerism. from https://docs.microsoft.com/en-us/ef/core/querying/
         *  
         *  specifically parts like this:           var enquiryQuery = context.Enquiries.Where(e => e.orderID == id).SingleOrDefault();
         */

        public Enquiry GetEnquiry(int id)
        {
            try
            {
                //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
                using (var context = new DatabaseEntities())
                {
                    var enquiryQuery = context.Enquiries.Where(e => e.orderID == id).SingleOrDefault();
                    return enquiryQuery;
                }
            }

            catch
            {
                return new Enquiry();
            }
        }

        public List<Enquiry> GetAllEnquiries()
        {
            try
            {
                //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
                using (var context = new DatabaseEntities())
                {
                    var enquiryQuery = context.Enquiries.ToList();
                    return enquiryQuery;
                }
            }

            catch
            {
                return new List<Enquiry>();
            }

        }

        public Customer GetCustomer(int id)
        {
            try
            {
                //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
                using (var context = new DatabaseEntities())
                {
                    var customerQuery = context.Customers.Where(c => c.customerID == id).SingleOrDefault();
                    return customerQuery;
                }
            }

            catch
            {
                return new Customer();
            }
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
                using (var context = new DatabaseEntities())
                {
                    var customerQuery = context.Customers.ToList();
                    return customerQuery;
                }
            }
            catch
            {
                return new List<Customer>();
            }
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

        public List<Order> GetAllOrders() 
        {
            using (var context = new DatabaseEntities())
            {
                //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
                var orders = context.Orders.ToList();
                return orders;
            }
        }
    }

    public class DatabaseUpdateQueries : IDatabaseUpdateQueries
    {
        public bool UpdateEnquiry(Enquiry enquiry)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
                    var orderItemsQuery = context.Enquiries.Where(i => i.orderID == enquiry.orderID).SingleOrDefault();
                    orderItemsQuery.deadline = enquiry.deadline;
                    orderItemsQuery.price = enquiry.price;
                    orderItemsQuery.hoursToComplete = enquiry.hoursToComplete;
                    orderItemsQuery.orderStatus = enquiry.orderStatus;
                    orderItemsQuery.orderNotes = enquiry.orderNotes;
                    context.SaveChanges();
                    return true;
                }
            }

            catch
            {
                return false;
            }
        }
    }

    public class DatabaseDeleteQueries : IDatabaseDeleteQueries
    {
        public bool DeleteCustomer(int customerID)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var customerGetQuery = context.Customers.Where(c => c.customerID == customerID).SingleOrDefault();
                    var customerQuery = context.Customers.Remove(customerGetQuery);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
        public bool DeleteAllCustomers()
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var customerGetQuery = context.Customers.ToList();

                    foreach (Customer c in customerGetQuery)
                    {
                        context.Customers.Remove(c);
                        context.SaveChanges();
                    }

                    context.SaveChanges();

                    var newCustomerGetQuery = context.Customers.ToList();
                    if (newCustomerGetQuery.Count() == 0)
                    {
                        return true;
                    }

                    return false;
                }
            }

            catch
            {
                return false;
            }

        }

        public bool DeleteEnquiry(int id)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var enquiryGetQuery = context.Enquiries.Where(e => e.orderID == id).SingleOrDefault();
                    var enquiryQuery = context.Enquiries.Remove(enquiryGetQuery);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
        public bool DeleteAllEnquiries()
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var enquiryGetQuery = context.Enquiries.ToList();
                    foreach (Enquiry e in enquiryGetQuery)
                    {
                        var enquiryQuery = context.Enquiries.Remove(e);
                    }

                    context.SaveChanges();

                    var newEnquiryGetQuery = context.Enquiries.ToList();
                    if (newEnquiryGetQuery.Count() == 0)
                    {
                        return true;
                    }

                    return false;
                }
            }

            catch
            {
                return false;
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
            catch
            {
                return false;
            }
        }

        public bool DeleteOrderItemsInEnquiry(int id)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var orderItemsQuery = context.OrderItems.Where(i => i.Enquiry.orderID == id).ToList();
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

                    return false;
                }

            }
            catch
            {
                return false;
            }
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

                catch
                {
                    return false;
                }
        }
    }
}
