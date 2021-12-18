using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDatabaseCreateQueries
    {
        bool SaveEnquiry(Enquiry enquiry);
        void SaveCustomer(Customer customer);
        void SaveOrderItem(OrderItems orderItems);
        void SaveBoth(Enquiry enquiry, List<OrderItems> orderItems, Customer customer); //List
    }

    public interface IDatabaseReadQueries
    {
        List<Enquiry> GetAllEnquiries();
        Enquiry GetEnquiry(int id);

        List<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
    }


    //spliting the datebase class into seperate classes for CRUD operations.
    public class DatabaseCreateQueries : IDatabaseCreateQueries
    {
        public bool SaveEnquiry(Enquiry enquiry)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    context.Enquiries.Add(enquiry);

                    /*()
                    for (int i = 0; i < enquiry.countItemInOrder(); i++)
                    {
                        //adds all the of the items in the order to a database
                        context.OrderItems.Add(enquiry.getItemInOrder(i));
                    }
                    */

                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void SaveCustomer(Customer customer)
        {
            using (var context = new DatabaseEntities())
            {
                context.Customers.Add(customer);
                context.SaveChanges();

                System.Windows.Forms.MessageBox.Show("Saved. Delete this.");
            }
        }

        public void SaveOrderItem(OrderItems orderItems)
        {
            using (var context = new DatabaseEntities())
            {
                context.OrderItems.Add(orderItems);
                context.SaveChanges();
                System.Windows.Forms.MessageBox.Show("Saved. Delete this.");
            }
        }

        public void SaveBoth(Enquiry enquiry, List<OrderItems> orderItems, Customer customer) //List<>
        {
            using (var context = new DatabaseEntities())
            {
                context.Customers.Add(customer);
                context.Enquiries.Add(enquiry);

                
                for (int i = 0; i < orderItems.Count(); i++)
                {
                    //adds all the of the items in the order to a database
                    context.OrderItems.Add(orderItems[i]);
                }
                

                context.SaveChanges();
            }
        }
    }
    public class DatabaseReadQueries : IDatabaseReadQueries
    {
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
