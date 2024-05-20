using System.Net.Http.Headers;
using System.Text;

namespace Exercise1
{

    /***
     * 1)   Classes that should be included for this problem: Program, RecodBook, Employee.
     * 2)   Program should contain a run loop, parseinputs and validate input and handle the main logic.
     *      RecordBook should contain said record and be able to add and remove employes from said recod in either list or dict
     *      Employee should contain properties for handling Firstname, Surname and salaries and some validation.
     */

    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }

        public Employee(string firstName, string lastName, double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }
    }

    class EmployeeDatabase
    {
        public List<Employee> Database { get; set; }

        public EmployeeDatabase()
        {
            Database = new();
        }

        public void AddEmployee(string firstName, string lastName, double Salary)
        {
            Employee employee = new Employee(firstName, lastName, Salary);
            Database.Add(employee);
        }
    }


    internal class Program
    {
        private (string, string[]) ParseInput(string input)
        {
            input = input.Trim();
            if (input.Length == 0)
            {
                return ("", Array.Empty<string>());
            }

            string[] segments = input.Split(' ');
            string[] arguments = segments.Skip(1).ToArray();
            return (segments[0], arguments);
        }

        private void WriteWelcome()
        {
            StringBuilder sb = new();
            sb.Append("\nWelcome!\nAdd new employe with command \"add name salary\"");
            sb.Append("\nYou can print the current record with the command \"print\"");
            sb.Append("\nUse command \"quit\" when you are done\n");
            sb.Append("We currently only accept first names and salaries in real numbers");
            Console.WriteLine(sb.ToString());
        }

        private void Add(EmployeeDatabase book, string[] employeeData)
        {
            if (employeeData.Length < 3) {
                Console.WriteLine($"{String.Join(' ', employeeData)} is not a valid input string for the add command");
                return;
            }

            string firstName = employeeData[0];
            string lastName = employeeData[1];
            if (!double.TryParse(employeeData[2], out double salary))
            {
                Console.WriteLine($"{employeeData[2]} is not valid salary value");
                return;
            }

            book.AddEmployee(firstName, lastName, salary);
            Console.WriteLine($"Added employee: {firstName} {lastName} with salary: {salary}");
        }

        private void Print(EmployeeDatabase book)
        {
            foreach (Employee employee in book.Database)
            {
                 Console.WriteLine($"Name: {employee.FirstName} {employee.LastName} Salary: {employee.Salary}");
            }
        }

        private void run()
        {
            EmployeeDatabase book = new();

            WriteWelcome();

            bool running = true;
            while (running)
            {
                (string command, string[] arguments) = ParseInput(Console.ReadLine());

                if (command == "")
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                switch (command)
                {
                    case "quit":
                        running = false;
                        break;
                    case "add":
                        Add(book, arguments);
                        break;
                    case "print":
                        Print(book);
                        break;
                    default:
                        Console.WriteLine($"{command} is an invalid command");
                        break;
                }
            }
            Console.WriteLine("Exiting");
            Environment.Exit(1);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.run();
        }
    }
}
