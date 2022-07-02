using RestAPICrudDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPICrudDemo.EmployeeData
{
    public interface IEmployeesData
    {
        List<EmployeesModel> GetEmployees();

        EmployeesModel GetEmployee(Guid id);

        EmployeesModel AddEmployee(EmployeesModel employee);

        EmployeesModel EditEmployee(EmployeesModel employee);

        void DeleteEmployee(EmployeesModel employee);


    }
}
