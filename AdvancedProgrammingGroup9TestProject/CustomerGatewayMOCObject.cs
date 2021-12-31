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

        public CustomerGatewayMOCObject()
        {
            storedcustomer = new Customer();
            storedcustomer.name = "Person Personington";
            storedcustomer.addressline1 = "Adress Line";
            storedcustomer.addressline2 = "26";
            storedcustomer.phone = "0191234567";
            storedcustomer.birthdate = new DateTime(1995, 2, 21);
            storedcustomer.postcode = "NE1 1AD";
            storedcustomer.townCity = "Newcastle";
            storedcustomer.county = "Tyne and Wear";
            storedcustomer.country = "England";
            storedcustomer.type = "Government";
        }
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
            allcustomers.Add(storedcustomer);
            return allcustomers;
        }

        public Customer GetCustomer(int id)
        {
            if (id == 1) { return storedcustomer; }
            else { return null; }
            
        }
    }
}
