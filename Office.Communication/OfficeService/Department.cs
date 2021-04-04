using System;

namespace Office.Communication.OfficeService
{
    public partial class Department : ICloneable
    {
        private readonly OfficeServiceSoapClient _officeServiceSoapClient = new OfficeServiceSoapClient();

        public Department(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public Department()
        {
            var cnt = _officeServiceSoapClient.MaxDepartment();
            Id = cnt;
            Title = default;
            Description = default;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
