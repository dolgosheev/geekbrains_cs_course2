namespace HomeWork.Lesson2.Task1
{
    internal class EmployeeHourly : Employee
    {
        private double _salary;
        private readonly double monthHours = 20.8;
        private readonly double dayHours = 8;
        private readonly double _hourCost;

        protected sealed override double CalculateAverageSalary()
        {
            _salary = monthHours * dayHours * _hourCost;
            return _salary;
        }

        public EmployeeHourly(string fname, string sname, double hourcost) : base(fname, sname)
        {
            _hourCost = hourcost;
            CalculateAverageSalary();
        }

        public override string ToString()
        {
            return string.Format($"{Fname} {Sname} | salary - {_salary}");
        }
    }
}