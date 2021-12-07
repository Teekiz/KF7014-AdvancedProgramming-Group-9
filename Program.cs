using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group9Assignment
{
    public class Assignment
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer();
            customer1.customerID = 0001;
            customer1.firstNames = "Thor";
            customer1.middleNames = "Chris";
            customer1.lastNames = "Odinson";
            customer1.companyNames = "Marvel Comics";
            customer1.addressLine1 = "1";
            customer1.addressLine2 = "Mjolnir Drive";
            customer1.addressLine3 = "Thunder Mountain";
            customer1.postcode = "MC1 1DC";
            customer1.townCity = "Asgard";
            customer1.stateCounty = "Valhalla";
            customer1.country = "Marvel Universe";
            customer1.phone = 01915551234;
            customer1.email = "thorodinson@email.com";
            customer1.bankdetails = "Gordon Banks 20-20-20 12345678";
            customer1.balance = 964;

            Customer customer2 = new Customer();
            customer2.customerID = 0002;
            customer2.firstNames = "Connor";
            customer2.middleNames = "Chris";
            customer2.lastNames = "MacLeod";
            customer2.companyNames = "Highlander Films";
            customer2.addressLine1 = "2";
            customer2.addressLine2 = "Lambert Road";
            customer2.addressLine3 = "The Trossachs";
            customer2.postcode = "CL2 2SC";
            customer2.townCity = "Fort Connery";
            customer2.stateCounty = "InverKilt";
            customer2.country = "Scotland";
            customer2.phone = 01415551235;
            customer2.email = "connormcleod@email.com";
            customer2.bankdetails = "Morewenna Banks 21-21-21 23456789";
            customer2.balance = 1518;
        }
    }
}