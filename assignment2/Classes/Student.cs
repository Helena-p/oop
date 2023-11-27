namespace oop
{
    class Student : SchoolPerson
    {
        public Student(
            string firstName, string lastName, string dateOfBirth) : base(firstName, lastName, "Student", dateOfBirth)
        {
        }
    }
}