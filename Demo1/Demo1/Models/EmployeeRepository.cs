using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> empList;
        public EmployeeRepository()
        {
            empList = new List<Employee>
            {
                new Employee(){ Id  = 1, Name = "Ali", Email = "ali@gmail.com", Department = "Dev" },
                new Employee(){ Id  = 2, Name = "Aijaz", Email = "aijaz@gmail.com", Department = "Dev" },
                new Employee(){ Id  = 3, Name = "Ahmed", Email = "Ahemd@gmail.com", Department = "HR" }
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = empList.Max(emp => emp.Id) + 1;
            empList.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return empList;
        }

        public Employee GetEmployee(int id)
        {
            return empList.FirstOrDefault(emp => emp.Id == id);
        }
    }
}
