using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

// public interface 

namespace DomainLayer
{
    public interface IStaffModel
    {
        void SetStaff(Staff staff);
        Staff GetStaff();
        void SaveStaff(Staff staff);
    }

    public class StaffModel : IStaffModel
    {

        Staff staff;
        IDatabaseCreateQueries create;
        IDatabaseReadQueries read;

        public StaffModel(IDatabaseCreateQueries create, IDatabaseReadQueries read)
        {
            this.create = create;
            this.read = read;
        }

        public void retreieveStaff(int id)
        {
            customer = read.GetStaff(id);
        }

        public void SetCustomer(Staff staff)
        {
            staff.name = "Staff";
        }

        public Staff GetStaff()
        {
            return customer;
        }

        public void SaveStaff(Staff Staff)
        {
            create.SaveStaff(staff);
        }
    }
}
