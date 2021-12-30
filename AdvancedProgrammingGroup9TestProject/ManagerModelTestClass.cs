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
        //While developing this and the model class, I noticed that some of the methods were more complex than others
        //therefore, simple methods have been split and more complex methods that need more testing will have
        //their own methods.

        [TestInitialize]
        public void InitialVariables()
        {
            IEnquiryGateway enquiryGateway = new EnquiryGatewayMOCObject();
            IOrderItemGateway orderItemGateway = new OrderItemsGatewayMOCObject();
            ICustomerGateway customerGateway = new CustomerGatewayMOCObject();
            IOrderGateway orderGateway = new OrderGatewayMOCObject();
            IEnquiryModel model = new EnquiryModel(enquiryGateway, orderItemGateway, customerGateway);

            List<OrderItems> orderItemsList = new List<OrderItems>();
            Enquiry enquiry = new Enquiry();
            Customer customer = new Customer();
        }

        [TestMethod]
        public void ManagerModelTestClassSimpleMethods()
        { 
        
        }
    }
}
