using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// public interface 

namespace DomainLayer
{
    public interface ICustomerModel
    {
        string getName();
        string getAddress();
        string getPostcode();
        string returnTownCity();
        string getStateCounty();
        string getCountry();
        string getType();
    }

    public class CustomerModel : ICustomerModel
    {
        //Added a comment to this - Ian please delete this when you can.

        public CustomerModel(string name, string address, string postcode, string townCity, string stateCounty, string country, string type)
        {
            this.name = name;
            this.address = address;
            this.postcode = postcode;
            this.townCity = townCity;
            this.stateCounty = stateCounty;
            this.country = country;
            this.type = type;

        }

        public CustomerModel()
        { 
        
        }

        public int customerID { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string postcode { get; set; }
        public string townCity { get; set; }
        public string stateCounty { get; set; }
        public string country { get; set; }
        public string type { get; set; }

        public string getName() {return name;}
        public string getAddress() {return address;}
        public string getPostcode() {return postcode;}
        public string returnTownCity() {return townCity;}
        public string getStateCounty() {return stateCounty;}
        public string getCountry() {return country;}
        public string getType() {return type;}
    }
}
