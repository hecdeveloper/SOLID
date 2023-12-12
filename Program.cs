using System.Xml.Linq;

namespace SOLID.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hector = new Person("Hector");
            var juan = new Person("Juan");
            hector.Speak();
            juan.Speak();
            var database = new Database();
            database.SaveToDatabase(hector);
            var calculator = new SalaryCalculator();
            var james = new Manager("James");
            Console.WriteLine($"{james.Name} salary is {calculator.CalculateSalary(james)}");
            var director = new Director("Richard");
            Console.WriteLine($"{director.Name} salary is {calculator.CalculateSalary(director)}");
        }
    }

    public class Person
    {
        public virtual decimal DailyRate => 0;
        public Person(string name)
        {
            Name = name;
        }
        public int Id { get; set;}
        public string Name { get; set; }

        public void Speak()
        {
            Console.WriteLine($"My name is {Name}");
        }
    }

    public class Employee : Person
    {
        public override decimal DailyRate => 100;
        public Employee(string name) : base(name)
        {

        }
    }

    public class Manager : Person
    {
        public override decimal DailyRate => 200;
        public Manager(string name) : base(name)
        {
        }
    }


    public class Director : Person
    {
        public override decimal DailyRate => 300;
        public Director(string name) : base(name)
        {
        }
    }

    public class SalaryCalculator
    {
        public decimal CalculateSalary(Person person)
        {
            return person.DailyRate * 356;
        }
    }


    public class Database
    {
        public void SaveToDatabase(Person person)
        {
            Console.WriteLine($"Added {person.Name}");
        }
    }
}



