using System.Collections.Generic;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AdministrativeControllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, 
        Policy = Constants.Roles.Administrator)]
    public class BusinessesTypesController : ControllerBase
    {
        private readonly IBusinessTypeRepository _businessTypeRepository;
        private readonly IMapper _mapper;

        public BusinessesTypesController(IBusinessTypeRepository businessTypeRepository, IMapper mapper)
        {
            _businessTypeRepository = businessTypeRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<List<BusinessTypeResponse>> GetAll()
        {
            return Ok(_businessTypeRepository.GetAllBusinessTypes());
        }

        [HttpGet("{id}")]
        public ActionResult<BusinessTypeResponse> FindBusinessTypeById(int id)
        {
            var result = _businessTypeRepository.FindBusinessTypeResponseById(id);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateBusinessType(BusinessTypeCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _businessTypeRepository.CreateBusinessType(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<BusinessTypeResponse> UpdateBusinessType(int id, BusinessTypeUpdateRequest request)
        {
            var failureToUpdate = _businessTypeRepository.FindBusinessTypeResponseById(id);
            
            if (failureToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _businessTypeRepository.UpdateBusinessType(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteBusinessType(int id)
        {
            var failure = _businessTypeRepository.FindBusinessTypeById(id);
            
            if (failure == null)
                return NotFound();
            
            _businessTypeRepository.DeleteBusinessType(failure);
            return Ok();
        }
    }
}