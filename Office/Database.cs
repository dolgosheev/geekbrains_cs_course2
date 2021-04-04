using Office.Communication.OfficeService;
using System;
using System.Collections.ObjectModel;


namespace Office
{
    public class Database
    {
        private readonly OfficeServiceSoapClient _officeServiceSoapClient = new OfficeServiceSoapClient();

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
        }

        #region Operations_Department

        private void LoadFromDepartmentsDatabase()
        {
           Array.ForEach(
               _officeServiceSoapClient.LoadFromDepartmentsDatabase(),
               r=>Departments.Add(r)
               );
        }

        public void UpdateDepartmentInDatabase(Department department)
        {
            _officeServiceSoapClient.UpdateDepartmentInDatabase(department);
        }

        public void SaveDepartmentToDatabase(Department department)
        {
            _officeServiceSoapClient.SaveDepartmentToDatabase(department);
        }

        public void DeleteDepartmentFromDatabase(Department department)
        {
            _officeServiceSoapClient.DeleteDepartmentFromDatabase(department);
        }

        #endregion

        #region Operations_Employee

        private void LoadFromEmployeesDatabase()
        {
            Array.ForEach(
                _officeServiceSoapClient.LoadFromEmployeesDatabase(),
                r => Employees.Add(r)
            );
        }

        public void UpdateEmployeeInDatabase(Employee employee)
        {
            _officeServiceSoapClient.UpdateEmployeeInDatabase(employee);
        }

        public void SaveEmployeeToDatabase(Employee employee)
        {
            _officeServiceSoapClient.SaveEmployeeToDatabase(employee);
        }

        public void DeleteEmployeeFromDatabase(Employee employee)
        {
            _officeServiceSoapClient.DeleteEmployeeFromDatabase(employee);
        }

        #endregion

    }
}
