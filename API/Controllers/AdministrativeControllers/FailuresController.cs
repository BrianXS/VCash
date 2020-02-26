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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = Constants.Roles.Administrator)]
    public class FailuresController : ControllerBase
    {
        private readonly IFailureRepository _failureRepository;

        public FailuresController(IFailureRepository failureRepository)
        {
            _failureRepository = failureRepository;
        }

        [HttpGet]
        public ActionResult<List<FailureResponse>> GetAll()
        {
            return Ok(_failureRepository.GetAllFailures());
        }

        [HttpGet("{id}")]
        public ActionResult<FailureResponse> FindFailureById(int id)
        {
            var result = _failureRepository.FindFailureResponseById(id);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateFailure(FailureCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _failureRepository.CreateFailure(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<FailureResponse> UpdateFailure(int id, FailureUpdateRequest request)
        {
            var failureToUpdate = _failureRepository.FindFailureResponseById(id);
            
            if (failureToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _failureRepository.UpdateFailure(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteFailure(int id)
        {
            var failure = _failureRepository.FindFailureById(id);
            
            if (failure == null)
                return NotFound();
            
            _failureRepository.DeleteFailure(failure);
            return Ok();
        }
    }
}