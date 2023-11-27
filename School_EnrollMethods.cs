using System.Collections.Generic;
using static System.Console;

namespace oop
{
    partial class School
    {
        public bool IsStudentEnrolledInSchool(string studentId)
        {
            bool isEnrolled = false;
            foreach (Student student in Students)
            {
                if (student.Id == studentId.ToString())
                    isEnrolled = true;
            }
            return isEnrolled;
        }

        public void EnrollStudentToSchool(Student student)
        {
            if (IsStudentEnrolledInSchool(student.Id))
                throw new ArgumentException("This student is already enrolled!");
            Students.Add(student);
        }

        public bool IsStudentEnrolledInCourse(string courseId, string studentId)
        {
            if (!HasCourse(courseId) || !IsStudentEnrolledInSchool(studentId))
                throw new ArgumentException("This course and/or student does not exists!");

            var courseKey = GetCourseKeyById(courseId);
            bool isEnrolled = false;

            foreach (Student student in Courses[courseKey].Students)
            {
                if (student.Id == studentId)
                {
                    isEnrolled = true;
                    break;
                }
            }
            return isEnrolled;
        }

        public void EnrollStudentToCourse(string courseId, string studentId)
        {
            if (!HasCourse(courseId) || !IsStudentEnrolledInSchool(studentId))
                throw new ArgumentException("This course and/or student does not exists!");

            if (IsStudentEnrolledInCourse(courseId, studentId))
                throw new ArgumentException("Student is already enrolled!");

            Student retrievedStudent = GetStudentById(studentId);

            var courseKey = GetCourseKeyById(courseId);
            Courses[courseKey].Students.Add(retrievedStudent);
        }
    }
}