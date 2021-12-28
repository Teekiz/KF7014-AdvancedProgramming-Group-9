using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IOrderGateway
    {
        bool SaveOrder(Order order);
        List<Order> GetAllOrders();
        Order GetOrder(int id);
        bool DeleteOrder(int order);
        bool DeleteAllOrders();
    }

    public class OrderGateway : IOrderGateway
    {
        public bool SaveOrder(Order Order)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    context.Orders.Add(Order);
                    context.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

        public Order GetOrder(int id)
        {
            try
            {
                //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
                using (var context = new DatabaseEntities())
                {
                    var OrderQuery = context.Orders.Where(o => o.orderID == id).SingleOrDefault();
                    return OrderQuery;
                }
            }

            catch { return new Order(); }
        }



        public List<Order> GetAllOrders()
        {
            try
            {
                //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
                using (var context = new DatabaseEntities())
                {
                    var OrderQuery = context.Orders.ToList();
                    return OrderQuery;
                }
            }
            catch
            { return new List<Order>(); }
        }

        public bool DeleteOrder(int order)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var OrderGetQuery = context.Orders.Where(o => o.orderID == order).SingleOrDefault();
                    var OrderQuery = context.Orders.Remove(OrderGetQuery);
                    context.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

        public bool DeleteAllOrders()
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var OrderGetQuery = context.Orders.ToList();

                    foreach (Order o in OrderGetQuery)
                    {
                        context.Orders.Remove(o);
                        context.SaveChanges();
                    }

                    context.SaveChanges();

                    var newOrderGetQuery = context.Orders.ToList();
                    if (newOrderGetQuery.Count() == 0)
                    {
                        return true;
                    }

                    return false;
                }
            }

            catch { return false; }
        }
    }
}

