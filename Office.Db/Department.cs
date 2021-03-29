using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Office.Db
{
    public class Department : INotifyPropertyChanged, ICloneable
    {
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

        public Department(string title, string description)
        {
            _title = title;
            _description = description;
        }

        public Department()
        {
            _title = "[Title]";
            _description = "[Description]";
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
