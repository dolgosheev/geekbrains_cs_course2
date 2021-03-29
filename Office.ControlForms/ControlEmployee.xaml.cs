using Office.ControlForms.Annotations;
using Office.Db;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Office.ControlForms
{
    public partial class ControlEmployee : INotifyPropertyChanged
    {
        private Employee _employee;

        public Employee Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Department> Departments { get; set; } = ExampleData.Departments; //= new ObservableCollection<Department>(ExampleData.Departments);

        public ControlEmployee()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
