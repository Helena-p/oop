using static System.Console;
using System.Globalization;

namespace oop
{
    class Person
    {
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonAge = age;
            IncreaseInstanceCount();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        private int age;
        private int count = 0;

        public int PersonAge
        {
            get { return age; }
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
            }
        }
        public int CountInstances
        {
            get
            {
                return count;
            }
        }

        // Print Person object's properties
        public override string ToString()
        {
            return $"\nFirstname: {FirstName}\nLastname: {LastName}\nAge: {PersonAge}"; ;
        }
        void IncreaseInstanceCount()
        {
            count += 1;
        }

        public void Speak()
        {
            WriteLine($"Hello, my name is {FirstName} {LastName} and I am {PersonAge} years old.");
        }

    }

    class Employee : Person
    {
        public Employee(string firstName, string lastName, int age, decimal salary) : base(firstName, lastName, age)
        {
            Salary = salary;
            SalesList = new List<Sale>();

        }
        double total = 0.0;
        private decimal salary;
        private readonly string Departement = "Employee";
        public List<Sale> SalesList { get; }
        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value > 0)
                {
                    salary = value;
                }
            }
        }

        public override string ToString()
        {
            return $"\n{Departement}: {FirstName} {LastName}\nAge: {PersonAge}\nSalary: {Salary.ToString("C2", CultureInfo.CurrentCulture)}"; ;
        }
        public int GetNumberOfSales()
        {
            return SalesList.Count();
        }
        public double GetSalesTotal()
        {
            foreach (Sale s in SalesList)
            {
                total += s.Price;
            }
            return total;
        }
        public double GetAverageSale()
        {
            return total /= SalesList.Count;
        }
        public void GetStatistics()
        {
            WriteLine($"Employee: {this.FullName}\nNum of sales: {this.GetNumberOfSales()}\nTotal: {this.GetSalesTotal():C}\nAverage: {this.GetAverageSale():C}"); ;
        }
        public void PrintSales()
        {
            WriteLine($"Sales for {this.FullName}\n");
            foreach (Sale s in SalesList)
            {
                WriteLine($"Product: {s.Product}\tPrice: {s.Price:C}\tDate: {s.TransactionDate}\tBuyer: {s.Customer.FullName}");
            }
        }
    }

    class Customer : Person
    {
        public Customer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            PurchasesList = new List<Sale>();
        }
        private readonly string Departement = "Customer";
        public List<Sale> PurchasesList { get; }
        public override string ToString()
        {
            return $"\n{Departement}: {FirstName} {LastName}\nAge: {PersonAge}"; ;
        }
        public void PrintSales()
        {
            WriteLine($"Sales for {this.FullName}\n");
            foreach (Sale s in PurchasesList)
            {
                WriteLine($"Product: {s.Product}\tPrice: {s.Price:C}\tDate: {s.TransactionDate}\tSeller: {s.Employee.FullName}");
            }
        }
    }

    class Sale
    {
        public Sale(string product, double price, Customer customer, Employee employee)
        {
            Product = product;
            Price = price;
            Customer = customer;
            Employee = employee;
            TransactionDate = DateTime.Now;
        }

        public string Product { get; }
        public double Price { get; }
        public Customer Customer { get; }
        public Employee Employee { get; }
        public DateTime TransactionDate { get; private set; }

        public void AddSaleToList(List<Sale> salesList)
        {
            salesList.Add(this);
        }
    }
}

