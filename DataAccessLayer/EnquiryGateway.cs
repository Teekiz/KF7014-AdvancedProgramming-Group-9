using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IEnquiryGateway
    {
        bool SaveEnquiry(Enquiry enquiry, Customer customer);
        List<Enquiry> GetAllEnquiries();
        Enquiry GetEnquiry(int id);
        bool DeleteEnquiry(int id);
        bool DeleteAllEnquiries();
        bool UpdateEnquiry(Enquiry enquiry);
        //this is in response to the data being duplicated.
        bool SaveEnquiryAll(Enquiry enquiry, List<OrderItems> orderItems, Customer customer);
        int FindCustomerIDinEnquiry(Enquiry enquiry);
    }
    public class EnquiryGateway : IEnquiryGateway
    {

        //1) For this method I used the answer by the user Slauma (2013)
        //https://stackoverflow.com/questions/20710178/entity-framework-creates-new-duplicate-entries-for-associated-objects
        //using it for context.Customers.Attach(enquiry.Customer); to fix duplication issues

        //2) I used the website entityframeworktutorial to understand eager loading
        //https://www.entityframeworktutorial.net/eager-loading-in-entity-framework.aspx
        //this was to find the enquiry id in orders, due to the lateness in the project, this is only used in this method
        //however, I would've used this method more often.


        //Method 1) reference
        public bool SaveEnquiry(Enquiry enquiry, Customer customer)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    enquiry.Customer = customer;
                    context.Customers.Attach(enquiry.Customer);
                    context.Enquiries.Add(enquiry);
                    context.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

        //This method is a legacy method, it was used when saving all the items at once because otherwise it would create
        //duplicates, I am leaving this in here in case it needs to be used later on.
        public bool SaveEnquiryAll(Enquiry enquiry, List<OrderItems> orderItems, Customer customer)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    enquiry.Customer = customer;
                    context.Enquiries.Add(enquiry);
                    context.Customers.Add(customer);

                    for (int i = 0; i < orderItems.Count(); i++)
                    {
                        //adds all the of the items in the order to a database
                        orderItems[i].Enquiry = enquiry;
                        context.OrderItems.Add(orderItems[i]);
                    }

                    context.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

        //Method for 2) reference
        public int FindCustomerIDinEnquiry(Enquiry enquiry)
        {
            try
            {
                //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
                using (var context = new DatabaseEntities())
                {
                    var enquiryQuery = context.Enquiries.Include("Customer").Where(e => e.orderID == enquiry.orderID).SingleOrDefault();
                    return enquiryQuery.Customer.customerID;
                }
            }
            catch
            { return 0; }
        }

        public Enquiry GetEnquiry(int id)
        {
            try
            {
                //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
                using (var context = new DatabaseEntities())
                {
                    var enquiryQuery = context.Enquiries.Where(e => e.orderID == id).SingleOrDefault();
                    return enquiryQuery;
                }
            }
            catch { return new Enquiry(); }
        }

        public List<Enquiry> GetAllEnquiries()
        {
            try
            {
                //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
                using (var context = new DatabaseEntities())
                {
                    var enquiryQuery = context.Enquiries.ToList();
                    return enquiryQuery;
                }
            }

            catch { return new List<Enquiry>(); }
        }

        public bool UpdateEnquiry(Enquiry enquiry)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    //based on code from https://docs.microsoft.com/en-us/ef/core/querying/
                    var orderItemsQuery = context.Enquiries.Where(i => i.orderID == enquiry.orderID).SingleOrDefault();
                    orderItemsQuery.deadline = enquiry.deadline;
                    orderItemsQuery.price = enquiry.price;
                    orderItemsQuery.hoursToComplete = enquiry.hoursToComplete;
                    orderItemsQuery.orderStatus = enquiry.orderStatus;
                    orderItemsQuery.orderNotes = enquiry.orderNotes;
                    context.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

        public bool DeleteEnquiry(int id)
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var enquiryGetQuery = context.Enquiries.Where(e => e.orderID == id).SingleOrDefault();
                    var enquiryQuery = context.Enquiries.Remove(enquiryGetQuery);
                    context.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }
        public bool DeleteAllEnquiries()
        {
            try
            {
                using (var context = new DatabaseEntities())
                {
                    var enquiryGetQuery = context.Enquiries.ToList();

                    foreach (Enquiry e in enquiryGetQuery)
                    {
                        var enquiryQuery = context.Enquiries.Remove(e);
                    }

                    context.SaveChanges();

                    var newEnquiryGetQuery = context.Enquiries.ToList();
                    if (newEnquiryGetQuery.Count() == 0)
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
