using Office.Communication.OfficeService;
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
            if (string.IsNullOrWhiteSpace(FormDepartment.Department.Title) || string.IsNullOrWhiteSpace(FormDepartment.Department.Description))
            {
                MessageBox.Show("Can't be empty", "error");
                return;
            }

            Department = FormDepartment.Department;
            DialogResult = true;
        }
    }
}
