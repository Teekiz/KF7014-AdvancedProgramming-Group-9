using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using DataAccessLayer;

namespace PresentationLayer
{
    public class Presentation
    {
        private ICustomerModel customerModel;
        private IOrderCust screen;
        Customer Customer;

        public Presentation(ICustomerModel model, IOrderCust screen)
        {
            customerModel = model;
            this.screen = screen;
            screen.register(this);
            Customer = customerModel.GetCustomer();
        }

        public Customer createCustomer()
        {
            Customer.name = screen.name;
            Customer.address = screen.address;
            Customer.country = screen.country;
            return Customer;
        }

        public void saveCustomer()
        {
            Customer c = new Customer();
            c.name = screen.name;
            c.address = screen.address;
            c.country = screen.country;
            customerModel.SaveCustomer(c);
        }
    }
}
