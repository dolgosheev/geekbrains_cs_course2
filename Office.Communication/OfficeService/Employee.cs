using System;

namespace Office.Communication.OfficeService
{
    public partial class Employee : ICloneable
    {
        private readonly OfficeServiceSoapClient _officeServiceSoapClient = new OfficeServiceSoapClient();

        public Employee()
        {
            var cnt = _officeServiceSoapClient.MaxEmployee();

            Id = cnt;
            Firstname = default;
            Lastname = default;
            Department = default;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
