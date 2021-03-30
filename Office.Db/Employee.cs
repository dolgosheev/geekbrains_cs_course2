using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Office.Db
{
    public class Employee : INotifyPropertyChanged, ICloneable
    {
        private int _id;

        //public const string ConnectionString = "Data Source=127.0.0.1;Initial Catalog=Office;User ID=alexander;Password=12345678";
        public string ConnectionString = Config.ConnectionString;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }

        private string _firstname;

        public string Firstname
        {
            get => _firstname;
            set
            {
                _firstname = value;
                NotifyPropertyChanged();
            }
        }

        private string _lastname;

        public string Lastname
        {
            get => _lastname;
            set
            {
                _lastname = value;
                NotifyPropertyChanged();
            }
        }

        private Department _department;

        public Department Department
        {
            get => _department;
            set
            {
                _department = value;
                    NotifyPropertyChanged();
            }
        }


        public Employee(int id, string firstname, string lastname, Department department)
        {
            _id = id;
            _firstname = firstname;
            _lastname = lastname;
            _department = department;
        }

        private int GetCountEmployees()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sqlQuery = $@"SELECT MAX(Id) FROM Employees";

                var command = new SqlCommand(sqlQuery, connection);

                using (var sr = command.ExecuteReader())
                {
                    if (sr.HasRows)
                    {
                        while (sr.Read())
                        {
                            return sr.GetInt32(0)+1;
                        }
                    }
                }

                return default;
            }
        }

        public Employee()
        {
            _id = GetCountEmployees();
            _firstname = default;
            _lastname = default;
            _department = default;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

    }
}
