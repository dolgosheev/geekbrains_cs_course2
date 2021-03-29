using Office.Db;
using System.Windows;

namespace Office
{

    public partial class AddNewDepartment
    {
        public Department Department { get; set; }
        public AddNewDepartment()
        {
            InitializeComponent();
            DataContext = this;
            DataContext = this;
            FormDepartment.Department = new Department();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            Department = FormDepartment.Department;
            DialogResult = true;
        }
    }
}
