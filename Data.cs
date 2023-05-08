using System.Collections;

namespace LINQ
{
    public partial class Program
    {
        public static class Data
        {
            public static List<Employee> GetEmployees()
            {
                List<Employee> employees = new List<Employee>();

                Employee employee = new Employee
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Jones",
                    AnnualSalary = 60000.3m,
                    IsManager = true,
                    DepartmentId = 1
                };
                employees.Add(employee);
                employee = new Employee
                {
                    Id = 2,
                    FirstName = "Sarah",
                    LastName = "Jameson",
                    AnnualSalary = 80000.1m,
                    IsManager = true,
                    DepartmentId = 3
                };
                employees.Add(employee);
                employee = new Employee
                {
                    Id = 3,
                    FirstName = "Douglas",
                    LastName = "Roberts",
                    AnnualSalary = 40000.2m,
                    IsManager = false,
                    DepartmentId = 2
                };
                employees.Add(employee);
                employee = new Employee
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Stevens",
                    AnnualSalary = 30000.2m,
                    IsManager = false,
                    DepartmentId = 3
                };
                employees.Add(employee);

                employee = new Employee
                {
                    Id = 5,
                    FirstName = "John",
                    LastName = "Doe",
                    AnnualSalary = 30000.2m,
                    IsManager = false,
                    DepartmentId = 3
                };
                employees.Add(employee);

                return employees;
            }

            public static List<Department> GetDepartments()
            {
                List<Department> departments = new List<Department>();

                Department department = new Department
                {
                    Id = 1,
                    ShortName = "HR",
                    LongName = "Human Resources"
                };
                departments.Add(department);
                department = new Department
                {
                    Id = 2,
                    ShortName = "FN",
                    LongName = "Finance"
                };
                departments.Add(department);
                department = new Department
                {
                    Id = 3,
                    ShortName = "TE",
                    LongName = "Technology"
                };
                departments.Add(department);

                return departments;
            }
            public static List<Student> PopulateStudentList()
            {
                List<Student> studentList = new List<Student>()
                {
                    new("Adam Smith", new List<Subject>()
                    {
                        new ("Math", 69),
                        new ("Physics", 71),
                        new ("History", 75),
                        new("English",55)
                    }),
                    new("George Washinton", new List<Subject>()
                    {
                        new ("Math", 86),
                        new ("Physics", 64),
                        new ("History", 97),
                        new("English",75)
                    }),new("John Kennedy", new List<Subject>()
                    {
                        new ("Math", 75),
                        new ("Physics", 89),
                        new ("History", 77),
                        new("English",88)
                    }),
                    new("Richard Nixon", new List<Subject>()
                    {
                        new ("Math", 84),
                        new ("Physics", 90),
                        new ("History", 89),
                        new("English",76)
                    }),
                    new("Gerald Ford", new List<Subject>()
                    {
                        new ("Math", 100),
                        new ("Physics", 98),
                        new ("History", 87),
                        new("English",80)
                    }),
                    new("George Bush", new List<Subject>()
                    {
                        new ("Math", 87),
                        new ("Physics", 75),
                        new ("History", 56),
                        new("English",80)
                    }),new("Bill Clinton", new List<Subject>()
                    {
                        new ("Math", 90),
                        new ("Physics", 78),
                        new ("History", 98),
                        new("English",86)
                    })
                };
                return studentList;
            }
            public static ArrayList GetHerogenousDataCollection()
            {
                ArrayList arrayList = new ArrayList();
                arrayList.Add(100);
                arrayList.Add("Bob Jones");
                arrayList.Add(2000);
                arrayList.Add(3000);
                arrayList.Add("Bill Henderson");
                arrayList.Add(new Employee { Id = 6, FirstName = "Jennifer", LastName = "Dale", AnnualSalary=90000, IsManager = true, DepartmentId = 1  });
                arrayList.Add(new Employee { Id = 7, FirstName = "Dane", LastName = "Hughes", AnnualSalary = 60000, IsManager = false, DepartmentId = 2 });
                arrayList.Add(new Department {  Id = 4, ShortName="MKT", LongName = "Marketing"});
                arrayList.Add(new Department { Id = 5, ShortName = "R&D", LongName = "Research and Development" });
                arrayList.Add(new Department { Id = 6, ShortName = "PRD", LongName = "Production" });
                return arrayList;
            }
        }
    }
}
