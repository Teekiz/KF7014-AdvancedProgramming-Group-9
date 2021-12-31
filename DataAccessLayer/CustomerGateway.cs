using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{

    /*
     * Based on the design pattern found here https://martinfowler.com/eaaCatalog/tableDataGateway.html
     */

    public interface ICustomerGateway
    {
        bool SaveCustomer(Customer customer);
        Customer GetCustomer(int id);
        List<Customer> GetAllCustomers();
        bool DeleteCustomer(int customerID);
        bool DeleteAllCustomers();
    }

    //1) Some of this code is based on https://docs.microsoft.com/en-us/ef/core/querying/ for the get methods
    //I've put this in the methods relevent

    //2) I reformatted the singleton design pattern to use thread saftey -
    //this comes fromC# in Depth "Implementing the Singleton Pattern in C#" https://csharpindepth.com/articles/singleton

    public sealed class CustomerGateway : ICustomerGateway
    {
        //Reference 2.
        //reformated to use simple thread-saftey - this code mostly comes from
        //C# in Depth "Implementing the Singleton Pattern in C#" https://csharpindepth.com/articles/singleton
        //it has been changed from the copy of the presentation

        //the explanation for using the singleton pattern for the gateways is because there only needs to be one instance of these
        //while the program will at some point need all the gateways, it doesn't make sense to create multiple versions of these objects.

        private static CustomerGateway instance = null;
        private static readonly object padlock = new object();
        CustomerGateway() { }

        public static CustomerGateway Instance
        {
            get { lock (padlock) { if (instance == null) { instance = new CustomerGateway(); } return instance; } }
        }

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
            catch { return false; }
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

            catch { return null ; }
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
            { return null; }
        }

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
            catch { return false; }
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

            catch { return false; }
        }
    }
}
