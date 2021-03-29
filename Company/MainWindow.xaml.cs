using Company.Database;
using System.Linq;
using System.Windows;

namespace Company
{

    public partial class MainWindow
    {
        private readonly CompanyDatabase _database = new CompanyDatabase(10);


        public MainWindow()
        {
            InitializeComponent();
            UpdateBindings();
        }

        private void UpdateBindings()
        {
            CompanyListView.ItemsSource = null;
            DepartmentsListView.ItemsSource = null;

            DepartmentsListView.ItemsSource = Help.Departments;
            CompanyListView.ItemsSource = _database.Employees;

        }

        private void CompanyListView_SelectionChanged(object sender,
            System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                if (DepartmentsListView.SelectedItems.Count > 0)
                    DepartmentsListView.SelectedIndex = -1;

                EmploeeControl.SetEmploee(e.AddedItems[0] as Employee);
            }
        }

        private void btnEditEmpl_Click(object sender, RoutedEventArgs e)
        {
            if (CompanyListView.SelectedItems.Count < 1)
                return;

            EmploeeControl.UpdateEmploee();
            UpdateBindings();
            MessageBox.Show("Database updated!", "info");
        }

        private void btnDelEmpl_Click(object sender, RoutedEventArgs e)
        {
            if (CompanyListView.SelectedItems.Count < 1)
                return;

            if (MessageBox.Show("Are you sure?", "Emploee delete", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _database.Employees.Remove((Employee) CompanyListView.SelectedItems[0]);
                UpdateBindings();
            }
        }

        private void btnAddEmpl_Click(object sender, RoutedEventArgs e)
        {
            var success = EmploeeControl.AddeEmploee();
            if (success != null)
            {
                _database.Employees.Add(success);
                UpdateBindings();
                MessageBox.Show("Database updated!", "info");
            }
        }

        private void DepartmentsListView_SelectionChanged(object sender,
            System.Windows.Controls.SelectionChangedEventArgs e)
        {


            if (e.AddedItems.Count != 0)
            {
                if (CompanyListView.SelectedItems.Count > 0)
                    CompanyListView.SelectedIndex = -1;

                DepartmentControl.SetDepartment(e.AddedItems[0] as Department);
            }
        }

        private void btnEditDpt_Click(object sender, RoutedEventArgs e)
        {
            if (DepartmentsListView.SelectedItems.Count < 1)
                return;

            DepartmentControl.UpdateDepartment();
            UpdateBindings();
            MessageBox.Show("Database updated!", "info");
        }

        private void btnAddDpt_Click(object sender, RoutedEventArgs e)
        {
            var success = DepartmentControl.AddDepartment();
            if (success != null)
            {
                UpdateBindings();
                MessageBox.Show("Database updated!", "info");
            }
        }

        private void btnDelDpt_Click(object sender, RoutedEventArgs e)
        {
            if (DepartmentsListView.SelectedItems.Count < 1)
                return;

            if (MessageBox.Show("Are you sure?", "Emploee delete", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var dprtmtTmp = (Department) DepartmentsListView.SelectedItems[0];


                var check2delete = _database.Employees.Where(r => r.Department == dprtmtTmp).Count();

                if (check2delete == 0)
                    Help.Departments.Remove(dprtmtTmp);
                else
                    MessageBox.Show("This department is used!","Error");
            }

            UpdateBindings();
        }
    }
}
