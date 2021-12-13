using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DomainLayer;

namespace AdvancedProgrammingGroup9TestProject
{
    [TestClass]
    class StaffCustomerTestClass
    {
        Customer customer;
        Staff staff;

        [TestInitialize]
        public void TestInitialize()
        {
            //customer
            //staff
        }

        [TestCleanup]
        public void TestCleanup()
        {
            customer = null;
            staff = null;
        }

        [TestMethod]
        public void StaffTesting()
        {
            //
        }

        [TestMethod]
        public void CustomerTesting()
        {
            //
        }
    }
}
