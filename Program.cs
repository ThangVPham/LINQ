using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace LINQ
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();
            List<Student> studentList = Data.PopulateStudentList();
            //-----------------------------------------------------------------------------//
            // Method Syntax
            var result = employeeList.Select(e => new
            {
                FullName = e.FirstName + " " + e.LastName,
                Salary = e.AnnualSalary
            }).Where(e => e.Salary >= 50000);

            ////LINQ Query Syntax
            var result2 = from emp in employeeList
                          where emp.AnnualSalary >= 50000
                          select new
                          {
                              FullName = emp.FirstName + " " + emp.LastName,
                              Salary = emp.AnnualSalary
                          };

            var result3 = from emp in employeeList.GetHighSalariedEmployees()
                          select new
                          {
                              FullName = emp.FirstName + " " + emp.LastName,
                              Salary = emp.AnnualSalary
                          };

            ////LINQ syntax are deferred until its called upon in foreach loop
            ///
            //employeeList.Add(new Employee
            //{
            //    Id = 5,
            //    FirstName = "Sam",
            //    LastName = "Davis",
            //    AnnualSalary = 100000,
            //    IsManager = true,
            //    DepartmentId = 2
            //});
            //foreach (var item in result3)
            //{
            //    Console.WriteLine(item.FullName + ": " + item.Salary);
            //}

            //-----------------------------------------------------------------------------//

            //Immediate Execution Example
            //var result4 = (from emp in employeeList.GetHighSalariedEmployees()
            //               select new
            //               {
            //                   FullName = emp.FirstName + " " + emp.LastName,
            //                   Salary = emp.AnnualSalary
            //               }).ToList();
            //employeeList.Add(new Employee
            //{
            //    Id = 5,
            //    FirstName = "Samuel",
            //    LastName = "Jackson",
            //    AnnualSalary = 100000,
            //    IsManager = true,
            //    DepartmentId = 2
            //});
            ////New employee is not reflected in the result because the querry has already been executed and result returned before new employee was added
            //foreach (var item in result4)
            //{
            //    Console.WriteLine(item.FullName + ": " + item.Salary);
            //}

            //----------------------------------------------------------------------------//
            //******LINQ INNER JOIN Operation******
            //LINQ Method Syntax
            var result5 = departmentList.Join(employeeList,
                            department => department.Id,
                            employee => employee.DepartmentId,
                            (department, employee) =>
                            new
                            {
                                FullName = employee.FirstName + " " + employee.LastName,
                                Salary = employee.AnnualSalary,
                                DepartmentName = department.LongName
                            });
            //LINQ Query Syntax
            var result6 = from dep in departmentList
                          join emp in employeeList
                          on dep.Id equals emp.Id
                          select new
                          {
                              FullName = emp.FirstName + " " + emp.LastName,
                              Salary = emp.AnnualSalary,
                              DepartmentName = dep.LongName
                          };
            //foreach (var emp in result6)
            //{
            //    Console.WriteLine($"Name:{emp.FullName,-20}. Salary: {emp.Salary,-10}. Department: {emp.DepartmentName}");
            //}

            //******LINQ OUTER JOIN******
            //Method Syntax - Using GroupJoin()
            var result7 = departmentList.GroupJoin(employeeList,
                          dep => dep.Id,
                          emp => emp.DepartmentId,
                          (dep, empGroup) =>
                          new
                          {
                              Employees = empGroup,             //This return a group of employees that belong to this departmentId
                              DepartmentName = dep.LongName
                          });
            //Query Syntax
            var result8 = from d in departmentList
                          join e in employeeList
                          on d.Id equals e.DepartmentId
                          into employeeGroup
                          select new
                          {
                              Employees = employeeGroup,       //This return a group of employees that belong to this departmentId for query syntax
                              DepartmentName = d.LongName
                          };
            //foreach (var item in result8)
            //{
            //    Console.WriteLine($"Department: {item.DepartmentName}");
            //    foreach (var emp in item.Employees)
            //    {
            //        Console.WriteLine($"{emp.FirstName} {emp.LastName}");
            //    }
            //}

            //------------------------------------------------------------------------------//
            //******LINQ Operators******
            //Method Syntax - ORDERBY/ORDERBYDESCENDING
            var result9 = employeeList.Join(departmentList,
                          e => e.DepartmentId,
                          d => d.Id,
                          (e, d) =>
                          new
                          {
                              Id = e.Id,
                              FirstName = e.FirstName,
                              LastName = e.LastName,
                              Salary = e.AnnualSalary,
                              DepartmentId = d.Id,
                              DepartmentName = d.LongName
                          }).OrderBy(item => item.Salary).ThenBy(item => item.LastName); //Order the result by salary then by last name
            //Query Syntax - ORDERBY/ORDERBYDESCENDING
            var result10 = from e in employeeList
                           join d in departmentList
                           on e.DepartmentId equals d.Id
                           orderby e.AnnualSalary, e.LastName
                           select new
                           {
                               Id = e.Id,
                               FirstName = e.FirstName,
                               LastName = e.LastName,
                               Salary = e.AnnualSalary,
                               DepartmentId = d.Id,
                               DepartmentName = d.LongName
                           };
            //foreach (var emp in result10)
            //{
            //    Console.WriteLine($"ID:{emp.Id, - 5} First Name:{emp.FirstName,-10} Last Name:{emp.LastName,-10} Annual Salary:{emp.Salary,10} \tDepartment Name:{emp.DepartmentName}");
            //}

            //Method Syntax - GROUPBY (Deferred execution)
            var result11 = from e in employeeList
                           orderby e.DepartmentId
                           group e by e.DepartmentId;

            //Query Syntax - GROUPBY 
            var result12 = employeeList.OrderBy(e => e.DepartmentId).GroupBy(e => e.DepartmentId);

            //Method Syntax - TOLOOKUP  (Immediate execution)
            var result13 = employeeList.OrderBy(e => e.DepartmentId).ToLookup(e => e.DepartmentId);

            //foreach (var item in result13)
            //{
            //    Console.WriteLine($"Department ID:{item.Key}");
            //    foreach (var e in item)
            //    {
            //        Console.WriteLine($"\tFull Name: {e.FirstName} {e.LastName}");
            //    }
            //}

            //All,Any, Contains Operators
            //All and Any Operators
            var annualSalaryCompare = 400000;
            bool isTrueAll = employeeList.All(e => e.AnnualSalary > annualSalaryCompare);
            //if (isTrueAll)
            //{
            //    Console.WriteLine($"All employees annual salary are above {annualSalaryCompare}");
            //}
            //else
            //{
            //    Console.WriteLine($"Not all employees annual salary are above {annualSalaryCompare}");
            //}
            bool isTrueAny = employeeList.Any(e => e.AnnualSalary > annualSalaryCompare);
            //if (isTrueAny)
            //{
            //    Console.WriteLine($"At least one employee annual salary is above {annualSalaryCompare}");
            //}
            //else
            //{
            //    Console.WriteLine($"Not a single employee's annual salary is above {annualSalaryCompare}");
            //}

            //Contains Operator
            var searchEmployee = new Employee()
            {
                Id = 3,
                FirstName = "Douglas",
                LastName = "Roberts",
                AnnualSalary = 40000.2m,
                IsManager = false,
                DepartmentId = 1
            };
            bool containsEmployee = employeeList.Contains(searchEmployee, new EmployeeComparer());
            //Console.WriteLine(containsEmployee);

            //OFTYPE filter Operator
            ArrayList mixedCollection = Data.GetHerogenousDataCollection();
            var stringResult = from s in mixedCollection.OfType<string>() //Filter out items of type 'string' inside of mixed collection
                               select s;
            var intResult = from s in mixedCollection.OfType<int>() //Filter out items of type 'int' inside of mixed collection
                            select s;
            var employeeResult = from s in mixedCollection.OfType<Employee>() //Filter out items of type 'Employee' inside of mixed collection
                                 select s;
            var departmentResult = from s in mixedCollection.OfType<Department>() //Filter out items of type 'Department' inside of mixed collection
                                   select s;

            //foreach (var item in departmentResult)
            //{
            //    Console.WriteLine(item.LongName);
            //}



            var highestMathGrade = studentList.OrderByDescending(student => student.Subjects.FirstOrDefault(subject => subject.SubjectName == "Math")?.Grade).FirstOrDefault();
            var personHighestAverageGrade = studentList.OrderByDescending(student => student.Subjects.Average(sub => sub.Grade)).FirstOrDefault();
            var average = studentList.Select(student => student.Subjects.Average(sub => sub.Grade)).Max();
            bool value = studentList.Any(student => student.Subjects.FirstOrDefault(sub => sub.SubjectName == "Math")?.Grade ==100);
            if (value)
            {
                Console.WriteLine("Someone got perfect in math");
            }
            else
            {
                Console.WriteLine("Noone got perfect in math");
            }
            Console.WriteLine(personHighestAverageGrade?.FullName);
            Console.WriteLine(average);
            
        }
    }
    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y)
        {
            return ((x?.FirstName.ToLower() == y?.FirstName.ToLower()) && (x?.LastName.ToLower() == y?.LastName.ToLower()));
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    public static class EnumerableCollectionExtensionMethods
    {
        public static IEnumerable<Employee> GetHighSalariedEmployees(this IEnumerable<Employee> employees)
        {
            foreach (Employee e in employees)
            {
                Console.WriteLine($"Accessing employee: {e.FirstName} {e.LastName}");
                if (e.AnnualSalary >= 50000)
                {
                    // 'yield' keyword allows the method to return a sequence of values without having to create a collection to hold all the values in memory at once
                    // the values are generated on-the-fly as they are requested by the caller
                    yield return e;
                }
            }
        }
    }

}
