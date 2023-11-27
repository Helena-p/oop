using System.Collections.Generic;
using static System.Console;

namespace oop
{
    partial class School
    {
        public string Name { get; set; }
        private List<Student> Students { get; set; }
        private Dictionary<String, Course> Courses { get; set; }
        private List<Teacher> Teachers { get; set; }
        private List<Grade> Grades { get; set; }

        public School(string name, List<Student> students, Dictionary<string, Course> courses, List<Teacher> teachers, List<Grade> grades)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("A school must have a name", nameof(name));
            if (students == null)
                throw new ArgumentNullException("List of students cannot be null", nameof(students));
            if (courses == null)
                throw new ArgumentNullException("Dictionary of courses cannot be null", nameof(courses));
            if (teachers == null)
                throw new ArgumentNullException("List of teachers cannot be null", nameof(teachers));
            if (grades == null)
                throw new ArgumentNullException("List of grades cannot be null", nameof(grades));

            Name = name;
            Students = students;
            Courses = courses;
            Teachers = teachers;
            Grades = grades;
        }

        public Student GetStudentById(string studentId)
        {
            foreach (Student student in Students)
            {
                if (student.Id == studentId)
                    return student;
            }

            throw new ArgumentException("Student not found");
        }

        public Teacher GetTeacherById(string teacherId)
        {
            foreach (Teacher teacher in Teachers)
            {
                if (teacher.Id == teacherId)
                    return teacher;
            }
            throw new ArgumentException("Teacher not found");
        }

        public Grade GetStudentGrade(string courseName, string studentId)
        {
            var student = GetStudentById(studentId);
            Grade? grade = Grades.Find(g => g.Student == student && g.Course == Courses[courseName]) ?? null;
            // return null if grade do not exist
            return grade!;
        }

        public string GetCourseKeyById(string courseId)
        {
            var courseKey = String.Empty;
            foreach (var item in Courses)
            {
                if (item.Value.Id == courseId)
                {
                    courseKey = item.Key.ToString();
                    break;
                }
            }
            return courseKey;
        }

        public bool HasCourse(string courseId)
        {
            bool hasCourse = false;
            var key = GetCourseKeyById(courseId);
            if (Courses.ContainsKey(key))
            {
                hasCourse = true;
            }
            return hasCourse;
        }
        public void AddTeacher(string firstName, string lastName, string dateOfBirth)
        {
            var teacher = new Teacher(firstName, lastName, dateOfBirth);
            Teachers.Add(teacher);
            WriteLine($"Teacher successfully added!");
        }
        public void RemoveTeacher(string teacherId)
        {
            if (string.IsNullOrWhiteSpace(teacherId))
                throw new ArgumentException("Course ID cannot be empty or null!");

            var teacher = GetTeacherById(teacherId);
            Teachers.Remove(teacher);
            WriteLine("Teacher successfully removed!");
        }

        public void AddCourse(Course course)
        {
            if (HasCourse(course.Id))
                throw new ArgumentException("This course already exists!");
            if (string.IsNullOrWhiteSpace(course.Id))
                throw new ArgumentException("Course ID cannot be empty or null!");

            Courses.Add(course.Name.ToString(), course);
            WriteLine("Course successfully added!");
        }

        public void RemoveCourse(string courseId)
        {
            if (!HasCourse(courseId))
                throw new ArgumentException("This course does not exists!");

            var courseKey = GetCourseKeyById(courseId);
            Courses.Remove(courseKey);
            WriteLine("Course successfully removed!");
        }

        public void RemoveStudentFromSchool(string studentId)
        {
            if (!IsStudentEnrolledInSchool(studentId))
                throw new ArgumentException("This student do not exist!");

            Student retrievedStudent = GetStudentById(studentId);

            Students.Remove(retrievedStudent);
            WriteLine("Student successfully removed!");
        }

        public void RemoveStudentFromCourse(string courseId, string studentId)
        {
            if (!HasCourse(courseId) || !IsStudentEnrolledInSchool(studentId))
                throw new ArgumentException("This course and/or student does not exists!");

            // remove student after fetching course 
            Student retrievedStudent = GetStudentById(studentId);
            var courseKey = GetCourseKeyById(courseId);
            Courses[courseKey].Students.Remove(retrievedStudent);
            WriteLine("Student successfully removed!");
        }

        public static void UpdateStudentsExistingGrade(Grade grade, int value)
        {
            grade.UpdateExistingGrade(value);
        }

        public void SetStudentGrade(string courseId, string studentId, int value)
        {

            if (!HasCourse(courseId) || !IsStudentEnrolledInSchool(studentId))
                throw new ArgumentException("This course and/or student does not exists!");
            if (!IsStudentEnrolledInCourse(courseId, studentId))
                throw new ArgumentException("Student is not enrolled in course!");

            Student retrievedStudent = GetStudentById(studentId);
            var courseKey = GetCourseKeyById(courseId);
            Course course = Courses[courseKey];

            Grade gradeToUpdate = GetStudentGrade(courseKey, studentId);
            WriteLine($"G to update{gradeToUpdate}");

            if (gradeToUpdate != null)
            {
                UpdateStudentsExistingGrade(gradeToUpdate, value);
            }
            else
            {
                var newGrade = new Grade(course, retrievedStudent, value);
                WriteLine($"NewGrade in set grade: {newGrade}");
                Grades.Add(newGrade);
            }
        }

        public void RemoveGrade(string courseId, string studentId)
        {
            if (!HasCourse(courseId) || !IsStudentEnrolledInSchool(studentId))
                throw new ArgumentException("This course and/or student does not exists!");
            if (!IsStudentEnrolledInCourse(courseId, studentId))
                throw new ArgumentException("Student is not enrolled in course!");

            Grade grade = GetStudentGrade(courseId, studentId);
            Grades.Remove(grade);
            WriteLine("Grade successfully removed!");
        }
        public void GetAllGrades(string studentId)
        {
            if (!IsStudentEnrolledInSchool(studentId))
                throw new ArgumentException("This student does not exists!");

            var student = GetStudentById(studentId);

            List<Grade> gradesList = Grades.FindAll(g => g.Student == student) ?? throw new NullReferenceException($"Grade for student {studentId} do not exist");
        }
    }
}