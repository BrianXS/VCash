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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerResponse> FindById(int id)
        {
            var result = _customerRepository.FindCustomerById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        
        [HttpGet]
        public ActionResult<List<CustomerResponse>> GetAll()
        {
            return Ok(_customerRepository.GetAllCustomers());
        }
        
        [HttpPost]
        public IActionResult CreateCustomer(CustomerCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _customerRepository.CreateCustomer(request);
            return Ok();
        }
        
        [HttpPut("{id}")]
        public ActionResult<CustomerResponse> UpdateCustomer(int id, CustomerUpdateRequest request)
        {
            var cityToUpdate = _customerRepository.FindCustomerResponseById(id);
            
            if (cityToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _customerRepository.UpdateCustomer(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerRepository.FindCustomerById(id);
            
            if (customer == null)
                return NotFound();
            
            _customerRepository.DeleteCustomer(customer);
            return Ok();
        }
    }
}