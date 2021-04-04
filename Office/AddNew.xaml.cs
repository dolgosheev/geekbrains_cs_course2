using Office.Communication.OfficeService;
using System.Windows;

namespace Office
{
    public partial class AddNew
    {
        public Employee Employee { get; set; }

        public AddNew()
        {
            InitializeComponent();
            DataContext = this;
            FormEmployee.Employee = new Employee();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FormEmployee.Employee.Firstname) ||
                string.IsNullOrWhiteSpace(FormEmployee.Employee.Lastname) || FormEmployee.Employee.Department == null)
            {
                MessageBox.Show("Can't be empty", "error");
                return;
            }

            Employee = FormEmployee.Employee;
            DialogResult = true;
        }
    }
}
