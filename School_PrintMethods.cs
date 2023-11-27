using System.Text;
using static System.Console;

namespace oop
{
    partial class School
    {
        public void PrintAllTeachers()
        {
            foreach (var teacher in Teachers)
                WriteLine(teacher);
        }

        public void PrintAllStudents()
        {
            foreach (var student in Students)
                WriteLine(student);
        }

        public void PrintAllCourses()
        {
            foreach (var item in Courses)
            {
                WriteLine(item);
            }
        }

        public void PrintAllGrades()
        {
            foreach (var item in Grades)
            {
                WriteLine(item);
            }
        }

        public override string ToString()
        {
            // Format the courses dict
            StringBuilder currentCourses = new StringBuilder("Courses:\n");
            foreach (KeyValuePair<string, Course> item in Courses)
            {
                currentCourses.Append($"{item.Key}\n");
            }
            // Format the teachers list
            StringBuilder teachers = new StringBuilder("Teachers:\n");
            foreach (Teacher teacher in Teachers)
            {
                teachers.Append($"Name: {teacher.FirstName} {teacher.LastName}\n");
            }
            // Format the students list
            StringBuilder students = new StringBuilder("Students:\n");
            foreach (Student student in Students)
            {
                students.Append($"Name: {student.FirstName} {student.LastName}\n");
            }
            // Format the grades list
            StringBuilder gradesList = new StringBuilder("Grades:\n");
            foreach (Grade grade in Grades)
            {
                gradesList.Append($"{grade}\n");
            }

            return $"School: {Name}\n{currentCourses}\n{teachers}\n{students}\n{gradesList}";
        }
    }
}