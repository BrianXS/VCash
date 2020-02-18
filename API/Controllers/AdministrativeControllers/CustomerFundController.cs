using System.Collections.Generic;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AdministrativeControllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, 
               Policy = Constants.Roles.Administrator)]
    public class CustomerFundController : ControllerBase
    {
        private readonly ICustomerFundRepository _customerFundRepository;

        public CustomerFundController(ICustomerFundRepository customerFundRepository)
        {
            _customerFundRepository = customerFundRepository;
        }
        
        [HttpGet]
        public ActionResult<List<CustomerFundResponse>> GetAll()
        {
            return Ok(_customerFundRepository.GetAllCustomerFunds());
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerFundResponse> FindCustomerFundById(int id)
        {
            var result = _customerFundRepository.FindCustomerFundResponseById(id);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCustomerFund(CustomerFundCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _customerFundRepository.CreateCustomerFund(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<CustomerFundResponse> UpdateCustomerFund(int id, CustomerFundUpdateRequest request)
        {
            var customerFundToUpdate = _customerFundRepository.FindCustomerFundResponseById(id);
            
            if (customerFundToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _customerFundRepository.UpdateCustomerFund(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomerFund(int id)
        {
            var customerFund = _customerFundRepository.FindCustomerFundById(id);
            
            if (customerFund == null)
                return NotFound();
            
            _customerFundRepository.DeleteCustomerFund(customerFund);
            return Ok();
        }
    }
}