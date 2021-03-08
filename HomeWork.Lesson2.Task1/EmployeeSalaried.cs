namespace HomeWork.Lesson2.Task1
{
    internal class EmployeeSalaried : Employee
    {
        private readonly double salary = 1000.2f;

        protected sealed override double CalculateAverageSalary()
        {
            return salary;
        }


        public EmployeeSalaried(string fname, string sname) : base(fname, sname)
        {
            CalculateAverageSalary();
        }

        public override string ToString()
        {
            return string.Format($"{Fname} {Sname} | salary - {salary}");
        }
    }
}