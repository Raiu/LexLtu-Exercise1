using System.Globalization;
using System.Text;

namespace Exercise1
{

    /***
     * 1)   Classes that should be included for this problem: Program, RecodBook, Employee.
     * 2)   Program should contain a run for the main logic, input parsing and validation, logic for the different commands
     *      RecordBook should contain said record and be able to add and remove employes from said recod in either list or dict
     *      Employee should contain properties for handling Firstname, Surname and salaries and some validation.
     */

    class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }

        public Employee(string firstName, string lastName, double salary)
        {
            ID = new Random().Next(int.MinValue, int.MaxValue);
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }
    }

    class EmployeeRegistry
    {
        public List<Employee> Registry { get; set; }

        public EmployeeRegistry()
        {
            Registry = new();
        }

        public void AddEmployee(string firstName, string lastName, double Salary)
        {
            Employee employee = new Employee(firstName, lastName, Salary);
            Registry.Add(employee);
        }

        public void RemoveEmployee(string firstName, string lastName)
        {

        }
    }


    class Program
    {
        private EmployeeRegistry Book {  get; set; } = new EmployeeRegistry();
        private readonly CultureInfo Culture = new CultureInfo("sv-SE");

        static void Main(string[] args)
        {
            Program program = new Program();
            program.run();
        }

        private void run()
        {
            PrintWelcomeMessage();

            bool running = true;
            while (running)
            {
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: Invalid input");
                    Console.WriteLine("Enter your command:");
                    continue;
                }

                (string command, string[] arguments) = ParseInput(input);

                switch (command.ToLower())
                {
                    case "quit":
                        running = false;
                        break;
                    case "add":
                        AddEmployee(arguments);
                        break;
                    case "print":
                        PrintEmployees();
                        break;
                    default:
                        Console.WriteLine($"{command} is an invalid command");
                        break;
                }

                Console.WriteLine("\nEnter your command:");
            }
            Console.WriteLine("Exiting");
            Environment.Exit(1);
        }

        private (string, string[]) ParseInput(string input)
        {
            string[] segments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = segments[0];
            string[] arguments = segments.Skip(1).ToArray();
            return (command, arguments);
        }

        private void PrintWelcomeMessage()
        {
            StringBuilder sb = new();
            sb.AppendLine("\nWelcome to the Employee Registry!");
            sb.AppendLine("Commands:");
            sb.AppendLine("   add <first name> <last name> <salary>      Add a new employee to the registry");
            sb.AppendLine("   print      Prints all records in the Employee Registry");
            sb.AppendLine("   quit       Exit current sessions");
            sb.AppendLine("\nEnter your command:");
            Console.WriteLine(sb.ToString());
        }

        private void AddEmployee(string[] employeeData)
        {
            if (employeeData.Length != 3) {
                Console.WriteLine($"{String.Join(' ', employeeData)} is not a valid input");
                Console.WriteLine("Usage:   add <first name> <last name> <salary>");
                return;
            }

            string firstName = employeeData[0];
            string lastName = employeeData[1];
            if (!double.TryParse(employeeData[2], Culture, out double salary))
            {
                Console.WriteLine($"{employeeData[2]} is not a valid salary value");
                return;
            }

            Book.AddEmployee(firstName, lastName, salary);
            Console.WriteLine($"Added employee: {firstName} {lastName} with salary: {salary}");
        }

        private void PrintEmployees()
        {
            foreach (Employee employee in Book.Registry)
            {
                 Console.WriteLine($"Name: {employee.FirstName} {employee.LastName} Salary: {employee.Salary}");
            }
        }
    }
}
