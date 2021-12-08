using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AdvancedProgrammingGroup9;

namespace AdvancedProgrammingGroup9TestProject
{
    [TestClass]
    public class UnitTest1
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
        public void OrderCreatedSuccessfully()
        {
            //pretty obvious in hindsight but the DateTime.Now method must be set as a variable else when it runs the values will be different.
            DateTime now = DateTime.Now;
            enquiry1 = new Enquiry(1, now, DateTime.Now.AddDays(1));

            Assert.AreEqual(1, enquiry1.GetOrderID(), "ID Incorrect");
            Assert.AreEqual(now, enquiry1.GetReceivedDate(), "Received Date Incorrect");
            Assert.AreEqual(now.AddDays(1), enquiry1.GetDeadline(), "Deadline Date Incorrect");
        }
    }
}