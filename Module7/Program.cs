namespace Module7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        
        //task 7.1.4

        class Employee
        {
            public string Name;
            public int Age;
            public int Salary;
        }

        class ProjectManager : Employee
        {
            public string projectName;
        }

        class Developer : Employee
        {
            public string programmingLanguage;
        }
    }
}