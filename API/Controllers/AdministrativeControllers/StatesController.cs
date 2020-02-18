using System.Collections.Generic;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AdministrativeControllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Policy = Constants.Roles.Administrator)]
    public class StatesController : ControllerBase
    {
        private readonly IStateRepository _stateRepository;
        
        public StatesController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<StateResponse> FindByStateId(int id)
        {
            var result = _stateRepository.FindStateResourceById(id);

            if (result != null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public ActionResult<List<StateResponse>> GetAllStates()
        {
            return Ok(_stateRepository.GetAllStates());
        }

        [HttpPost]
        public IActionResult CreateState(StateCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _stateRepository.CreateState(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<StateResponse> UpdateState(int id, StateUpdateRequest request)
        {
            var stateToUpdate = _stateRepository.FindStateResourceById(id);
            
            if (stateToUpdate == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            _stateRepository.UpdateState(id, request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteState(int id)
        {
            var stateToDelete = _stateRepository.FindStateById(id);
            
            if (stateToDelete == null)
                return NotFound();
            
            _stateRepository.DeleteState(stateToDelete);
            return Ok();
        }
    }
}