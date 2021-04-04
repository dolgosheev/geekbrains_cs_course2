using Office.Db;
using System;
using System.Collections.ObjectModel;

namespace Office
{
    public class Database
    {
        private static readonly Random Rnd = new Random();

        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Department> Departments { get; set; }

        private static readonly Lazy<Database> LazyInstance = new Lazy<Database>(() => new Database());
        public static Database Instance => LazyInstance.Value;


        private Database()
        {
            Employees = new ObservableCollection<Employee>();

            GenerateEmployees(10);

            Departments = ExampleData.Departments;
        }

        private void GenerateEmployees(int count)
        {
            Employees.Clear();

            for (var i = 0; i < count; i++)
            {
                var employee = new Employee(
                    identify: Rnd.Next(100,2000),
                    firstname: ExampleData.FirstNames[Rnd.Next(0,ExampleData.FirstNames.Count)],
                    lastname: ExampleData.LastNames[Rnd.Next(0, ExampleData.LastNames.Count)],
                    department: ExampleData.Departments[Rnd.Next(0,ExampleData.Departments.Count)]
                    );
                Employees.Add(employee);
            }
        }
    }
}
