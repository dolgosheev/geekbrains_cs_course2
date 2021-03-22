using System;
using Company.Database;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Company.Controls
{
    public partial class EmploeeControl
    {
        private Employee _emploee;

        public EmploeeControl()
        {
            InitializeComponent();

            UpdateCombo();
        }

        public void UpdateCombo()
        {
            ctrlDepartmentt.ItemsSource = Help.Departments.Select(r => r.Title).AsEnumerable();
        }

        public void SetEmploee(Employee employee)
        {
            UpdateCombo();

            _emploee = employee;
            
            ctrlFirstName.Text = employee.Firstname;
            ctrlLastName.Text = employee.LastName;
            ctrlAge.Text = employee.Age.ToString();
            ctrlSalary.Text = employee.Salary.ToString("C3",CultureInfo.CurrentCulture);
            ctrlExp.Text = employee.Experience.ToString();
            ctrlSecretAccess.IsChecked = employee.SecretInfoAccess;
            ctrlDepartmentt.SelectedItem = employee.Department.Title;
        }

        public void UpdateEmploee()
        {
            UpdateCombo();

            _emploee.Firstname = ctrlFirstName.Text;
            _emploee.LastName = ctrlLastName.Text;
            _emploee.Age = 
                int.TryParse(ctrlAge.Text, out var age) 
                    ? age 
                    : default(int);
            _emploee.Salary =
                double.TryParse(ctrlSalary.Text, out var sal)
                    ? sal
                    : default(double);
            _emploee.Experience =
                int.TryParse(ctrlExp.Text, out var exp)
                    ? exp
                    : default(int);
            _emploee.SecretInfoAccess = (bool)ctrlSecretAccess.IsChecked;
            _emploee.Department = Help.Departments.Where(r => r.Title == ctrlDepartmentt.SelectedItem).SingleOrDefault();
        }

        public Employee AddeEmploee()
        {
            if (string.IsNullOrWhiteSpace(ctrlFirstName.Text) || string.IsNullOrWhiteSpace(ctrlLastName.Text) || ctrlDepartmentt.SelectedItem == null)
            {
                MessageBox.Show("Can't add without:  Firstname, Lastname and Department", "Error");
                return null;
            }

            UpdateCombo();

            _emploee = new Employee();

            _emploee.Firstname = ctrlFirstName.Text;
            _emploee.LastName = ctrlLastName.Text;
            _emploee.Age =
                int.TryParse(ctrlAge.Text, out var age)
                    ? age
                    : default(int);
            _emploee.Salary =
                double.TryParse(ctrlSalary.Text, out var sal)
                    ? sal
                    : default(double);
            _emploee.Experience =
                int.TryParse(ctrlExp.Text, out var exp)
                    ? exp
                    : default(int);
            _emploee.SecretInfoAccess = (bool)ctrlSecretAccess.IsChecked;
            _emploee.Department = Help.Departments.Where(r => r.Title == ctrlDepartmentt.SelectedItem).SingleOrDefault();

            return _emploee;
        }
    }
}
