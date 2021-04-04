using Office.Db;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;

namespace Office.WebService
{
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class OfficeService : System.Web.Services.WebService
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["OfficeConnectionString"].ConnectionString;

        #region Operations_Department

        [WebMethod]
        public List<Department> LoadFromDepartmentsDatabase()
        {
            var departmentList = new List<Department>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlQuery = $@"SELECT * FROM Departments";

                var command = new SqlCommand(sqlQuery, connection);

                using (var sr = command.ExecuteReader())
                {
                    if (sr.HasRows)
                    {
                        while (sr.Read())
                        {
                            var dpt = new Department
                            {
                                Id = sr.GetInt32(0),
                                Title = sr.GetString(1),
                                Description = sr.GetString(2)
                            };
                            departmentList.Add(dpt);
                        }
                    }
                }
            }

            return departmentList;
        }

        [WebMethod]
        public int MaxDepartment()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlQuery = $@"SELECT MAX(Id) FROM Departments";

                var command = new SqlCommand(sqlQuery, connection);

                using (var sr = command.ExecuteReader())
                {
                    if (sr.HasRows)
                    {
                        while (sr.Read())
                        {
                            return sr.GetInt32(0) + 1;
                        }
                    }
                }

                return default;
            }
        }

        [WebMethod]
        public void UpdateDepartmentInDatabase(Department department)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlQuery = $@"Update Departments SET Title = '{department.Title}',Description = '{department.Description}' Where Id = {department.Id}";

                var command = new SqlCommand(sqlQuery, connection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        [WebMethod]
        public void SaveDepartmentToDatabase(Department department)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlQuery = $@"Insert into Departments (Id,Title,Description) VALUES ({department.Id},'{department.Title}','{department.Description}')";

                var command = new SqlCommand(sqlQuery, connection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        [WebMethod]
        public void DeleteDepartmentFromDatabase(Department department)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlQuery = $@"Delete from departments Where Id = {department.Id}";

                var command = new SqlCommand(sqlQuery, connection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        #endregion

        #region Operations_Employee

        [WebMethod]
        public List<Employee> LoadFromEmployeesDatabase()
        {
            var employeeList = new List<Employee>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlQuery = $@"SELECT * FROM Employees";

                var command = new SqlCommand(sqlQuery, connection);

                using (var sr = command.ExecuteReader())
                {
                    if (sr.HasRows)
                    {
                        while (sr.Read())
                        {
                            var empl = new Employee
                            {
                                Id = sr.GetInt32(0),
                                Firstname = sr.GetString(1),
                                Lastname = sr.GetString(2),
                                Department = LoadFromDepartmentsDatabase()[sr.GetInt32(3) - 1]
                            };
                            employeeList.Add(empl);
                        }
                    }
                }

            }

            return employeeList;
        }

        [WebMethod]
        public int MaxEmployee()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlQuery = $@"SELECT MAX(Id) FROM Employees";

                var command = new SqlCommand(sqlQuery, connection);

                using (var sr = command.ExecuteReader())
                {
                    if (sr.HasRows)
                    {
                        while (sr.Read())
                        {
                            return sr.GetInt32(0) + 1;
                        }
                    }
                }

                return default;
            }
        }

        [WebMethod]
        public void UpdateEmployeeInDatabase(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlQuery = $@"Update Employees SET Firstname = '{employee.Firstname}',Lastname = '{employee.Lastname}',Department = {employee.Department.Id} Where Id = {employee.Id}";

                var command = new SqlCommand(sqlQuery, connection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        [WebMethod]
        public void SaveEmployeeToDatabase(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlQuery = $@"Insert into Employees (Id,Firstname,Lastname,Department) VALUES ({employee.Id},'{employee.Firstname}','{employee.Lastname}', {employee.Department.Id})";

                var command = new SqlCommand(sqlQuery, connection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        [WebMethod]
        public void DeleteEmployeeFromDatabase(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlQuery = $@"Delete from Employees Where Id = {employee.Id}";

                var command = new SqlCommand(sqlQuery, connection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        #endregion

    }
}
