using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Office.Db
{
    public class Employee : INotifyPropertyChanged, ICloneable
    {
        private int _identify;

        public int Identify
        {
            get => _identify;
            set
            {
                _identify = value;
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


        public Employee(int identify, string firstname, string lastname, Department department)
        {
            _identify = identify;
            _firstname = firstname;
            _lastname = lastname;
            _department = department;
        }

        public Employee()
        {
            _identify = new Random().Next(100,2000);
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
