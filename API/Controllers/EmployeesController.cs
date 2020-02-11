using System.Collections.Generic;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Policy = Constants.Roles.Administrator)]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeResponse> FindById(int id)
        {
            var result = _employeeRepository.FindEmployeeById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        
        [HttpGet]
        public ActionResult<List<EmployeeResponse>> GetAll()
        {
            return Ok(_employeeRepository.GetAllEmployees());
        }
        
        [HttpPost]
        public IActionResult CreateEmployee(EmployeeCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _employeeRepository.CreateEmployee(request);
            return Ok();
        }
        
        [HttpPut("{id}")]
        public ActionResult<EmployeeResponse> UpdateEmployee(int id, EmployeeUpdateRequest request)
        {
            var cityToUpdate = _employeeRepository.FindEmployeeById(id);
            
            if (cityToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _employeeRepository.UpdateEmployee(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeRepository.FindEmployeeById(id);
            
            if (employee == null)
                return NotFound();
            
            _employeeRepository.DeleteEmployee(employee);
            return Ok();
        }
    }
}