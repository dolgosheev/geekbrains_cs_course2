using Office.Db;
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
            Employee = FormEmployee.Employee;
            DialogResult = true;
        }
    }
}
