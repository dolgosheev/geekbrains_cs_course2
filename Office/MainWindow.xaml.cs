using Office.Db;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Office
{
    public partial class MainWindow
    {
        private readonly Database _db = Database.Instance;

        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        public Employee SelectedEmployee { get; set; }
        public Department SelectedDepartment { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            Employees = _db.Employees;
            Departments = _db.Departments;

        }

        #region Employee Control

        private void ListViewOffice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                if (ListViewDepartments.SelectedItems.Count > 0)
                {
                    FormDepartment.Department = null;
                    ListViewDepartments.SelectedIndex = -1;
                }

                FormEmployee.Employee = (Employee)SelectedEmployee.Clone();
            }

            
        }

        private void Employee_Apply(object sender, RoutedEventArgs e)
        {
            if (ListViewOffice.SelectedItems.Count < 1)
                return;

            Employees[Employees.IndexOf(SelectedEmployee)] = FormEmployee.Employee;
            FormEmployee.Employee = null;
        }

        private void Employee_New(object sender, RoutedEventArgs e)
        {
            var newEmployee = new AddNew();
            if (newEmployee.ShowDialog() == true)
            {
                _db.Employees.Add(newEmployee.Employee);
            }
        }

        private void Employee_Delete(object sender, RoutedEventArgs e)
        {
            if (ListViewOffice.SelectedItems.Count < 1)
                return;

            if (MessageBox.Show("Are you sure?", "[Delete operation]", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _db.Employees.Remove((Employee)ListViewOffice.SelectedItems[0]);
            }
        }

        #endregion

        #region Department Control

        private void ListViewDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                if (ListViewOffice.SelectedItems.Count > 0)
                {
                    FormEmployee.Employee = null;
                    ListViewOffice.SelectedIndex = -1;
                }

                FormDepartment.Department = (Department)SelectedDepartment.Clone();
            }
        }

        private void Department_Apply(object sender, RoutedEventArgs e)
        {
            if (ListViewDepartments.SelectedItems.Count < 1)
                return;

            foreach (var employeeChanged in Employees.Where(r => r.Department.Equals(SelectedDepartment)))
            {
                employeeChanged.Department = FormDepartment.Department;
            }

            Departments[Departments.IndexOf(SelectedDepartment)] = FormDepartment.Department;
            FormDepartment.Department = null;
        }

        private void Department_New(object sender, RoutedEventArgs e)
        {
            var newDepartment = new AddNewDepartment();
            if (newDepartment.ShowDialog() == true)
            {
                _db.Departments.Add(newDepartment.Department);
            }
        }

        private void Department_Delete(object sender, RoutedEventArgs e)
        {
            if (ListViewDepartments.SelectedItems.Count < 1)
                return;

            if (MessageBox.Show("Are you sure?", "[Delete operation]", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                var dprtmtTmp = (Department)ListViewDepartments.SelectedItems[0];

                var check2delete = _db.Employees.Where(r => r.Department == dprtmtTmp).Count();

                if (check2delete == 0)
                    _db.Departments.Remove(dprtmtTmp);
                else
                    MessageBox.Show("This department is used!", "Error");

            }
        }
        #endregion


    }
}
