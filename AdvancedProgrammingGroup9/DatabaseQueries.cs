using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgrammingGroup9
{
    //spliting the datebase class into seperate classes for CRUD operations.

    public class DatabaseCreateQueries
    {
        public bool SaveEnquiry(Enquiry enquiry)
        {
            //try
            //{
                using (var context = new DatabaseEntities())
                {
                    context.Enquiry.Add(enquiry);

                    for (int i = 0; i < enquiry.countItemInOrder(); i++)
                    {
                        //adds all the of the items in the order to a database
                        context.OrderItems.Add(enquiry.getItemInOrder(i));
                    }

                    context.SaveChanges();
                    return true;
                }
            //}
            /*
            catch
            {
                return false;
            }
            */
        }      
    }

    public class DatabaseReadQueries
    {
        //blank
    }

    public class DatabaseUpdateQueries
    {
        //blank
    }

    public class DatabaseDeleteQueries
    {
        //blank
    }
}
