using Dal.Repository;
using Dal.TableModel;
using Service.BusinessObjects;
using Service.Mappers;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class EmployeeService
    {
        private EmployeeRepository _employeeRepository;

        public List<EmployeeBo> GetEmployeeInfo()
        {
            return EmployeeRepository.GetEmployeeInfo().ToEmployeeListBo();
        }

        public List<EmployeeBo> GetEmployeeInfoByDepartment(String depatmentName)
        {
            return EmployeeRepository.GetEmployeeInfoByDepartment(depatmentName).ToEmployeeListBo();
        }

        public void CreateNewEmployee(EmployeeBo employee)
        {
             EmployeeRepository.CreateNewEmployeeInfo(employee.ToEmployee());
        }

        public EmployeeRepository EmployeeRepository => _employeeRepository ?? (_employeeRepository = new EmployeeRepository());
    }
}
