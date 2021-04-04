using Office.Communication.OfficeService;
using Office.ControlForms.Annotations;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Office.ControlForms
{
    public partial class ControlEmployee : INotifyPropertyChanged
    {
        private Employee _employee;

        private readonly OfficeServiceSoapClient _officeServiceSoapClient = new OfficeServiceSoapClient();

        private bool UpdFlag { get; set; }
        public bool Update
        {
            get => UpdFlag;
            set
            {
                _contentLoaded = value;
                Departments.Clear();
                LoadFromDepartmentsDatabase();
                UpdFlag = false;
            }
        }


        private void LoadFromDepartmentsDatabase()
        {
            Array.ForEach(
                _officeServiceSoapClient.LoadFromDepartmentsDatabase(),
                r => Departments.Add(r)
            );
        }

        public Employee Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Department> Departments { get; set; } = new ObservableCollection<Department>();

        public ControlEmployee()
        {
            InitializeComponent();

            LoadFromDepartmentsDatabase();

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
