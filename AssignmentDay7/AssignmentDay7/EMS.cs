using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDay7
{
    struct Employee
    {
        public string Name { get; set; }
        public DateTime JoiningDate { get; set; }

        public Employee(string name, DateTime joindate)
        {
            Name = name;
            JoiningDate = joindate;
        }

        public int getHowMuchExp()
        {
            return DateTime.Now.Year - JoiningDate.Year;
        }
    }
   
}
