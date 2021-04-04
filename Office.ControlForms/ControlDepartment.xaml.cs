using Office.Communication.OfficeService;
using Office.ControlForms.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Office.ControlForms
{

    public partial class ControlDepartment : INotifyPropertyChanged
    {
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

        public ControlDepartment()
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
