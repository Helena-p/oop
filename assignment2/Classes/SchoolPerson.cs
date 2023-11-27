using static System.Console;

namespace oop
{
    class SchoolPerson
    {
        public string Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string DateOfBirth { get; set; }
        public int Age { get => GetAge(); }

        public SchoolPerson(string firstName, string lastName, string role, string dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be null or empty.", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be null or empty.", nameof(lastName));

            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role cannot be null or empty.", nameof(role));

            Id = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            DateOfBirth = dateOfBirth;
        }
        private int GetAge()
        {
            if (string.IsNullOrWhiteSpace(DateOfBirth))
                throw new ArgumentException($"A date of birth must be provided. Cannot be null or empty!", nameof(DateOfBirth));

            var today = DateTime.Today;
            var ageInDateTime = Convert.ToDateTime(DateOfBirth);
            return today.Year - ageInDateTime.Year;
        }
        public override string ToString()
        {
            return $"Id: {Id}, {Role}: {FirstName} {LastName}, Age: {Age}";
        }
    }
}