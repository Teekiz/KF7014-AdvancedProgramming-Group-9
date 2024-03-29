﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvancedProgrammingGroup9TestProject
{
    //Created by Callum Rossiter, Ian Kenny developed the Order Test Method

    [TestClass]
    public class DataAccessTestClass
    {
        CustomerGateway CustomerCRUD = CustomerGateway.Instance;
        EnquiryGateway EnquiryCRUD = EnquiryGateway.Instance;
        OrderItemGateway OrderItemCRUD = OrderItemGateway.Instance;
        OrderGateway OrderCRUD = OrderGateway.Instance;

        Customer customer;
        Enquiry enquiry;
        Order order;
        DateTime now;

        OrderItems itemOne;
        OrderItems itemTwo;
        OrderItems itemThree;
        List<OrderItems> orderItems;

        [TestInitialize]
        public void DataClasses()
        {
            //Empty database.
            Assert.AreEqual(true, EnquiryCRUD.DeleteAllEnquiries());
            Assert.AreEqual(true, CustomerCRUD.DeleteAllCustomers());
            Assert.AreEqual(true, OrderItemCRUD.DeleteAllOrderItems());
            Assert.AreEqual(true, OrderCRUD.DeleteAllOrders());

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

            order = new Order();
        }

        //Created by Callum Rossiter
        [TestMethod]
        //Testing customer, read and write
        public void TestMethod1Customer()
        {
            //checking to see if it rejects a blank customer
            Assert.AreEqual(false, CustomerCRUD.SaveCustomer(new Customer()));

            //Testing to see if it can delete a customer that doesn't exist.
            Assert.AreEqual(false, CustomerCRUD.DeleteCustomer(1000));

            CustomerCRUD.DeleteAllCustomers();
            CustomerCRUD.SaveCustomer(customer);

            /*
             * because of autoincrement, this test will always fail after the first one
             * therefore, I am using to test get all customers and get the correct customer.
            */

            Assert.AreEqual(null, CustomerCRUD.GetCustomer(1000));
            Customer readCustomer = CustomerCRUD.GetAllCustomers()[0];

            Customer loadedCustomer = CustomerCRUD.GetCustomer(readCustomer.customerID);
            Assert.AreEqual(loadedCustomer.name, "Person Personington");
            Assert.AreEqual(loadedCustomer.addressline1, "Adress Line");
            Assert.AreEqual(loadedCustomer.addressline2, "26");
            Assert.AreEqual(loadedCustomer.phone, "0191234567");
            Assert.AreEqual(loadedCustomer.birthdate, new DateTime(1995, 2, 21));
            Assert.AreEqual(loadedCustomer.postcode, "NE1 1AD");
            Assert.AreEqual(loadedCustomer.townCity, "Newcastle");
            Assert.AreEqual(loadedCustomer.county, "Tyne and Wear");
            Assert.AreEqual(loadedCustomer.country, "England");
            Assert.AreEqual(loadedCustomer.type, "Government");

            //this should be false unless there has been a large amount of data stored.
            Assert.AreEqual(false, CustomerCRUD.DeleteCustomer(20000));
            Assert.AreEqual(true, CustomerCRUD.DeleteCustomer(loadedCustomer.customerID));
            Assert.AreEqual(true, CustomerCRUD.DeleteAllCustomers());
        }

        //Created by Callum Rossiter
        [TestMethod]
        public void TestMethod2Enquiry()
        {
            Assert.AreEqual(true, CustomerCRUD.DeleteAllCustomers());
            Assert.AreEqual(true, EnquiryCRUD.DeleteAllEnquiries());

            //Testing to see if it can delete a customer that doesn't exist.
            Assert.AreEqual(false, EnquiryCRUD.DeleteEnquiry(1000));

            //checking if it can be saved
            CustomerCRUD.SaveCustomer(customer);
            Assert.AreEqual(true, EnquiryCRUD.SaveEnquiry(enquiry, customer));

            //checking to see if the returned enquiry is null if it can't get it.
            Assert.AreEqual(EnquiryCRUD.GetEnquiry(100), null);
            Enquiry readEnquiry = EnquiryCRUD.GetAllEnquiries()[0];
            Enquiry loadedEnquiry = EnquiryCRUD.GetEnquiry(readEnquiry.orderID);

            Assert.AreEqual(loadedEnquiry.orderNotes, "Order notes");
            Assert.AreEqual(loadedEnquiry.receivedDate, now);
            Assert.AreEqual(loadedEnquiry.deadline, now.AddDays(20));

            loadedEnquiry.price = 1000;
            loadedEnquiry.hoursToComplete = 5000;

            //creating a new enquiry to get new info
            Assert.AreEqual(true, EnquiryCRUD.SaveEnquiry(loadedEnquiry, customer));
            Enquiry loadedNewEnquiry = EnquiryCRUD.GetEnquiry(EnquiryCRUD.GetAllEnquiries()[1].orderID);

            Assert.AreEqual(loadedNewEnquiry.orderNotes, "Order notes");
            Assert.AreEqual(loadedNewEnquiry.receivedDate, now);
            Assert.AreEqual(loadedNewEnquiry.deadline, now.AddDays(20));
            Assert.AreEqual(loadedNewEnquiry.price, 1000);
            Assert.AreEqual(loadedNewEnquiry.hoursToComplete, 5000);

            loadedNewEnquiry.orderNotes = "updated";
            loadedNewEnquiry.orderStatus = "updated";


            //testing the method update
            Assert.AreEqual(true, EnquiryCRUD.UpdateEnquiry(loadedNewEnquiry));
            Enquiry updatedEnquiry = EnquiryCRUD.GetEnquiry(loadedNewEnquiry.orderID);

            Assert.AreEqual(updatedEnquiry.orderNotes, "updated");
            Assert.AreEqual(updatedEnquiry.receivedDate, now);
            Assert.AreEqual(updatedEnquiry.deadline, now.AddDays(20));
            Assert.AreEqual(updatedEnquiry.price, 1000);
            Assert.AreEqual(updatedEnquiry.hoursToComplete, 5000);
            Assert.AreEqual(updatedEnquiry.orderStatus, "updated");

            Assert.AreEqual(false, EnquiryCRUD.UpdateEnquiry(new Enquiry()));

            //Get the enquiry id - will not save into db otherwise
            Assert.AreEqual(customer.customerID, EnquiryCRUD.FindCustomerIDinEnquiry(loadedEnquiry));

            //Should only be 1 enquiry in database
            Assert.AreEqual(false, EnquiryCRUD.DeleteEnquiry(20000));
            Assert.AreEqual(true, EnquiryCRUD.DeleteEnquiry(loadedEnquiry.orderID));
            Assert.AreEqual(true, EnquiryCRUD.DeleteAllEnquiries());
            Assert.AreEqual(true, CustomerCRUD.DeleteAllCustomers());
        }

        //Created by Callum Rossiter
        [TestMethod]
        public void TestMethod3OrderItems()
        {
            Assert.AreEqual(true, CustomerCRUD.DeleteAllCustomers());
            Assert.AreEqual(true, EnquiryCRUD.DeleteAllEnquiries());
            Assert.AreEqual(true, OrderItemCRUD.DeleteAllOrderItems());
    

            //Testing to see if it can delete an orderItem that doesn't exist.
            Assert.AreEqual(false, OrderItemCRUD.DeleteOrderItems(10000));

            //Testing to see if it can delete a orderitem in an enquiry that doesn't exist.
            Assert.AreEqual(false, OrderItemCRUD.DeleteOrderItemsInEnquiry(100000));

            //Assert.AreEqual(true, EnquiryCRUD.SaveEnquiry(enquiry, customer));
            CustomerCRUD.SaveCustomer(customer);
            EnquiryCRUD.SaveEnquiry(enquiry, customer);
            Assert.AreEqual(true, OrderItemCRUD.SaveOrderItems(orderItems, enquiry));

            //checking to see if the returned enquiry is null if it can't get it.
            Assert.AreEqual(0, OrderItemCRUD.GetOrderItemsInEnquiry(1000).Count());

            Enquiry readEnquiry = EnquiryCRUD.GetAllEnquiries()[0];
            List<OrderItems> loadedOrderItems = OrderItemCRUD.GetOrderItemsInEnquiry(readEnquiry.orderID);

            Assert.AreEqual("itemOne", loadedOrderItems[0].description);
            Assert.AreEqual(10, loadedOrderItems[0].quantity);
            Assert.AreEqual(null, loadedOrderItems[0].referenceImage);

            Assert.AreEqual("itemTwo", loadedOrderItems[1].description);
            Assert.AreEqual(2, loadedOrderItems[1].quantity);
            Assert.AreEqual(null, loadedOrderItems[1].referenceImage);

            Assert.AreEqual("itemThree", loadedOrderItems[2].description);
            Assert.AreEqual(8, loadedOrderItems[2].quantity);
            Assert.AreEqual(null, loadedOrderItems[2].referenceImage);

            Assert.AreEqual(true, OrderItemCRUD.DeleteOrderItems(loadedOrderItems[2].itemID));
            Assert.AreEqual(false, OrderItemCRUD.DeleteOrderItems(300000));
            Assert.AreEqual(true, OrderItemCRUD.DeleteOrderItemsInEnquiry(readEnquiry.orderID));

            Assert.AreEqual(true, EnquiryCRUD.DeleteAllEnquiries());
            Assert.AreEqual(true, CustomerCRUD.DeleteAllCustomers());
            Assert.AreEqual(true, OrderItemCRUD.DeleteAllOrderItems());
        }
        //Created by Ian Kenny
        [TestMethod]
        public void TestMethod4Orders()
        {
            Assert.AreEqual(true, OrderCRUD.DeleteAllOrders());

            DateTime start = new DateTime(2021, 12, 21);
            DateTime deadline = new DateTime(2021, 12, 25);
            order.scheduledStartDate = start;
            order.confirmedDeadline = deadline;
            order.Enquiry = enquiry;

            //required to save orders
            CustomerCRUD.SaveCustomer(customer);
            EnquiryCRUD.SaveEnquiry(enquiry, customer);

            // the next 4 lines should be okay as they are boolean    
            Assert.AreEqual(true, OrderCRUD.SaveOrder(order));
            List<Order> loadedOrder = OrderCRUD.GetAllOrders();
            Assert.AreEqual(start, loadedOrder[0].scheduledStartDate);
            Assert.AreEqual(deadline, loadedOrder[0].confirmedDeadline);

            //checking to see if the order can be updated
            DateTime updatedDeadline = new DateTime(2021, 12, 27); 
            Order orderOrderToUpdate = loadedOrder[0];
            orderOrderToUpdate.confirmedDeadline = updatedDeadline;
            Assert.AreEqual(true, OrderCRUD.UpdateOrder(orderOrderToUpdate));

            //get the updated order
            Order updatedOrder = OrderCRUD.GetOrder(orderOrderToUpdate.orderID);
            Assert.AreEqual(updatedDeadline, updatedOrder.confirmedDeadline);

            //Get the enquiry id - will not save into db otherwise
            Assert.AreEqual(enquiry.orderID, OrderCRUD.FindEnquiryIDinOrder(loadedOrder[0]));

            //database should be empty after the delete
            Assert.AreEqual(true, OrderCRUD.DeleteOrder(updatedOrder.orderID));
            Assert.AreEqual(0, OrderCRUD.GetAllOrders().Count());
            
        }
    }
}
