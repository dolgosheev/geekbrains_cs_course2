using Office.Db;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
//using System.Linq;

namespace Office
{
    public class Database
    {
        //private static readonly Random Rnd = new Random();

        //public const string ConnectionString = "Data Source=127.0.0.1;Initial Catalog=Office;User ID=alexander;Password=12345678";
        public string ConnectionString = Config.ConnectionString;

        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Department> Departments { get; set; }

        private static readonly Lazy<Database> LazyInstance = new Lazy<Database>(() => new Database());
        public static Database Instance => LazyInstance.Value;

        private Database()
        {
            Employees = new ObservableCollection<Employee>();
            Departments = new ObservableCollection<Department>();

            LoadFromDepartmentsDatabase();
            LoadFromEmployeesDatabase();
            
            #region deprecated

            //GenerateEmployees(10);

            //Departments = ExampleData.Departments;

            // Just for filling
            //SyncDatabase();

            #endregion
        }

        #region deprecated

        //private void GenerateEmployees(int count)
        //{
        //    Employees.Clear();

        //    for (var i = 0; i < count; i++)
        //    {
        //        var employee = new Employee(
        //            id: Rnd.Next(100, 2000),
        //            firstname: ExampleData.FirstNames[Rnd.Next(0, ExampleData.FirstNames.Count)],
        //            lastname: ExampleData.LastNames[Rnd.Next(0, ExampleData.LastNames.Count)],
        //            department: ExampleData.Departments[Rnd.Next(0, ExampleData.Departments.Count)]
        //        );
        //        Employees.Add(employee);
        //    }
        //}

        //public void SyncDatabase()
        //{
        //    Departments.ToList().ForEach(department => AddDepartment(department));
        //    Employees.ToList().ForEach(employee => AddEmployee(employee));
        //}

        //public int AddDepartment(Department department)
        //{
        //    int comparedInsert = 0;
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string sqlQuery = $@"INSERT INTO Departments (Id,Title,Description) VALUES ({department.Id},'{department.Title}','{department.Description}')";

        //        var command = new SqlCommand(sqlQuery, connection);

        //        try
        //        {
        //            comparedInsert = command.ExecuteNonQuery();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //        }

        //        if(comparedInsert > 0)
        //            Departments.Add(department);
        //    }

        //    return comparedInsert;
        //}

        //public int AddEmployee(Employee employee)
        //{
        //    int comparedInsert = 0;
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        string sqlQuery = $@"INSERT INTO Employees (Id,Firstname,Lastname,Department) VALUES ({employee.Id},'{employee.Firstname}','{employee.Lastname}',(select id from Departments D where D.Title = '{employee.Department.Title}'))";

        //        var command = new SqlCommand(sqlQuery, connection);

        //        try
        //        {
        //            comparedInsert = command.ExecuteNonQuery();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //        }

        //        if(comparedInsert > 0)
        //            Employees.Add(employee);
        //    }

        //    return comparedInsert;
        //}

        #endregion

        private void LoadFromDepartmentsDatabase()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = $@"SELECT * FROM Departments";

                var command = new SqlCommand(sqlQuery, connection);

                using (SqlDataReader sr = command.ExecuteReader())
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
                            Departments.Add(dpt);
                        }
                    }
                }

            }
        }

        public void UpdateDepartmentInDatabase(Department department)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = $@"Update Departments SET Title = '{department.Title}',Description = '{department.Description}' Where Id = {department.Id}";

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

        public void SaveDepartmentToDatabase(Department department)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = $@"Insert into Departments (Id,Title,Description) VALUES ({department.Id},'{department.Title}','{department.Description}')";

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

        public void DeleteDepartmentFromDatabase(Department department)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = $@"Delete from departments Where Id = {department.Id}";

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

        #region Operations_Employee

        private void LoadFromEmployeesDatabase()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = $@"SELECT * FROM Employees";

                var command = new SqlCommand(sqlQuery, connection);

                using (SqlDataReader sr = command.ExecuteReader())
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
                                Department = Departments[sr.GetInt32(3) - 1]
                            };
                            Employees.Add(empl);
                        }
                    }
                }

            }
        }

        public void UpdateEmployeeInDatabase(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = $@"Update Employees SET Firstname = '{employee.Firstname}',Lastname = '{employee.Lastname}',Department = {employee.Department.Id} Where Id = {employee.Id}";

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

        public void SaveEmployeeToDatabase(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = $@"Insert into Employees (Id,Firstname,Lastname,Department) VALUES ({employee.Id},'{employee.Firstname}','{employee.Lastname}', {employee.Department.Id})";

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

        public void DeleteEmployeeFromDatabase(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = $@"Delete from Employees Where Id = {employee.Id}";

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
