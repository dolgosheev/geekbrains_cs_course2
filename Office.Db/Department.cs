using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Office.Db
{
    public class Department : INotifyPropertyChanged, ICloneable
    {
        private int _id;

        [XmlIgnore]
        private readonly string _connectionString = Config.ConnectionString;

        private int GetCountDepartments()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlQuery = $@"SELECT MAX(Id) FROM Departments";

                var command = new SqlCommand(sqlQuery, connection);

                using (var sr = command.ExecuteReader())
                {
                    if (sr.HasRows)
                    {
                        while (sr.Read())
                        {
                            return sr.GetInt32(0) + 1;
                        }
                    }
                }

                return default;
            }
        }

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                NotifyPropertyChanged();
            }
        }

        private string _description;

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                NotifyPropertyChanged();
            }
        }

        public Department(int id, string title, string description)
        {
            _id = id;
            _title = title;
            _description = description;
        }

        public Department()
        {
            _id = GetCountDepartments();
            _title = default;
            _description = default;
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
