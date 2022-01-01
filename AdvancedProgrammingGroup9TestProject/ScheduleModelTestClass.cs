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
    public class ScheduleModelTestClass
    {
        //look at the schedule model interface, you need to check each type
        //does it return the exepected value, what if the parameter is invaild, or null?

        [TestMethod]
        //Testing Schedule, read and write
        public void TestMethod1ScheduleModel()
        {
        List<Order> GetAllOrdersWithinTwoMonths();
        Enquiry GetEnquiryFromOrder(Order order);
        List<OrderItems> GetOrderItemsFromOrder(Order order);
     
         Customer customer = new Customer();

            //checking the  1st schedule order create models.

            OrderItems GetAllOrdersWithinTwoMonths= model.createItem("desc", 60, null, OrderType.GetAllOrdersWithinTwoMonths);
            SwordItem swordItems = new SwordItem(sword1,armour,CeremonialSwordItem);
            OrderItems order1 = model.createItem("desc1",15 , null, OrderType.order1(swordItem));
            OrderItems order2 = model.createItem("desc2", 20, null, OrderType.order2(swordItem));
            ArmourItem armourItem = new ArmourItem();
            OrderItems order3 = model.createItem("desc3", 20, null, OrderType.order3(ArmourItem));
           

            Assert.AreEqual("desc", GetAllOrdersWithinTwoMonths.description);
            Assert.AreEqual(60, OrderType.GetAllOrdersWithinTwoMonths);
            Assert.IsInstanceOfType(GetAllOrdersWithinTwoMonths, GetAllOrdersWithinTwoMonths.GetType());

            Assert.AreEqual("desc1", order1.description);
            Assert.AreEqual(15, swordItem.quantity);
            Assert.IsInstanceOfType(order1, order1.GetType());

            Assert.AreEqual("desc2", order2.description);
            Assert.AreEqual(20, swordItem.quantity);
            Assert.IsInstanceOfType(order2, order2.GetType());

            Assert.AreEqual("desc3", order3.description);
            Assert.AreEqual(20, armourItem.quantity);
            Assert.IsInstanceOfType(order3, order3.GetType());

            orderItemsList.Add(order1;
            orderItemsList.Add(order2);
            orderItemsList.Add(order3);
            orderItemsList.Add(order4);

            model.CalculateEstimatedTime(out int mindays, out int maxdays, orderItemsList);

            Assert.AreEqual(55, minTime);
            Assert.AreEqual(60, maxTime);

            //save Schedule
            Assert.AreEqual(true, model.SaveEnquiry(enquiry, customer, orderItemsList));

            //should not accept null variables
            Enquiry enull = null;
            Customer cnull = null;
            List<OrderItems> onull = null;
            List<OrderItems> missingOrderItems = new List<OrderItems>();

            Assert.AreEqual(false, model.SaveEnquiry(enull, customer, orderItemsList));
            Assert.AreEqual(false, model.SaveEnquiry(enquiry, cnull, orderItemsList));
            Assert.AreEqual(false, model.SaveEnquiry(enquiry, customer, onull));
            Assert.AreEqual(false, model.SaveEnquiry(enull, cnull, onull));
            Assert.AreEqual(true, model.SaveEnquiry(enquiry, customer, missingOrderItems));

            model.CalculateEstimatedTime(out int minTime2, out int maxTime2, missingOrderItems);
            Assert.AreEqual(55, minTime2);
            Assert.AreEqual(60, maxTime2);
           model.CalculateEstimatedTime(out int minTime3, out int maxTime3, onull);
            Assert.AreEqual(55, minTime3);
            Assert.AreEqual(55, maxTime3);
        }                   
    }
}
