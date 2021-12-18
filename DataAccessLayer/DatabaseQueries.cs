using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDatabaseCreateQueries
    {
        void SaveCustomer(Customer customer);
        void SaveEnquiry(Enquiry enquiry, List<OrderItems> orderItems, Customer customer); //List
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


    //spliting the datebase class into seperate classes for CRUD operations.
    public class DatabaseCreateQueries : IDatabaseCreateQueries
    {
        public void SaveCustomer(Customer customer)
        {
            using (var context = new DatabaseEntities())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void SaveEnquiry(Enquiry enquiry, List<OrderItems> orderItems, Customer customer)
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
            //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
            using (var context = new DatabaseEntities())
                {
                    var enquiryQuery = context.Enquiries.Where(e => e.orderID == id).SingleOrDefault();
                    return enquiryQuery;
                }
        }

        public List<Enquiry> GetAllEnquiries()
        {
            //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
            using (var context = new DatabaseEntities())
            {
                var enquiryQuery = context.Enquiries.ToList();
                return enquiryQuery;
            }
        }

        public Customer GetCustomer(int id)
        {
            //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
            using (var context = new DatabaseEntities())
            {
                var customerQuery = context.Customers.Where(c => c.customerID == id).SingleOrDefault();
                return customerQuery;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
            using (var context = new DatabaseEntities())
            {
                var customerQuery = context.Customers.ToList();
                return customerQuery;
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

    public class DatabaseUpdateQueries
    {
        //blank
    }

    public class DatabaseDeleteQueries
    {
        //blank
    }
}
