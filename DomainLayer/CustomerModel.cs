using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

// public interface 

namespace DomainLayer
{

    //Model created by Ian Kenny - however, the methods were combined into the manager
    public interface ICustomerModel
    {
        void SetCustomer(Customer customer);
        Customer GetCustomer();
        void SaveCustomer(Customer customer);
    }

    public class CustomerModel : ICustomerModel
    {

        Customer customer;
        ICustomerGateway customerCRUD;

        public CustomerModel(ICustomerGateway customerCRUD)
        {
            this.customerCRUD = customerCRUD;
        }

        public void retreieveCustomer(int id)
        {
            customer = customerCRUD.GetCustomer(id);
        }

        public void SetCustomer(Customer customer)
        {
            customer.name = "Customer";
        }

        public Customer GetCustomer()
        {
            return customer;
        }

        public void SaveCustomer(Customer customer)
        {
            customerCRUD.SaveCustomer(customer);
        }
    }
}
