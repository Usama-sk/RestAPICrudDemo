using RestAPICrudDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPICrudDemo.EmployeeData
{
    public class MockEmployeeData : IEmployeesData
    {
        private List<EmployeesModel> employees = new List<EmployeesModel>()
        {
              new EmployeesModel()
              {
                Id = Guid.NewGuid(),
                Name = "Usama"
              },
                new EmployeesModel()
              {
                Id = Guid.NewGuid(),
                Name = "Hamza"
              },
                  new EmployeesModel()
              {
                Id = Guid.NewGuid(),
                Name = "Shaikh"
              }

        };

        public EmployeesModel AddEmployee(EmployeesModel employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(EmployeesModel employee)
        {
            employees.Remove(employee);
        }

        public EmployeesModel EditEmployee(EmployeesModel employee)
        {
            var existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            return existingEmployee;
        }

        public EmployeesModel GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<EmployeesModel> GetEmployees()
        {
            return employees;
        }
    }
}
