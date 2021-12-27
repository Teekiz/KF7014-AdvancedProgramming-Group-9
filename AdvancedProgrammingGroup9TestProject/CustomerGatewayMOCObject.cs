using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace AdvancedProgrammingGroup9TestProject
{
    public class CustomerGatewayMOCObject : ICustomerGateway
    {
        public Customer storedcustomer;
        public List<Customer> allcustomers;

        public bool SaveCustomer(Customer customer)
        {
            storedcustomer = customer;
            return true;
        }

        public bool DeleteAllCustomers()
        {
            return true;
        }

        public bool DeleteCustomer(int customerID)
        {
            return true;
        }

        public List<Customer> GetAllCustomers()
        {
            Customer customer = new Customer();
            customer.name = "Person Personington";
            customer.addressline1 = "Adress Line";
            customer.addressline2 = "26";
            customer.phone = "0191234567";
            customer.birthdate = new DateTime(1995, 2, 21);
            customer.postcode = "NE1 1AD";
            customer.townCity = "Newcastle";
            customer.county = "Tyne and Wear";
            customer.country = "England";
            customer.type = "Government";

            allcustomers.Add(customer);
            return allcustomers;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            customer.name = "Person B";
            customer.addressline1 = "Adress Line";
            customer.addressline2 = "26";
            customer.phone = "0191234567";
            customer.birthdate = new DateTime(1995, 2, 21);
            customer.postcode = "NE1 1AD";
            customer.townCity = "Newcastle";
            customer.county = "Tyne and Wear";
            customer.country = "England";
            customer.type = "Government";

            return customer;
        }
    }
}
