using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AdvancedProgrammingGroup9TestProject
{
    [TestClass]
    public class DataAccessTestClass
    {
        DatabaseReadQueries read = new DatabaseReadQueries();
        DatabaseCreateQueries create = new DatabaseCreateQueries();
        DatabaseDeleteQueries delete = new DatabaseDeleteQueries();
        DatabaseUpdateQueries update = new DatabaseUpdateQueries();

        Customer customer;
        Enquiry enquiry;
        DateTime now;

        OrderItems itemOne;
        OrderItems itemTwo;
        OrderItems itemThree;
        List<OrderItems> orderItems;

        [TestInitialize]
        public void DataClasses()
        {
            customer = new Customer();
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

            now = new DateTime(2021, 12, 10);

            enquiry = new Enquiry();
            enquiry.orderNotes = "Order notes";
            enquiry.receivedDate = now;
            enquiry.deadline = now.AddDays(20);

            itemOne = ItemFactory.Singleton.GetItemTypes(OrderType.Sword);
            itemOne.description = "itemOne";
            itemOne.quantity = 10;
            itemOne.referenceImage = null;

            itemTwo = ItemFactory.Singleton.GetItemTypes(OrderType.Armour);
            itemTwo.description = "itemTwo";
            itemTwo.quantity = 2;
            itemTwo.referenceImage = null;

            itemThree = ItemFactory.Singleton.GetItemTypes(OrderType.CeremonialSword);
            itemThree.description = "itemThree";
            itemThree.quantity = 8;
            itemThree.referenceImage = null;

            orderItems = new List<OrderItems>();

            orderItems.Add(itemOne);
            orderItems.Add(itemTwo);
            orderItems.Add(itemThree);
        }

        [TestMethod]
        public void dele()
        {
            delete.DeleteCustomer(66);
            Assert.AreEqual(true, delete.DeleteCustomer(66));
        }

        [TestMethod]
        //Testing customer, read and write
        public void TestMethod1Customer()
        {
            //checking to see if it rejects a blank customer
            Assert.AreEqual(false, create.SaveCustomer(new Customer()));
            //Testing to see if it can handle if there is no data
            delete.DeleteAllCustomers();
            create.SaveCustomer(customer);

            /*
             * because of autoincrement, this test will always fail after the first one
             * therefore, I am using to test get all customers and get the correct customer.
            */

            Assert.AreEqual(null, read.GetCustomer(100));
            Customer readCustomer = read.GetAllCustomers()[0];

            Customer loadedCustomer = read.GetCustomer(readCustomer.customerID);
            Assert.AreEqual(loadedCustomer.name, "Person Personington");
            Assert.AreEqual(loadedCustomer.addressline1, "Adress Line");
            Assert.AreEqual(loadedCustomer.addressline2, "26");
            Assert.AreEqual(loadedCustomer.phone, "0191234567");
            Assert.AreEqual(loadedCustomer.birthdate, new DateTime(1995, 2, 21));
            Assert.AreEqual(loadedCustomer.postcode, "NE1 1AD");
            Assert.AreEqual(loadedCustomer.townCity, "Newcastle");
            Assert.AreEqual(loadedCustomer.county, "Tyne and Wear");
            Assert.AreEqual(loadedCustomer.country,"England");
            Assert.AreEqual(loadedCustomer.type, "Government");

            //Should only be 1 customer in database
            Assert.AreEqual(false, delete.DeleteCustomer(2));
            Assert.AreEqual(true, delete.DeleteCustomer(loadedCustomer.customerID));
        }
        [TestMethod]
        public void TestMethod2Enquiry()
        {
            Assert.AreEqual(true, delete.DeleteAllCustomers());
            Assert.AreEqual(true, delete.DeleteAllEnquiries());

            //Prerequisites to save an enquiry.
            List<OrderItems> tempOrderItems = new List<OrderItems>();
            //Assert.AreEqual(false, create.SaveEnquiry(enquiry, tempOrderItems, customer));

            //checking if it can be saved
            Assert.AreEqual(true, create.SaveEnquiry(enquiry, orderItems, customer));

            //checking to see if the returned enquiry is null if it can't get it.
            Assert.AreEqual(read.GetEnquiry(100), null);
            Enquiry readEnquiry = read.GetAllEnquiries()[0];
            Enquiry loadedEnquiry = read.GetEnquiry(readEnquiry.orderID);

            Assert.AreEqual(loadedEnquiry.orderNotes, "Order notes");
            Assert.AreEqual(loadedEnquiry.receivedDate, now);
            Assert.AreEqual(loadedEnquiry.deadline, now.AddDays(20));

            loadedEnquiry.price = 1000;
            loadedEnquiry.hoursToComplete = 5000;

            //creating a new enquiry to get new info
            Assert.AreEqual(true, create.SaveEnquiry(loadedEnquiry, tempOrderItems, customer));
            Enquiry loadedNewEnquiry = read.GetEnquiry(read.GetAllEnquiries()[1].orderID);

            Assert.AreEqual(loadedEnquiry.orderNotes, "Order notes");
            Assert.AreEqual(loadedEnquiry.receivedDate, now);
            Assert.AreEqual(loadedEnquiry.deadline, now.AddDays(20));
            Assert.AreEqual(loadedEnquiry.price, 1000);
            Assert.AreEqual(loadedEnquiry.hoursToComplete, 5000);

            //Should only be 1 enquiry in database
            Assert.AreEqual(false, delete.DeleteEnquiry(30));
            Assert.AreEqual(true, delete.DeleteEnquiry(loadedEnquiry.orderID));
            Assert.AreEqual(true, delete.DeleteAllEnquiries());
        }

        [TestMethod]
        public void TestMethod3OrderItems()
        {
            Assert.AreEqual(true, delete.DeleteAllCustomers());
            Assert.AreEqual(true, delete.DeleteAllEnquiries());
            Assert.AreEqual(true, delete.DeleteAllOrderItems());

            Assert.AreEqual(true, create.SaveEnquiry(enquiry, orderItems, customer));

            //checking to see if the returned enquiry is null if it can't get it.
            Assert.AreEqual(read.GetOrderItemsInEnquiry(6).Count(), 0);

            Enquiry readEnquiry = read.GetAllEnquiries()[0];
            List<OrderItems> loadedOrderItems = read.GetOrderItemsInEnquiry(readEnquiry.orderID);

            Assert.AreEqual("itemOne", loadedOrderItems[0].description);
            Assert.AreEqual(10, loadedOrderItems[0].quantity);
            Assert.AreEqual(null, loadedOrderItems[0].referenceImage);

            Assert.AreEqual("itemTwo", loadedOrderItems[1].description);
            Assert.AreEqual(2, loadedOrderItems[1].quantity);
            Assert.AreEqual(null, loadedOrderItems[1].referenceImage);

            Assert.AreEqual("itemThree", loadedOrderItems[2].description);
            Assert.AreEqual(8, loadedOrderItems[2].quantity);
            Assert.AreEqual(null, loadedOrderItems[2].referenceImage);

            Assert.AreEqual(false, delete.DeleteOrderItems(30));
            Assert.AreEqual(true, delete.DeleteOrderItemsInEnquiry(readEnquiry.orderID));
        }
    }
}
