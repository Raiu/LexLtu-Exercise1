using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
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
}
