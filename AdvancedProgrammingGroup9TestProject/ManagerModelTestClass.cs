using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvancedProgrammingGroup9TestProject
{
    [TestClass]
    public class ManagerModelTestClass
    {
        /*
         * While developing this and the model class, I noticed that some of the methods were more complex than others
         * therefore, the simple methods have been split from the more complex methods that need more testing, they now have
         * their own methods.
         */

        IEnquiryGateway enquiryGateway;
        IOrderItemGateway orderItemGateway;
        ICustomerGateway customerGateway;
        IOrderGateway orderGateway;
        IManagerModel model;

        [TestInitialize]
        public void InitialVariables()
        {
            enquiryGateway = new EnquiryGatewayMOCObject();
            orderItemGateway = new OrderItemsGatewayMOCObject();
            customerGateway = new CustomerGatewayMOCObject();
            orderGateway = new OrderGatewayMOCObject();
            model = new ManagerModel(enquiryGateway, customerGateway, orderItemGateway, orderGateway);
        }

        [TestMethod]
        public void ManagerModelTestClassSimpleMethods()
        {
            List<OrderItems> checkItemList;
            Enquiry enquiry;

            /*For Method: List<Enquiry> GetEnquiries();*/
            enquiry = model.GetEnquiries()[0];
            Assert.AreEqual(1, enquiry.orderID);
            Assert.AreEqual("Order notes", enquiry.orderNotes);
            Assert.AreEqual(new DateTime(2020 / 20 / 12), enquiry.receivedDate);
            Assert.AreEqual(new DateTime(2020 / 30 / 12), enquiry.deadline);

            /*For Method: Enquiry GetEnquiry(int enquiryID);*/
            //get enquiry with id of 1
            enquiry = model.GetEnquiry(1);
            Assert.AreEqual(1, enquiry.orderID);
            Assert.AreEqual("Order notes", enquiry.orderNotes);
            Assert.AreEqual(new DateTime(2020 / 20 / 12), enquiry.receivedDate);
            Assert.AreEqual(new DateTime(2020 / 30 / 12), enquiry.deadline);
            //if the id is wrong return null
            Assert.IsNull(model.GetEnquiry(2));

            /*For Method: List<OrderItems> GetItemsInEnquiry(int enquiryID);*/
            //if the id matches an enquiry
            checkItemList = model.GetItemsInEnquiry(1);
            Assert.AreEqual("itemOne", checkItemList[0].description);
            Assert.AreEqual(4, checkItemList[0].quantity);
            //if the id doesn't match an enquiry
            checkItemList = model.GetItemsInEnquiry(2);
            Assert.IsTrue(checkItemList is null);

            /*For Method: Customer GetCustomerInEnquiry(int customerID);*/
            //if the customer exists
            Customer customer = model.GetCustomerInEnquiry(1);
            Assert.AreEqual("Person Personington", customer.name);
            Assert.AreEqual("Adress Line", customer.addressline1);
            Assert.AreEqual("26", customer.addressline2);
            Assert.AreEqual("0191234567", customer.phone);
            Assert.AreEqual(new DateTime(1995, 2, 21), customer.birthdate);
            Assert.AreEqual("NE1 1AD", customer.postcode);
            Assert.AreEqual("Newcastle", customer.townCity);
            Assert.AreEqual("Tyne and Wear", customer.county);
            Assert.AreEqual("England", customer.country);
            Assert.AreEqual("Government", customer.type);
            //if customer does not exist.
            customer = model.GetCustomerInEnquiry(2);
            Assert.IsTrue(customer is null);

            /*For Method: Order GetOrder(int id);*/
            //if the order exists
            Order order = model.GetOrder(1);
            Assert.AreEqual(0, order.progressCompleted);
            Assert.AreEqual(new DateTime(20 / 12 / 2021), order.scheduledStartDate);
            Assert.AreEqual(new DateTime(30 / 12 / 2021), order.confirmedDeadline);
            //if the order does not exist
            order = model.GetOrder(2);
            Assert.IsTrue(order is null);

            /*For Method: int GetEnquiryInOrder(Order order);*/
            int enqid = model.GetEnquiryInOrder(model.GetOrder(1));
            Assert.AreEqual(1, enqid);
            order = null;
            enqid = model.GetEnquiryInOrder(order);
            Assert.AreEqual(0, enqid);

            /*For Method: bool UpdateEnquiry(Enquiry enquiry);*/
            //enquiry exists.
            Assert.AreEqual(true, model.UpdateEnquiry(model.GetEnquiries()[0]));
            //enquiry is null.
            enquiry = null;
            Assert.AreEqual(false, model.UpdateEnquiry(enquiry));

            /*For Method: bool UpdateOrder(Order order);*/
            //order exists
            Assert.AreEqual(true, model.UpdateOrder(model.GetOrder(1)));
            //order is null
            order = null;
            Assert.AreEqual(false, model.UpdateOrder(order));

            /*For Method: bool SaveOrder(Order order, Enquiry enquiry);*/
            //order and enquiry exist
            Assert.AreEqual(true, model.SaveOrder(model.GetOrder(1), model.GetEnquiry(1)));
            //enquiry is null
            Assert.AreEqual(false, model.SaveOrder(model.GetOrder(1), null));
            //order is null
            Assert.AreEqual(false, model.SaveOrder(null, model.GetEnquiry(1)));
            //both are null
            Assert.AreEqual(false, model.SaveOrder(null, null));
        }

        //Probably the easiest method to test in this class as it only requires a list of items
        //five lists will be used to test this.

        /*For Method: void CalculateEstimatedTime(out int minTime, out int maxTime, out double minCost, out double maxCost, List<OrderItems> orderItems);*/

        [TestMethod]
        public void ManagerModelTestClassCalculateEstimatedTime()
        {
            //the smallest list, 1 ceremonial sword
            List<OrderItems> list1 = new List<OrderItems>();
            OrderItems item1list1 = (ItemFactory.Singleton.GetItemTypes(OrderType.CeremonialSword));
            item1list1.quantity = 1;
            list1.Add(item1list1);
            model.CalculateEstimatedTime(out int minTime1, out int maxTime1, out double minCost1, out double maxCost1, list1);
            //checking the outs
            Assert.AreEqual(20, minTime1); Assert.AreEqual(30, maxTime1); Assert.AreEqual(50, minCost1); Assert.AreEqual(1000, maxCost1);

            //this list with all the items
            List<OrderItems> list2 = new List<OrderItems>();
            OrderItems item1list2 = (ItemFactory.Singleton.GetItemTypes(OrderType.CeremonialSword));
            OrderItems item2list2 = (ItemFactory.Singleton.GetItemTypes(OrderType.Armour));
            OrderItems item3list2 = (ItemFactory.Singleton.GetItemTypes(OrderType.Sword));
            item1list2.quantity = 1; item2list2.quantity = 1; item3list2.quantity = 1;
            list2.Add(item1list2); list2.Add(item2list2); list2.Add(item3list2);
            model.CalculateEstimatedTime(out int minTime2, out int maxTime2, out double minCost2, out double maxCost2, list2);
            Assert.AreEqual(180, minTime2); Assert.AreEqual(450, maxTime2); Assert.AreEqual(4050, minCost2); Assert.AreEqual(21000, maxCost2);

            //checking if a list with types of items with differing quantities
            List<OrderItems> list3 = new List<OrderItems>();
            OrderItems item1list3 = ItemFactory.Singleton.GetItemTypes(OrderType.CeremonialSword);
            OrderItems item2list3 = ItemFactory.Singleton.GetItemTypes(OrderType.Armour);
            OrderItems item3list3 = ItemFactory.Singleton.GetItemTypes(OrderType.Sword);
            item1list3.quantity = 5; item2list3.quantity = 2; item3list3.quantity = 2; //5 22
            list3.Add(item1list3); list3.Add(item2list3); list3.Add(item3list3);
            model.CalculateEstimatedTime(out int minTime3, out int maxTime3, out double minCost3, out double maxCost3, list3);
            Assert.AreEqual(420, minTime3); Assert.AreEqual(990, maxTime3); Assert.AreEqual(8250, minCost3); Assert.AreEqual(45000, maxCost3);

            //checking a list with no values in it
            List<OrderItems> list4 = new List<OrderItems>();
            model.CalculateEstimatedTime(out int minTime4, out int maxTime4, out double minCost4, out double maxCost4, list4);
            Assert.AreEqual(0, minTime4); Assert.AreEqual(0, maxTime4); Assert.AreEqual(0, minCost4); Assert.AreEqual(0, maxCost4);

            //checking a null list
            List<OrderItems> list5 = null;
            model.CalculateEstimatedTime(out int minTime5, out int maxTime5, out double minCost5, out double maxCost5, list5);
            Assert.AreEqual(0, minTime5); Assert.AreEqual(0, maxTime5); Assert.AreEqual(0, minCost5); Assert.AreEqual(0, maxCost5);
        }

        /*For Method: bool PriceHoursCheck(Double price, int hours, List<OrderItems> orderItems);*/
        [TestMethod]
        public void ManagerModelTestClassPriceHoursCheck()
        {
            //this will be based on the methods before as the values are known
            List<OrderItems> list1 = new List<OrderItems>();
            OrderItems item1list1 = (ItemFactory.Singleton.GetItemTypes(OrderType.CeremonialSword));
            item1list1.quantity = 1;
            list1.Add(item1list1);

            //Min time = 20, Max time = 30, MinCost = 50, MaxCost = 1000
            Assert.IsFalse(model.PriceHoursCheck(2, 25, list1)); //price too low
            Assert.IsFalse(model.PriceHoursCheck(1500, 25, list1)); //price too high
            Assert.IsFalse(model.PriceHoursCheck(500, 15, list1)); //time too low 
            Assert.IsFalse(model.PriceHoursCheck(500, 35, list1)); //time too high            
            Assert.IsTrue(model.PriceHoursCheck(500, 25, list1)); //within the range

            List<OrderItems> list2 = new List<OrderItems>();
            OrderItems item1list2 = ItemFactory.Singleton.GetItemTypes(OrderType.CeremonialSword);
            OrderItems item2list2 = ItemFactory.Singleton.GetItemTypes(OrderType.Armour);
            OrderItems item3list2 = ItemFactory.Singleton.GetItemTypes(OrderType.Sword);
            item1list2.quantity = 5; item2list2.quantity = 2; item3list2.quantity = 2; //5 22
            list2.Add(item1list2); list2.Add(item2list2); list2.Add(item3list2);

            //Min time = 420, Max time = 990, MinCost = 8250, MaxCost = 45000
            Assert.IsFalse(model.PriceHoursCheck(2000, 500, list2)); //price too low
            Assert.IsFalse(model.PriceHoursCheck(50000, 500, list2)); //price too high
            Assert.IsFalse(model.PriceHoursCheck(15000, 15, list2)); //time too low 
            Assert.IsFalse(model.PriceHoursCheck(15000, 1000, list2)); //time too high            
            Assert.IsTrue(model.PriceHoursCheck(15000, 700, list2)); //within the range

            List<OrderItems> list3 = new List<OrderItems>();
            //should return false (list is empty)
            Assert.IsFalse(model.PriceHoursCheck(1000, 1000, list3));

            List<OrderItems> list4 = null;
            Assert.IsFalse(model.PriceHoursCheck(1000, 1000, list4));
        }


        /*For Method: CheckIfDeadlineIsFeasible(int hours, DateTime startDate, DateTime deadline);*/
        [TestMethod]
        public void ManagerModelTestClassCheckIfDeadlineIsFeasible()
        {
            //this version of the method multiplys the hours by 3 for 24 hours
            //there is 240 hours between these dates
            DateTime start1 = new DateTime(2021, 12, 10);
            DateTime end1 = new DateTime(2021, 12, 20);
            Assert.IsFalse(model.CheckIfDeadlineIsFeasible(1000, start1, end1)); //very unreasonable deadline
            Assert.IsTrue(model.CheckIfDeadlineIsFeasible(24, start1, end1)); //generious deadline

            DateTime start2 = new DateTime(2021, 12, 5);
            DateTime end2 = new DateTime(2021, 12, 8);
            Assert.IsFalse(model.CheckIfDeadlineIsFeasible(25, start2, end2)); //just over deadline
            Assert.IsTrue(model.CheckIfDeadlineIsFeasible(24, start2, end2)); //close deadline
        }

        /*For Method: Order conflictingOrder(DateTime checkStartDate, DateTime checkDeadline);*/
        //this method uses the database to find the exisitng orders, therefore, in the Gateway MOC objects
        //there will be a few orders created.
        [TestMethod]
        public void ManagerModelTestClassConflictingOrder()
        {
            /*four dates stored in the datebase that are relevent to this method
             * this should mean that for the most of january, there is no slots free
             *  28/12/2021 - 01/01/2022 (2)
             *  02/01/2022 - 09/01/2022 (3)
             *  14/01/2022 - 20/01/2022 (4)
             *  21/01/2022 - 21/02/2022 (5) 
            */

            //it is expected that if there is no conflicting order, return null
            //the beginning of january should be free
            Assert.IsNull(model.conflictingOrder(new DateTime(2021, 1, 1), new DateTime(2021, 1, 10)));
            //placing the object on the exact start and endate
            Order existingOrder = model.conflictingOrder(new DateTime(2021, 12, 28), new DateTime(2022, 1, 1));
            Assert.IsNotNull(existingOrder);
            Assert.AreEqual(new DateTime(2021, 12, 28), existingOrder.scheduledStartDate);
            Assert.AreEqual(new DateTime(2022, 1, 1), existingOrder.confirmedDeadline);

            //Placing the values within the time
            existingOrder = model.conflictingOrder(new DateTime(2021, 12, 29), new DateTime(2021, 12, 31));
            Assert.IsNotNull(existingOrder);
            Assert.AreEqual(new DateTime(2021, 12, 28), existingOrder.scheduledStartDate);
            Assert.AreEqual(new DateTime(2022, 1, 1), existingOrder.confirmedDeadline);

            //Testing march (should be free)
            Assert.IsNull(model.conflictingOrder(new DateTime(2022, 3, 1), new DateTime(2022, 3, 5)));

            //Placing the values during another time
            existingOrder = model.conflictingOrder(new DateTime(2022, 1, 1), new DateTime(2022, 1, 5));
            Assert.IsNotNull(existingOrder);
            Assert.AreEqual(new DateTime(2022, 1, 2), existingOrder.scheduledStartDate);
            Assert.AreEqual(new DateTime(2022, 1, 9), existingOrder.confirmedDeadline);
        }

        /*For Method: CheckSchedule(DateTime checkStartDate, DateTime checkDeadline)*/
        //this method uses the database to find the exisitng orders, therefore, in the Gateway MOC objects
        //there will be a few orders created.
        [TestMethod]
        public void ManagerModelTestCheckSchedule()
        {
            //this logic of this class mostly comes from the method above (conflictingOrder)
            //therefore, this should work correctly with no errors

            /*four dates stored in the datebase that are relevent to this method
             * this should mean that for the most of january, there is no slots free
             *  28/12/2021 - 01/01/2022 (2)
             *  02/01/2022 - 09/01/2022 (3)
             *  14/01/2022 - 20/01/2022 (4)
             *  21/01/2022 - 21/02/2022 (5) 
            */

            //clear schedule
            Assert.IsTrue(model.CheckSchedule(new DateTime(2021, 1, 1), new DateTime(2021, 1, 10)));
            //busy schedule
            Assert.IsFalse(model.CheckSchedule(new DateTime(2021, 12, 28), new DateTime(2022, 1, 1)));
            //busy schedule
            Assert.IsFalse(model.CheckSchedule(new DateTime(2021, 12, 29), new DateTime(2021, 12, 31)));
            //clear - set in march
            Assert.IsTrue(model.CheckSchedule(new DateTime(2022, 3, 1), new DateTime(2022, 3, 5)));
            //exisiting time
            Assert.IsFalse(model.CheckSchedule(new DateTime(2022, 1, 1), new DateTime(2022, 1, 5)));
        }
    }
}
