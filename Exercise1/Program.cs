
namespace Exercise1
{

    /***
     * 1) Classes that should be included for this problem: Program, RecodBook, Employee.
     * 2)   Program should contain a run loop, parseinputs and validate input and handle the main logic.
     *      RecordBook should contain said record and be able to add and remove employes from said recod in either list or dict
     *      Employee should contain properties for handling Firstname, Surname and salaries and some validation.
     */

    class EmploymentRecordBook
    {
        public Dictionary<string, int> Employes { get; set; }

        public EmploymentRecordBook()
        {
            Employes = new();
        }

        public void Add(string employeeName, int employeeSalary)
        {
            Employes.Add(employeeName, employeeSalary);
        }
    }


    internal class Program
    {
        private (string, int) ParseInputAdd(string input)
        {
            input = input.Trim();
            string[] inputArray = input.Split(' ');
            string name = inputArray[1];
            int salary = int.Parse(inputArray[2]);
            return (name, salary);
        }

        private void run()
        {
            EmploymentRecordBook book = new();

            Console.WriteLine("\nWelcome!\nAdd new employe with command \"add name salary\"");
            Console.WriteLine("We currently only accept first names and salaries in real numbers");
            Console.WriteLine("\nYou can print the current record with the command \"print\"");
            Console.WriteLine("\nUse command \"quit\" when you are done\n");


            string line;
            while ((line = Console.ReadLine()) != "quit")
            {
                if (line.StartsWith("add"))
                {
                    (string employeeName, int employeeSalary) = ParseInputAdd(line);
                    book.Add(employeeName, employeeSalary);
                    Console.WriteLine($"Added employee: {employeeName} with salary: {employeeSalary}");
                }
                else if (line.StartsWith("print"))
                {
                    foreach (KeyValuePair<string, int> employee in book.Employes)
                    {
                        string name = employee.Key;
                        int salary = employee.Value;

                        Console.WriteLine($"Name: {employee.Key} Salary: {employee.Value}");
                    }
                }
                else
                {
                    Console.WriteLine($"{line} is not a valid command");
                    break;
                }

            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.run();
        }
    }
}
