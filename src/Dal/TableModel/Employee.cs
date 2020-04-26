using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.TableModel
{
    public class Employee
    {
        public Int32 EmployeeID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int32 WorkExperience { get; set; }
        public Decimal Salary { get; set; }
        public Int32 DepartmentId { get; set; }
    }
}
