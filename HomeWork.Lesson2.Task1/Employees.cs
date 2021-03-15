using System.Collections;
using System.Collections.Generic;

namespace HomeWork.Lesson2.Task1
{
    internal class Employees : IEnumerable
    {
        private readonly List<Employee> _memrList = new List<Employee>();

        public void Add(Employee employee)
        {
            _memrList.Add(employee);
        }

        /* classic */
        //public  IEnumerator GetEnumerator()
        //{
        //    return _memrList.GetEnumerator();
        //}

        /* senior candidate method */
        public IEnumerator GetEnumerator()
        {
            foreach (var member in _memrList)
                yield return member;
        }

    }
}