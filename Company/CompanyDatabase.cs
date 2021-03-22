using Company.Database;
using System;
using System.Collections.Generic;

namespace Company
{
    public class CompanyDatabase
    {


        private static readonly Random Rand = new Random();

        public List<Employee> Employees;

        public CompanyDatabase(int count)
        {
            Employees = GenerateEmploees(count);
        }

        private List<Employee> GenerateEmploees(int count)
        {
            var returnList = new List<Employee>();

            for (var i = 0; i < count; i++)
            {

                var emploee = new Employee(
                    Help.FirstNames[Rand.Next(0, Help.FirstNames.Count)], 
                    Help.LastNames[Rand.Next(0, Help.LastNames.Count)],
                    Rand.Next(40,65),
                    Rand.Next(1,10),
                    Rand.NextDouble()*1000,
                    Help.Departments[Rand.Next(0,3)]);

                returnList.Add(emploee);
            }

            return returnList;
        }
    }
}
