using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
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
}
