using System;
using System.Collections.Generic;
using static System.Console;

namespace oop
{
    class Program
    {
        static void ExcerciseOne()
        {
            // EXERCISE 1
            var benjamin = new Employee("Benjamin", "Plantin", 24, 24300.78m);
            var bella = new Customer("Bella", "Svensson", 18);

            benjamin.Speak();
            WriteLine();
            bella.Speak();

            Sale sale = new Sale("Cat snack", 4.50, bella, benjamin);
            Sale sale2 = new Sale("Cat toy", 2.35, bella, benjamin);
            sale.AddSaleToList(benjamin.SalesList);
            sale2.AddSaleToList(benjamin.SalesList);
            sale.AddSaleToList(bella.PurchasesList);

            WriteLine($"Person class object: {benjamin}");
            WriteLine();
            WriteLine($"Person class object: {bella}");

            WriteLine();
            // statistics
            benjamin.GetStatistics();
            // sales
            benjamin.PrintSales();
            WriteLine();
            bella.PrintSales();
        }
        static void ExerciseTwo()
        {
            // EXERCISE 2
            IDriveable fiat = new Car("Fiat", 32, 45);
            IDriveable harley = new MotorBike("Harley Davidson", 100, 20);
            IDriveable scania = new Bus("Saab Scania", 100, 70);

            WriteLine($"Bike model {harley.Name}, fueltank {harley.RemainingFuel}lit, speed {harley.VehicleSpeed}km/h");
            WriteLine($"Bus model {scania.Name}, fueltank {scania.RemainingFuel}lit, speed {scania.VehicleSpeed}km/h");

            TestDrive(harley);
            WriteLine($"Bike model {harley.Name}, fueltank {harley.RemainingFuel}lit, speed {harley.VehicleSpeed}km/h");
            TestDrive(scania);
            TestDrive(harley);

            void TestDrive(IDriveable vehicle)
            {
                vehicle.StartEngine();
                vehicle.Gas();
                vehicle.TurnLeft();
                vehicle.TurnRight();
                vehicle.Break();
                vehicle.StopEngine();
            }
        }

        static void ExerciseThree()
        {
            // create some initial data
            // students
            var student1 = new Student("Harry", "Potter", "1994/11/04");
            var student2 = new Student("Ron", "Weasley", "1996/02/24");
            List<Student> studentList = new();
            studentList.Add(student1);
            studentList.Add(student2);
            // teachers
            var teacher1 = new Teacher("Albus", "Dumbledore", "1938/10/04");
            var teacher2 = new Teacher("Minerva", "McGonagall", "1941/05/18");
            List<Teacher> teachers = new();
            teachers.Add(teacher1);
            teachers.Add(teacher2);
            // courses
            var math = new Course("Math", teacher1, studentList);
            var science = new Course("Science", teacher2, studentList);
            var courses = new Dictionary<string, Course>(){
                {"Math", math},
                {"Science", science},
            };
            // grades
            var grade1 = new Grade(math, student1, 87);
            var grade2 = new Grade(science, student2, 92);
            List<Grade> grades = new();
            grades.Add(grade1);
            grades.Add(grade2);
            // iniitate a school
            var hogwarts = new School("Hogwarts", studentList, courses, teachers, grades);


            // CONSOLE Program Methods
            void AddTeacherProgram()
            {
                WriteLine("Enter persons firstname: ");
                string firstName = ReadLine()!.Trim();
                WriteLine("Enter persons lastname: ");
                string lastName = ReadLine()!.Trim();
                WriteLine("Enter persons date of birth (yyyy/mm/dd): ");
                string dateOfBirth = ReadLine()!.Trim();
                hogwarts.AddTeacher(firstName, lastName, dateOfBirth);
                hogwarts.PrintAllTeachers();
            }

            void AddStudentProgram()
            {
                WriteLine("Enter persons firstname: ");
                string firstName = ReadLine()!.Trim();
                WriteLine("Enter persons lastname: ");
                string lastName = ReadLine()!.Trim();
                WriteLine("Enter persons date of birth (yyyy/mm/dd): ");
                string dateOfBirth = ReadLine()!.Trim();
                var student = new Student(firstName, lastName, dateOfBirth);
                hogwarts.EnrollStudentToSchool(student);
                hogwarts.PrintAllStudents();
            }
            void AddCourseProgram()
            {
                WriteLine("Enter name of course: ");
                var courseName = ReadLine()!.Trim();
                WriteLine("Enter firstname of teacher: ");
                var teacherFirstName = ReadLine()!.Trim();
                WriteLine("Enter lastname of teacher: ");
                var teacherLastName = ReadLine()!.Trim();
                WriteLine("Enter teachers date of birth (yyyy/mm/dd): ");

                var teacherDateOfBirth = ReadLine()!.Trim();
                var courseTeacher = new Teacher(teacherFirstName, teacherLastName, teacherDateOfBirth);
                var addMoreStudents = true;
                List<Student> courseStudentList = new();
                do
                {
                    WriteLine("Enter students firstname: ");
                    string studentFirstName = ReadLine()!.Trim();
                    WriteLine("Enter students lastname: ");
                    string studentLastName = ReadLine()!.Trim();
                    WriteLine("Enter students date of birth (yyyy/mm/dd): ");
                    string studentDateOfBirth = ReadLine()!.Trim();

                    var newCourseStudent = new Student(studentFirstName, studentLastName, studentDateOfBirth);

                    courseStudentList.Add(newCourseStudent);
                    WriteLine("Do you want to add another student (Y/N)? ");
                    var answer = ReadLine()!.Trim().ToLower();
                    addMoreStudents = answer == "n" ? false : true;
                }
                while (courseStudentList.Count < 1 || addMoreStudents is true);

                var newCourse = new Course(courseName, courseTeacher, courseStudentList);
                hogwarts.AddCourse(newCourse);
                hogwarts.PrintAllCourses();
            }
            void RemoveTeacherProgram()
            {
                hogwarts.PrintAllTeachers();
                WriteLine("Enter id for teacher: ");
                var teacherId = ReadLine()!.Trim();
                hogwarts.RemoveTeacher(teacherId);
            }
            void RemoveStudentProgram()
            {
                hogwarts.PrintAllStudents();
                WriteLine("Enter id for student: ");
                var studentId = ReadLine()!.Trim();
                hogwarts.RemoveStudentFromSchool(studentId);
            }
            void RemoveCourseProgram()
            {
                hogwarts.PrintAllCourses();
                WriteLine("Enter id for course: ");
                var courseId = ReadLine()!.Trim();
                hogwarts.RemoveCourse(courseId);
            }
            void GetAllStudentGradesProgram()
            {
                hogwarts.PrintAllStudents();
                WriteLine("Enter student id: ");
                var studentId = ReadLine()!.Trim();
                hogwarts.GetAllGrades(studentId);
            }
            void GetStudentCourseGradeProgram()
            {
                WriteLine("Enter name of Course: ");
                var courseName = ReadLine()!.Trim();
                WriteLine("Enter student id: ");
                var studentId = ReadLine()!.Trim();
                hogwarts.GetStudentGrade(courseName, studentId);
            }
            void RemoveGradeProgram()
            {
                WriteLine("Enter id of Course: ");
                var courseId = ReadLine()!.Trim();
                WriteLine("Enter student id: ");
                var studentId = ReadLine()!.Trim();
                hogwarts.RemoveGrade(courseId, studentId);
            }
            void SetGradeProgram()
            {
                WriteLine("Enter id of Course: ");
                var courseId = ReadLine()!.Trim();
                WriteLine("Enter student id: ");
                var studentId = ReadLine()!.Trim();
                WriteLine("Enter value of grade: ");
                var value = int.Parse(ReadLine()!.Trim());
                hogwarts.SetStudentGrade(courseId, studentId, value);
            }
            void UpdateGradeProgram()
            {
                WriteLine("Enter name of Course: ");
                var courseName = ReadLine()!.Trim();
                WriteLine("Enter student id: ");
                var studentId = ReadLine()!.Trim();
                var grade = hogwarts.GetStudentGrade(courseName, studentId);
                WriteLine("Enter value of grade: ");
                var newValue = int.Parse(ReadLine()!.Trim());
                grade.UpdateExistingGrade(newValue);
            }

            // CONSOLE Program
            /*
                Note! Neccessary to print teachers, students, or courses to
                get correct id's for code to work since the ids change with each run of program
            */
            WriteLine(@"Main menu:
            1) Display teachers/student/courses
            2) Add teachers/student/courses
            3) Remove teachers/student/courses
            4) Display/remove/add grades
            ");

            switch (ReadLine()!.Trim())
            {
                case "1":
                    WriteLine(@"Sub menu:
            1) Display teachers
            2) Display students
            3) Display courses
            4) Display grades
            ");
                    switch (ReadLine()!.Trim())
                    {
                        case "1":
                            hogwarts.PrintAllTeachers();
                            break;
                        case "2":
                            hogwarts.PrintAllStudents();
                            break;
                        case "3":
                            hogwarts.PrintAllCourses();
                            break;
                        case "4":
                            hogwarts.PrintAllGrades();
                            break;
                        default:
                            WriteLine("This is not a valid option! Try again.");
                            break;
                    }
                    Write("Press any key to exit program");
                    ReadKey();
                    break;
                case "2":
                    WriteLine(@"Sub menu:
            1) Add teacher
            2) Add student
            3) Add course
            ");
                    switch (ReadLine()!.Trim())
                    {
                        case "1":
                            AddTeacherProgram();
                            break;
                        case "2":
                            AddStudentProgram();
                            break;
                        case "3":
                            AddCourseProgram();
                            break;
                        default:
                            WriteLine("This is not a valid option! Try again.");
                            break;
                    }
                    Write("Press any key to exit program");
                    ReadKey();
                    break;
                case "3":
                    WriteLine(@"Sub menu:
            1) Remove teacher
            2) Remove student
            3) Remove course
            ");
                    switch (ReadLine()!.Trim())
                    {
                        case "1":
                            RemoveTeacherProgram();
                            break;
                        case "2":
                            RemoveStudentProgram();
                            break;
                        case "3":
                            RemoveCourseProgram();
                            break;
                        default:
                            WriteLine("This is not a valid option! Try again.");
                            break;
                    }
                    Write("Press any key to exit program");
                    ReadKey();
                    break;
                case "4":
                    WriteLine(@"Sub menu:
            1) Show all grades for student
            2) Show course grade for student
            3) Remove grade for student
            4) Set grade for student
            5) Update student grade
            ");
                    string subMenu4 = ReadLine()!.Trim();
                    switch (ReadLine()!.Trim())
                    {
                        case "1":
                            GetAllStudentGradesProgram();
                            break;
                        case "2":
                            GetStudentCourseGradeProgram();
                            break;
                        case "3":
                            RemoveGradeProgram();
                            break;
                        case "4":
                            SetGradeProgram();
                            break;
                        case "5":
                            UpdateGradeProgram();
                            break;
                        default:
                            WriteLine("This is not a valid option! Try again.");
                            break;
                    }
                    Write("Press any key to exit program");
                    ReadKey();
                    break;
                default:
                    WriteLine("This is not a valid option! Try again.");
                    break;
            }
            Write("Press any key to exit program");
            ReadKey();
        }

        private static void Main(string[] args)
        {
            // ExcerciseOne();
            // ExerciseTwo();
            ExerciseThree();
        }
    }
}