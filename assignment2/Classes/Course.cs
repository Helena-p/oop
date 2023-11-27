using System;
using System.Collections.Generic;
using System.Text;

namespace oop
{
    class Course
    {
        public string Id { get; }
        public string Name { get; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public Course(string name, Teacher teacher, List<Student> studentList)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Course name cannot be null or empty", nameof(name));
            if (teacher == null)
                throw new ArgumentNullException("Teacher cannot be null", nameof(teacher));
            if (studentList == null)
                throw new ArgumentNullException("List of students cannot be null", nameof(studentList));

            Id = Guid.NewGuid().ToString();
            Name = name;
            Teacher = teacher;
            Students = studentList;
        }

        public override string ToString()
        {
            // Format the students list
            StringBuilder students = new StringBuilder("Students:\n");
            foreach (Student student in Students)
            {
                students.Append($"- Id: {student.Id}, Name: {student.FirstName} {student.LastName}\n");
            }
            return $"\nTeacher:\n- Id: {Teacher.Id}, Name: {Teacher.FirstName} {Teacher.LastName}\n{students}";
        }
    }
}