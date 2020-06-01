using System.Collections.Generic;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AdministrativeControllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, 
        Policy = Constants.Roles.Administrator )]
    public class OfficesController : ControllerBase
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly ICustomerRepository _customerRepository;

        public OfficesController(IOfficeRepository officeRepository,
            ICustomerRepository customerRepository)
        {
            _officeRepository = officeRepository;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public ActionResult<List<OfficeResponse>> GetAll()
        {
            return Ok(_officeRepository.GetAllOffices());
        }
        
        [HttpGet("Funds/{id}")]
        public ActionResult<List<OfficeResponse>> FindAllFundsByClientId(int id)
        {
            if (_customerRepository.FindCustomerById(id) == null)
                return BadRequest();
            
            return Ok(_officeRepository.FindAllFundsByClientId(id));
        }

        [HttpGet("{id}")]
        public ActionResult<OfficeResponse> FindOfficeById(int id)
        {
            var result = _officeRepository.FindOfficeResourceById(id);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateOffice(OfficeCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _officeRepository.CreateOffice(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<OfficeResponse> UpdateOffice(int id, OfficeUpdateRequest request)
        {
            var officeToUpdate = _officeRepository.FindOfficeResourceById(id);
            
            if (officeToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _officeRepository.UpdateOffice(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteOffice(int id)
        {
            var office = _officeRepository.FindOfficeById(id);
            
            if (office == null)
                return NotFound();
            
            _officeRepository.DeleteOffice(office);
            return Ok();
        }
    }
}