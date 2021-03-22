namespace Company.Database
{
    public class Employee
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; } = default(int);
        public int Experience { get; set; } = default(int);

        public double Salary { get; set; } = default(double);
        public Department Department { get; set; }

        public bool SecretInfoAccess { get; set; } = false;

        public string AbsoluteName => $"{Firstname} {LastName}";

        public Employee(string firstname, string lastName, int age, int experience, double salary, Department department,bool SecretInfoAccess = false)
        {
            Firstname = firstname;
            LastName = lastName;
            Age = age;
            Experience = experience;
            Salary = salary;
            Department = department;
        }

        public Employee()
        {
        }
    }
}
