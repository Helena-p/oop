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
            // validate student don't exist
            if (IsStudentEnrolledInSchool(student.Id))
                throw new ArgumentException("This student is already enrolled!");
            Students.Add(student);
        }

        public bool IsStudentEnrolledInCourse(string courseId, string studentId)
        {
            // validate course and student exist
            if (!HasCourse(courseId) || !IsStudentEnrolledInSchool(studentId))
                throw new ArgumentException("This course and/or student does not exists!");

            // find course by its id
            var courseKey = GetCourseKeyById(courseId);
            // find student by id 
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
            // validate course and student exist
            if (!HasCourse(courseId) || !IsStudentEnrolledInSchool(studentId))
                throw new ArgumentException("This course and/or student does not exists!");
            // check student isn't already enrolled in the course
            if (IsStudentEnrolledInCourse(courseId, studentId))
                throw new ArgumentException("Student is already enrolled!");

            // get student data
            Student retrievedStudent = GetStudentById(studentId);
            // add student to student list in course
            var courseKey = GetCourseKeyById(courseId);
            Courses[courseKey].Students.Add(retrievedStudent);
        }
    }
}