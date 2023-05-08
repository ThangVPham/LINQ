using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Student
    {
        public string FullName { get; set; }
        public List<Subject> Subjects { get; set; }
        public Student(string name, List<Subject> subjectList) 
        { 
            this.FullName = name;
            this.Subjects = subjectList;
        }
    }
}
