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

            OrderItems sword = model.createItem("desc", 2, null, OrderType.Sword);
            SwordItem swordItem = new SwordItem();
            ArmourItem armourItem = new ArmourItem();

            Assert.AreEqual("desc", sword.description);
            Assert.AreEqual(2, sword.quantity);
            Assert.AreEqual(null, sword.referenceImage);
            Assert.IsInstanceOfType(swordItem, sword.GetType());
        }
    }
}
