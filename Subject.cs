namespace LINQ
{
    public class Subject
    {
        public string SubjectName { get; set; }
        public double Grade { get; set; }

        public Subject(string subjectName, double grade)
        {
            this.SubjectName= subjectName;
            this.Grade= grade;
        }
    }
}