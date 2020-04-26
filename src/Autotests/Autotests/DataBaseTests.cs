using NUnit.Framework;
using Service.BusinessObjects;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.Autotests
{
    /// <summary>
    /// Tests here doesn't test DB. 
    /// They shows how to work with DB and use results for autotests.
    /// </summary>
    [Ignore("Need to set up an instance of DB")]
    public class DataBaseTests : BaseTest
    {
        private EmployeeService _employeeService;
        private ProductService _productService;

        [Test]
        [Description(@"
        Test steps:
        1. Get employee info from DB.
        2. Multiply employee work experience * coeff.
            Check:           
            - Salary is correct.")]
        public void CheckEmployeeSalaryCalculation()
        {
            #region Preconditions
            Int32 coeff = 300;
            #endregion

            List<EmployeeBo> employeeList = EmployeeService.GetEmployeeInfo();

            foreach (EmployeeBo employee in employeeList)
            {
                Int32 salaryCalculation = employee.WorkExperience * coeff;

                Assert.AreEqual(salaryCalculation, employee.Salary,
                       "Salary is correct.");
            }
        }

        [Test]
        [Description(@"
        Test steps:
        1. Get count of employee from DB for Service Department.
        2. Add new employee for Service department.
            Check:           
            - Count of employee for Service Department has been changed;
            - Data was added to DB with appropriate First Name;
            - Data was added to DB with appropriate Last Name.")]
        public void AddNewEmployeeDataToDb()
        {
            #region Preconditions
            Random random = new Random();
            Int32 changesMark = random.Next(100, 999);

            String departmentName = "Service";

            EmployeeBo employeeNewData = new EmployeeBo
            {
                FirstName = $"Artem {changesMark}",
                LastName = $"Ivanov {changesMark}",
                WorkExperience = 4,
                Salary = 1200,
                DepartmentId = 2
            };
            #endregion

            Int32 employeeCountForServiceDepartment = EmployeeService.GetEmployeeInfoByDepartment(departmentName).Count;

            EmployeeService.CreateNewEmployee(employeeNewData);

            Int32 employeeCountAfterAddNewEmployee = EmployeeService.GetEmployeeInfoByDepartment(departmentName).Count;

            EmployeeBo addedEmployee = EmployeeService.GetEmployeeInfo()
                                       .Where(x => x.FirstName == employeeNewData.FirstName).FirstOrDefault();

            Assert.AreEqual(employeeCountAfterAddNewEmployee - 1 , employeeCountForServiceDepartment,
                   "Count of employee for Service Department has been changed.");

            Assert.AreEqual(employeeNewData.FirstName, addedEmployee.FirstName,
                   "Data was added to DB with appropriate First Name.");

            Assert.AreEqual(employeeNewData.LastName, addedEmployee.LastName,
                   "Data was added to DB with appropriate Last Name.");
        }

        [Test]
        [Description(@"
        Test steps:
        1. Get product info from DB by search condition.
        2. Update product with new data.
            Check:
            - Price was updated for product into DB.")]
        public void UpdateProductData()
        {
            #region Preconditions
            Random random = new Random(); 
            Decimal priceNew = random.Next(100, 999);
            #endregion

            ProductInfo productDataBeforUpdate = ProductService.GetProductInfo();

            ProductService.UpdateProductInfo(new ProductInfo
            { ProductId = productDataBeforUpdate.ProductId, Price = priceNew });

            ProductInfo productDataAfterUpdate = ProductService.GetProductInfoById(productDataBeforUpdate.ProductId);

            Assert.AreEqual(priceNew, productDataAfterUpdate.Price,
                   "Price was updated for product into DB");
        }

        private EmployeeService EmployeeService => _employeeService ?? (_employeeService = new EmployeeService());
        private ProductService ProductService => _productService ?? (_productService = new ProductService());
    }
}
