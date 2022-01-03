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
    //Created by Sai Pavan Madala, Updated by Callum Rossiter

    [TestClass]
    public class ScheduleModelTestClass
    {

        IEnquiryGateway enquiryGateway;
        IOrderItemGateway orderItemGateway;
        IOrderGateway orderGateway;
        IScheduleModel model;
        Order order;
        Enquiry enquiry;
        OrderItems order1;

        [TestInitialize]
        public void InitialVariables()
        {
            enquiryGateway = new EnquiryGatewayMOCObject();
            orderItemGateway = new OrderItemsGatewayMOCObject();
            orderGateway = new OrderGatewayMOCObject();
            model = new ScheduleModel(orderGateway, enquiryGateway, orderItemGateway);
        }

        [TestMethod]
        public void Testmethod1ScheduleModel()
        {
            //orders within two months = 4
            Assert.AreEqual(4, model.GetAllOrdersWithinTwoMonths().Count());

            //order id exisits
            order = model.GetOrder(2);
            Assert.AreEqual(2, order.orderID);
            //order id doesn't exist
            Assert.IsNull(model.GetOrder(20));

            //should equal 2
            enquiry = model.GetEnquiryFromOrder(order);
            Assert.AreEqual(2, enquiry.orderID);

            order.orderID = 1;
            order1 = model.GetOrderItemsFromOrder(order)[0];
            Assert.IsNotNull(order1);

            //should return yes (100%)
            order.orderID = 3;
            Assert.IsTrue(model.OnTarget(order));

            //order is behind
            order.orderID = 1;
            Assert.IsFalse(model.OnTarget(order));

            //the order is not null
            Assert.AreEqual(true, model.updateOrder(order));



            /* Fix Later  - Madalas sumbitted
            checkItemList = model.GetItemsInEnquiry(1);
            Assert.AreEqual("itemOne", checkItemList[0].description);
            Assert.AreEqual(12, checkItemList[0].quantity);

            checkItemList = model.GetItemsInEnquiry(2);
            Assert.IsTrue(checkItemList is null);
            Order order = model.GetOrder(1);
            Assert.AreEqual(0, order.progressCompleted);
            Assert.AreEqual(new DateTime(01 / 01 / 2020), order.scheduledStartDate);
            Assert.AreEqual(new DateTime(10 / 02 / 2020), order.confirmedDeadline);
         
            order = model.GetOrder(60);
            Assert.IsTrue(order is null);
      
            int enqid = model.GetEnquiryInOrder(model.GetOrder(1));
            Assert.AreEqual(1, enqid);
            order = null;
            enqid = model.GetEnquiryInOrder(order);
            Assert.AreEqual(0, enqid);

            
            Assert.AreEqual(true, model.UpdateEnquiry(model.GetEnquiries()[0]));
       

            enquiry = null;
            Assert.AreEqual(false, model.UpdateEnquiry(enquiry));

            //bool 

            Assert.AreEqual(true, model.UpdateOrder(model.GetOrder(1)));
          
            order = null;
            Assert.AreEqual(false, model.UpdateOrder(order));

           Assert.AreEqual(true, model.SaveOrder(model.GetOrder(1), model.GetEnquiry(1)));
            
            Assert.AreEqual(false, model.SaveOrder(model.GetOrder(1), null));
           
            Assert.AreEqual(false, model.SaveOrder(null, model.GetEnquiry(1)));
            
            Assert.AreEqual(false, model.SaveOrder(null, null));

            //no orders

            Assert.AreEqual(orderGateway.GetOrder(3), model.DoesOrderExist(enquiryGateway.GetEnquiry(3)));
            enquiry = new Enquiry();
            enquiry.orderID = 20; 
            Assert.IsNull(model.DoesOrderExist(enquiry));

            */


        }
    }
}
