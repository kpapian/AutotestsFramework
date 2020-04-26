using Dal.TableModel;
using Dapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Dal.Repository
{
    public class EmployeeRepository
    {
        public List<Employee> GetEmployeeInfo()
        {         
            List<Employee> result;

            String query = "SELECT * FROM Employees";

            using (SqlConnection db = new SqlConnection(DbManager.ConnectionString))
            {
                result = db.Query<Employee>(query).ToList();
            }

            if (!result.Any())
            {
                throw new Exception($"No such items by request.{Environment.NewLine} Query: {query}");               
            }

            return result;
        }

        public List<Employee> GetEmployeeInfoByDepartment(String departmentName)
        {
            List<Employee> result;

            String query = $@"SELECT e.* FROM Employees AS e
                             INNER JOIN Departments AS d ON e.DepartmentId = d.DepartmentId
                             WHERE d.DepartmentName = '{departmentName}'";

            using (SqlConnection db = new SqlConnection(DbManager.ConnectionString))
            {
                result = db.Query<Employee>(query).ToList();
            }

            if (!result.Any())
            {
                throw new Exception($"No such items by request.{Environment.NewLine} Query: {query}");
            }

            //if (!result.Any())
            //{
            //    Assert.Ignore($"No such items by request.{Environment.NewLine} Query: {query}");
            //}

            return result;
        }

        public void CreateNewEmployeeInfo(Employee employee)
        { 
            String query = $@"INSERT INTO Employees (FirstName, LastName, WorkExperience, Salary, DepartmentId)
                              VALUES ('{employee.FirstName}', '{employee.LastName}', 
                              {employee.WorkExperience}, {employee.Salary}, {employee.DepartmentId})";

            using (SqlConnection db = new SqlConnection(DbManager.ConnectionString))
            {
                db.Execute(query);
            }
        }

        public void UpdateEmployeeInfo(Employee employee)
        {
            String query = $@"UPDATE Employees 
                              SET FirstName = '{employee.FirstName}', LastName = '{employee.LastName}'
                              WHERE EmployeeId = {employee.EmployeeID}";

            using (SqlConnection db = new SqlConnection(DbManager.ConnectionString))
            {
                db.Execute(query);
            }
        }

        public void DeletEmployeeInfo(Employee employee)
        {
            String query = $@"DELETE FROM Employees WHERE EmployeeId = {employee.EmployeeID}";

            using (SqlConnection db = new SqlConnection(DbManager.ConnectionString))
            {
                db.Execute(query);
            }
        }
    }
}
