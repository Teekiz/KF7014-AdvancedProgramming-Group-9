using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AdvancedProgrammingGroup9;

namespace AdvancedProgrammingGroup9TestProject
{
    [TestClass]
    public class UnitTest1
    {
        Order order1;
        OrderItems orderItem1;

        [TestInitialize]
        public void TestInitialize()
        {
            order1 = new Order(1, DateTime.Now, DateTime.Now.AddDays(1));
            orderItem1 = new OrderItems("Sword1", 5, null);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            order1 = null;
            orderItem1 = null;
        }

        [TestMethod]
        public void OrderCreatedSuccessfully()
        {
            //pretty obvious in hindsight but the DateTime.Now method must be set as a variable else when it runs the values will be different.
            DateTime now = DateTime.Now;
            order1 = new Order(1, now, DateTime.Now.AddDays(1));

            Assert.AreEqual(1, order1.GetOrderID(), "ID Incorrect");
            Assert.AreEqual(now, order1.GetReceivedDate(), "Received Date Incorrect");
            Assert.AreEqual(now.AddDays(1), order1.GetDeadline(), "Deadline Date Incorrect");
        }
    }
}