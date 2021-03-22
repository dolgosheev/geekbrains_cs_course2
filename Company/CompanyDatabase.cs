using System;
using Company.Database;
using System.Collections.Generic;

namespace Company
{
    public class CompanyDatabase
    {


        private static Random rand = new Random();

        public List<Employee> Employees;

        public CompanyDatabase(int count)
        {
            Employees = GenerateEmploees(count);
        }

        private List<Employee> GenerateEmploees(int count)
        {
            var returnList = new List<Employee>();

            for (int i = 0; i < count; i++)
            {

                var emploee = new Employee(
                    Help.FirstNames[rand.Next(0, Help.FirstNames.Count)], 
                    Help.LastNames[rand.Next(0, Help.LastNames.Count)],
                    rand.Next(40,65),
                    rand.Next(1,10),
                    rand.NextDouble()*1000,
                    Help.Departments[rand.Next(0,3)]);

                returnList.Add(emploee);
            }

            return returnList;
        }
    }
}
