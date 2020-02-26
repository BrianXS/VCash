using System.Collections.Generic;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
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

        [HttpGet("{customerId}/{officeId}")]
        public ActionResult<CustomerFundResponse> FindCustomerFundById(int customerId, int officeId)
        {
            var result = _customerFundRepository
                .FindCustomerFundResponseById(customerId, officeId);
            
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

        [HttpPut("{customerId}/{officeId}")]
        public ActionResult<CustomerFundResponse> UpdateCustomerFund(int customerId, int officeId, CustomerFundUpdateRequest request)
        {
            var customerFundToUpdate = _customerFundRepository
                .FindCustomerFundResponseById(customerId, officeId);
            
            if (customerFundToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _customerFundRepository
                .UpdateCustomerFund(customerId, officeId, request);
            return Ok(result);
        }
        
        [HttpDelete("{customerId}/{officeId}")]
        public IActionResult DeleteCustomerFund(int customerId, int officeId)
        {
            var customerFund = _customerFundRepository
                .FindCustomerFundByCustomerAndOffice(customerId, officeId);
            
            if (customerFund == null)
                return NotFound();
            
            _customerFundRepository.DeleteCustomerFund(customerFund);
            return Ok();
        }
    }
}