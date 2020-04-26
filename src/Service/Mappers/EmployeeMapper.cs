using Dal.TableModel;
using Service.BusinessObjects;
using System.Collections.Generic;

namespace Service.Mappers
{
    public static class EmployeeMapper
    {       
        public static EmployeeBo ToEmployeeBo(this Employee employee)
        {
            if (employee == null)
            {
                return null;
            }

            EmployeeBo employeeBo = new EmployeeBo();
            employeeBo.EmployeeID = employee.EmployeeID;
            employeeBo.FirstName = employee.FirstName;
            employeeBo.LastName = employee.LastName;
            employeeBo.WorkExperience = employee.WorkExperience;
            employeeBo.Salary = employee.Salary;
            employeeBo.DepartmentId = employee.DepartmentId;

            return employeeBo;
        }

        public static Employee ToEmployee(this EmployeeBo employeeBo)
        {
            if (employeeBo == null)
            {
                return null;
            }

            Employee employee = new Employee();
            employee.EmployeeID = employeeBo.EmployeeID;
            employee.FirstName = employeeBo.FirstName;
            employee.LastName = employeeBo.LastName;
            employee.WorkExperience = employeeBo.WorkExperience;
            employee.Salary = employeeBo.Salary;
            employee.DepartmentId = employeeBo.DepartmentId;

            return employee;
        }

        public static List<EmployeeBo> ToEmployeeListBo(this List<Employee> employeeList)
        {
            List<EmployeeBo> employeeBoList = new List<EmployeeBo>();

            foreach (Employee employee in employeeList)
            {
                employeeBoList.Add(ToEmployeeBo(employee));
            }

            return employeeBoList;
        }

        //public static List<EmployeeBo> ToEmployeeListBo(this List<Employee> employeeList)
        //{
        //    return employeeList?.Select(ToEmployeeBo).ToList();
        //}
    }
}
