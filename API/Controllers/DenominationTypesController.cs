using System.Collections.Generic;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using API.Services.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = Constants.Roles.Administrator)]
    public class DenominationTypesController : ControllerBase
    {
        private readonly IDenominationTypeRepository _denominationTypeRepository;

        public DenominationTypesController(IDenominationTypeRepository denominationTypeRepository)
        {
            _denominationTypeRepository = denominationTypeRepository;
        }
        
        [HttpGet]
        public ActionResult<List<DenominationTypeResponse>> GetAll()
        {
            return Ok(_denominationTypeRepository.GetAllDenominationTypes());
        }

        [HttpGet("{id}")]
        public ActionResult<DenominationTypeResponse> FindDenominationTypeById(int id)
        {
            var result = _denominationTypeRepository.FindDenominationTypeResponseById(id);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateDenominationType(DenominationTypeCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _denominationTypeRepository.CreateDenominationType(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<DenominationTypeResponse> UpdateDenominationType(int id, DenominationTypeUpdateRequest request)
        {
            var denomiationTypeToUpdate = _denominationTypeRepository.FindDenominationTypeResponseById(id);
            
            if (denomiationTypeToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _denominationTypeRepository.UpdateDenominationType(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteDenominationType(int id)
        {
            var denomiationType = _denominationTypeRepository.FindDenominationTypeById(id);
            
            if (denomiationType == null)
                return NotFound();
            
            _denominationTypeRepository.DeleteDenominationType(denomiationType);
            return Ok();
        }
    }
}