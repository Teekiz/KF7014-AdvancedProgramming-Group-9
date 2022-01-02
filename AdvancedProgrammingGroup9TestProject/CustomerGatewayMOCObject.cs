using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace AdvancedProgrammingGroup9TestProject
{
    //Created by Callum Rossiter
    public class CustomerGatewayMOCObject : ICustomerGateway
    {
        public Customer storedcustomer;
        public List<Customer> allcustomers;

        public CustomerGatewayMOCObject()
        {
            allcustomers = new List<Customer>();

            storedcustomer = new Customer();
            storedcustomer.customerID = 1;
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
            allcustomers.Add(storedcustomer);

            Customer customer2 = new Customer();
            customer2.customerID = 2;
            customer2.type = "Collector";
            allcustomers.Add(customer2);

            Customer customer3 = new Customer();
            customer3.customerID = 3;
            customer3.type = "Governmental";
            allcustomers.Add(customer3);

            Customer customer4 = new Customer();
            customer4.customerID = 4;
            customer4.type = "Entertainment";
            allcustomers.Add(customer4);

            Customer customer5 = new Customer();
            customer5.customerID = 5;
            customer5.type = "Collector";
            allcustomers.Add(customer5);

            Customer customer6 = new Customer();
            customer6.customerID = 6;
            customer6.type = "Governmental";
            allcustomers.Add(customer6);


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
            return allcustomers;
        }

        public Customer GetCustomer(int id)
        {
            foreach (Customer cu in GetAllCustomers())
            {
                if (cu.customerID == id) { return cu; }
            }
            return null;

        }
    }
}
