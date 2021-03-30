//using System;
using Office.ControlForms.Annotations;
using Office.Db;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Office.ControlForms
{
    public partial class ControlEmployee : INotifyPropertyChanged
    {
        private Employee _employee;

        //public const string ConnectionString = "Data Source=127.0.0.1;Initial Catalog=Office;User ID=alexander;Password=12345678";
        public string ConnectionString = Config.ConnectionString;

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
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sqlQuery = $@"SELECT * FROM Departments";

                var command = new SqlCommand(sqlQuery, connection);

                using (var sr = command.ExecuteReader())
                {
                    if (sr.HasRows)
                    {
                        while (sr.Read())
                        {
                            var dpt = new Department
                            {
                                Id = sr.GetInt32(0),
                                Title = sr.GetString(1),
                                Description = sr.GetString(2)
                            };
                            Departments.Add(dpt);
                        }
                    }
                }

            }
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
