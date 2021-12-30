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
    public class EnquiryModelTestClass
    {
        [TestMethod]
        //Testing customer, read and write
        public void TestMethod1EnquiryModel()
        {
            IEnquiryGateway enquiryGateway = new EnquiryGatewayMOCObject();
            IOrderItemGateway orderItemGateway = new OrderItemsGatewayMOCObject();
            ICustomerGateway customerGateway = new CustomerGatewayMOCObject();
            IEnquiryModel model = new EnquiryModel(enquiryGateway, orderItemGateway, customerGateway);

            List<OrderItems> orderItemsList = new List<OrderItems>();
            Enquiry enquiry = new Enquiry();
            Customer customer = new Customer();

            //checking the create models.

            OrderItems sword = model.createItem("desc", 2, null, OrderType.Sword);
            SwordItem swordItem = new SwordItem();
            OrderItems sword2 = model.createItem("descsword2", 3, null, OrderType.Sword);
            OrderItems armour = model.createItem("desc2", 2, null, OrderType.Armour);
            ArmourItem armourItem = new ArmourItem();
            OrderItems csword = model.createItem("desc3", 5, null, OrderType.CeremonialSword);
            CeremonialSwordItem cswordItem = new CeremonialSwordItem();

            Assert.AreEqual("desc", sword.description);
            Assert.AreEqual(2, sword.quantity);
            Assert.AreEqual(null, sword.referenceImage);
            Assert.IsInstanceOfType(swordItem, sword.GetType());

            Assert.AreEqual("desc2", armour.description);
            Assert.AreEqual(2, armour.quantity);
            Assert.AreEqual(null, armour.referenceImage);
            Assert.IsInstanceOfType(armourItem, armour.GetType());

            Assert.AreEqual("desc3", csword.description);
            Assert.AreEqual(5, csword.quantity);
            Assert.AreEqual(null, csword.referenceImage);
            Assert.IsInstanceOfType(cswordItem, csword.GetType());

            orderItemsList.Add(sword);
            orderItemsList.Add(csword);
            orderItemsList.Add(armour);
            orderItemsList.Add(sword2);

            model.CalculateEstimatedTime(out int minTime, out int maxTime, orderItemsList);

            Assert.AreEqual(660, minTime);
            Assert.AreEqual(1350, maxTime);

            //save enquiry
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
            Assert.AreEqual(0, minTime2);
            Assert.AreEqual(0, maxTime2);

            model.CalculateEstimatedTime(out int minTime3, out int maxTime3, onull);
            Assert.AreEqual(0, minTime3);
            Assert.AreEqual(0, maxTime3);
        }
    }
}
