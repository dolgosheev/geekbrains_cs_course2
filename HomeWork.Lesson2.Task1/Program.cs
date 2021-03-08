/*
 * Author : Alexander Dolgosheev
 * Github : https://github.com/dolgosheev
 * Mailto : alexanderdolgosheev@gmail.com
 * Lesson 2
 * Task 1
 */

using System;

namespace HomeWork.Lesson2.Task1
{
    internal class Program
    {
        private static void Main()
        {

            Employee[] employeesArray = {
                new EmployeeHourly("Artemii", "Lebedev", 1.2),
                new EmployeeHourly("Alexander", "Dolgosheev", 13.2),
                new EmployeeSalaried("Steve", "Jobs")
            };

            Array.Sort(employeesArray);

            foreach (var e in employeesArray)
                Console.WriteLine(e.ToString());

            Console.WriteLine("\n*******************\n");

            var employees = new Employees
            { new EmployeeHourly("Artemii", "Lebedev", 1.2),
                new EmployeeHourly("Alexander", "Dolgosheev", 13.2),
                new EmployeeSalaried("Steve", "Jobs")
            };

            foreach (var e in employees)
                Console.WriteLine(e.ToString());

            Console.ReadKey();
        }
    }
}
