using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public interface IStaffModel
    { 
        //update
    }

    public class StaffModel : IStaffModel
    {

        //properties
        public int staffID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int workinghours { get; set; }
        public string addressid { get; set; }

        //empty construstor

        public StaffModel()
        {


        }

        //parametrised constor
        public StaffModel(int staffID, string firstname, string lastname, int workinghours, string addressid)
        {
            this.staffID = staffID;
            this.firstname = firstname;
            this.lastname = lastname;
            this.workinghours = workinghours;
            this.addressid = addressid;

        }


        //getters
        public string getFirstName()
        {
            return firstname;
        }
    }
}