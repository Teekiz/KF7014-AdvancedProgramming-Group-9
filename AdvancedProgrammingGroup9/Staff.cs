using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgrammingGroup9
{
    public class staff
    {

        //properties
        public int staffID;
        public string firstname;
        public string lastname;
        public int bankdetails;
        public int salary;
        public int workinghours;
        public int holidays;
        public int sickness;
        public string addressid;

        //empty construstor

        public staff()
        {


        }

        //parametrised constor
        public staff(int staffID, string firstname, string lastname, int bankdetails, int salary, int workinghours, int holidays, int sickness, string addressid)
        {
            this.staffID = staffID;
            this.firstname = firstname;
            this.lastname = lastname;
            this.bankdetails = bankdetails;
            this.salary = salary;
            this.workinghours = workinghours;
            this.holidays = holidays;
            this.sickness = sickness;
            this.addressid = addressid;

        }
    }
}