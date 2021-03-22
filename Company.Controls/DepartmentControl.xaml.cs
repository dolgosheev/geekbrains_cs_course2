using Company.Database;
using System.Linq;
using System.Windows.Forms;
using Help = Company.Database.Help;

namespace Company.Controls
{
    public partial class DepartmentControl
    {
        private Department _department;
        public DepartmentControl()
        {
            InitializeComponent();
        }

        public void SetDepartment(Department department)
        {
            _department = department;

            DptTitle.Text = department.Title;
            DptDesc.Text = department.Description;
        }

        public void UpdateDepartment()
        {

            foreach (var department in Help.Departments.Where(r => r.Title == _department.Title))
            {
                department.Title = DptTitle.Text;
                department.Description = DptDesc.Text;
            }

            _department.Title = DptTitle.Text;
            _department.Description = DptDesc.Text;
        }

        public Department AddDepartment()
        {
            if (string.IsNullOrWhiteSpace(DptTitle.Text) || string.IsNullOrWhiteSpace(DptDesc.Text))
            {
                MessageBox.Show("Can't add without:  Firstname, Lastname and Department", "Error");
                return null;
            }

            _department = new Department
            {
                Title = DptTitle.Text,
                Description = DptDesc.Text
            };

            Help.Departments.Add(_department);

            return _department;
        }
    }
}
