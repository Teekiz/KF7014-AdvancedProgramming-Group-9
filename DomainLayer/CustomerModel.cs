using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

// public interface 

namespace DomainLayer
{
    public interface ICustomerModel
    {

    }

    public class CustomerModel : ICustomerModel
    {

        Customer customer;
        IDatabaseCreateQueries create;

        public CustomerModel(IDatabaseCreateQueries create)
        {
            this.create = create;
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
            create.SaveCustomer(customer);
        }
    }
}
