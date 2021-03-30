using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Office.Db
{
    public static class ExampleData
    {
        public static List<string> FirstNames = new List<string> { "Anthony", "Brian", "Charles", "Christopher", "Daniel", "David", "Donald", "Edward", "George", "James", "Jason", "Jeff", "John", "Joseph", "Kenneth", "Kevin", "Mark", "Michael", "Paul", "Richard", "Robert", "Ronald", "Steven", "Thomas", "William" };

        public static List<string> LastNames = new List<string> { "Adams", "Allen", "Anderson", "Baker", "Brown", "Campbell", "Carter", "Clark", "Davis", "Flores", "Garcia", "Gonzalez", "Green", "Hall", "Harris", "Hernandez", "Hill", "Jackson", "Johnson", "Jones", "King", "Lee", "Lewis", "Lopez", "Martin", "Martinez", "Miller", "Mitchell", "Moore", "Nelson", "Nguyen", "Perez", "Ramirez", "Rivera", "Roberts", "Robinson", "Rodriguez", "Sanchez", "Scott", "Smith", "Taylor", "Thomas", "Thompson", "Torres", "Walker", "White", "Williams", "Wilson", "Wright", "Young" };

        public static ObservableCollection<Department> Departments = new ObservableCollection<Department>()
        {
            new Department(1,"IT","Internet tech"),
            new Department(2,"Support","Tech Support"),
            new Department(3,"Operator","Sales"),
            new Department(4,"Manager","Maintaners")
        };

    }

}
