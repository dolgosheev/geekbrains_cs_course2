namespace Company.Database
{
    public class Department
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Department(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public Department()
        {
            
        }
    }
}
