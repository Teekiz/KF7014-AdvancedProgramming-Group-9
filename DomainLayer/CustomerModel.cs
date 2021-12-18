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
        void SetCustomer(Customer customer);
        Customer GetCustomer();
        void SaveCustomer(Customer customer);
    }

    public class CustomerModel : ICustomerModel
    {

        Customer customer;
        IDatabaseCreateQueries create;
        IDatabaseReadQueries read;

        public CustomerModel(IDatabaseCreateQueries create, IDatabaseReadQueries read)
        {
            this.create = create;
            this.read = read;
        }

        public void retreieveCustomer(int id)
        {
            customer = read.GetCustomer(id);
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
