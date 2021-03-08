using System;

namespace HomeWork.Lesson2.Task1
{
    internal abstract class Employee : IComparable
    {
        protected readonly string Fname;
        protected readonly string Sname;

        protected abstract double CalculateAverageSalary();

        public Employee(string fname, string sname)
        {
            Fname = fname;
            Sname = sname;
        }

        public abstract override string ToString();
        public int CompareTo(object obj)
        {
            var employee = (Employee) obj;

            var fname1 = ToString();
            var fname2 = employee.ToString();

            return string.Compare(fname1, fname2, StringComparison.Ordinal);
        }
    }
}