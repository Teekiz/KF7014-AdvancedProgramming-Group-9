using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// public interface 

namespace DomainLayer
{
    public interface ICustomer
    { 
    
    }

    public class Customer : ICustomer
    {
        //Added a comment to this - Ian please delete this when you can.

        public Customer(string name, string companyName, string address, string postcode, string townCity, string stateCounty,
            string country, int phone, string email, int balance, string type)
        {
            this.name = name;
            this.companyName = companyName;
            this.address = address;
            this.postcode = postcode;
            this.townCity = townCity;
            this.stateCounty = stateCounty;
            this.country = country;
            this.phone = phone;
            this.email = email;
            this.balance = balance;
            this.type = type;

        }

        public int customerID { get; set; }
        public string name { get; set; }
        public string companyName { get; set; }
        public string address { get; set; }
        public string postcode { get; set; }
        public string townCity { get; set; }
        public string stateCounty { get; set; }
        public string country { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public string type { get; set; }
        public int balance { get; set; }

        public string getName()
        {
            return name;
        }

    }
}
