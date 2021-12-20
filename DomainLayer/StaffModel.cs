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
            //TODO staff = read.GetStaff(id);
        }

        public void SetStaff(Staff staff)
        {
            //TODOstaff.name = "Staff";
        }

        public Staff GetStaff()
        {
            return staff;
        }

        public void SaveStaff(Staff Staff)
        {
            //TODO create.SaveStaff(staff);
        }
    }
}
