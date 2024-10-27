namespace CourseManagement.Models
{
    internal class Student
    {
        public string Name;
        public string Surname;
        public string GroupNo;
        public string Type;

        public Student(string name, string surname, string type)
        {
            Name = name;
            Surname = surname;
            Type = type;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Type: {Type} ";
        }
    }
}
