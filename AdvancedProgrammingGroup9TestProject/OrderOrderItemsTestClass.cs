using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AdvancedProgrammingGroup9;

namespace AdvancedProgrammingGroup9TestProject
{
    [TestClass]
    public class OrderOrderItemsTestClass
    {
        Enquiry enquiry1;
        OrderItems orderItem1;

        [TestInitialize]
        public void TestInitialize()
        {
            enquiry1 = new Enquiry(1, DateTime.Now, DateTime.Now.AddDays(1));
            orderItem1 = new OrderItems("Sword1", 5, null);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            enquiry1 = null;
            orderItem1 = null;
        }

        [TestMethod]
        public void CreatingOrder()
        {
            //pretty obvious in hindsight but the DateTime.Now method must be set as a variable else when it runs the values will be different.
            DateTime now = DateTime.Now;
            enquiry1 = new Enquiry(1, now, DateTime.Now.AddDays(1));

            Assert.AreEqual(1, enquiry1.GetOrderID(), "ID Incorrect");
            Assert.AreEqual(now, enquiry1.GetReceivedDate(), "Received Date Incorrect");
            Assert.AreEqual(now.AddDays(1), enquiry1.GetDeadline(), "Deadline Date Incorrect");
        }

        [TestMethod]
        public void CreatingOrderItem()
        {
            enquiry1.createSword("Sword", 5, null);
            enquiry1.createArmour("Armour", 2, null);
            enquiry1.createCeremonialSword("CeremonialSword", 3, null);

            Assert.AreEqual(3, enquiry1.countItemInOrder(), "Incorrect count");

            //Max time :- Sword (5 * 120 hours) = 600
            //            Armour (2 * 300) = 600
            //            CeremonialSword (3 * 30) = 90
            //Max time should = 1290 hours

            Assert.AreEqual(1290, enquiry1.CalculateEstimatedMaxTime(), "Incorrect count");

            //Min time :- Sword (5 * 80) = 400
            //            Armour (2 * 80) = 160
            //            CeremonialSword (3 * 20) = 60
            //Max time should = 620 hours

            Assert.AreEqual(620, enquiry1.CalculateEstimatedMinTime(), "Incorrect count");

            Assert.AreEqual(0, enquiry1.getItemInOrder(0).GetID(), "Incorrect ID");
            Assert.AreEqual("Sword", enquiry1.getItemInOrder(0).GetName(), "Incorrect Name");
            Assert.AreEqual(5, enquiry1.getItemInOrder(0).GetQuantity(), "Incorrect Quantity");
            Assert.AreEqual(5, enquiry1.getItemInOrder(0).GetQuantity(), "Incorrect Quantity");
            Assert.AreEqual(null, enquiry1.getItemInOrder(0).GetReferenceImage(), "Incorrect Reference Image");
            Assert.AreEqual(120, enquiry1.getItemInOrder(0).GetMaxTime(), "Incorrect Max time");
            Assert.AreEqual(80, enquiry1.getItemInOrder(0).GetMinTime(), "Incorrect Min time");
        }
    }
}