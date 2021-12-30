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
        List<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        bool DeleteCustomer(int customerID);
        bool DeleteAllCustomers();
    }

    //1) Some of this code is based on https://docs.microsoft.com/en-us/ef/core/querying/ for the get methods
    //I've put this in the methods relevent

    public class CustomerGateway : ICustomerGateway
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

            catch { return new Customer(); }
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
            { return new List<Customer>(); }
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
