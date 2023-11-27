namespace oop
{
    class Grade
    {

        public string Id { get; }
        public Course Course { get; }
        public Student Student { get; }

        private GRADE GradeReceived;

        public DateTime DateAcquired { get; }
        enum GRADE { A = 95, B = 90, C = 85, D = 80, E = 70, F = 60 }

        public Grade(Course course, Student student, int grade)
        {
            if (course == null)
                throw new ArgumentNullException("Course cannot be null", nameof(course));
            if (student == null)
                throw new ArgumentNullException("Student cannot be null", nameof(student));
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException("Grade can only be within 0 - 100 in range.", nameof(grade));

            Id = Guid.NewGuid().ToString();
            DateAcquired = DateTime.Now;
            Course = course;
            Student = student;
            GradeReceived = SetGrade(grade);
        }

        private static GRADE SetGrade(int grade)
        {
            if (grade >= 95)
                return GRADE.A;
            else if (grade >= 90)
                return GRADE.B;
            else if (grade >= 85)
                return GRADE.C;
            else if (grade >= 80)
                return GRADE.D;
            else if (grade >= 70)
                return GRADE.E;
            else
                return GRADE.F;
        }

        public void UpdateExistingGrade(int value)
        {
            GradeReceived = SetGrade(value);
        }


        public override string ToString()
        {
            return $"Grade:\n- Id:{Id}, Course: {Course.Name},\nStudent: {Student.FirstName} {Student.LastName}\nGrade received: {GradeReceived}";
        }
    }
}