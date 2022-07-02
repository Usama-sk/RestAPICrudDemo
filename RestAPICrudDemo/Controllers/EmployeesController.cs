using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPICrudDemo.EmployeeData;
using RestAPICrudDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPICrudDemo.Controllers
{

    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeesData _employeeData;

        //constructor
        public EmployeesController(IEmployeesData employesData)
        {
            _employeeData = employesData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with Id:{id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(EmployeesModel employee)
        {
            _employeeData.AddEmployee(employee);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }

        [HttpDelete]
        [Route("api/[controller]/(id)")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"Employee with Id:{id} was not found");
        }



        [HttpPatch]
        [Route("api/[controller]")]
        public IActionResult EditEmployee(EmployeesModel employee)
        {
            var existingemployee = _employeeData.GetEmployee(employee.Id);
            if (existingemployee != null)
            {
                employee.Id = existingemployee.Id;
                _employeeData.EditEmployee(employee);

            }

            return Ok(employee);
        }


    }
}
