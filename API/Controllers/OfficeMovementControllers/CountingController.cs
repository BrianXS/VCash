using System.Linq;
using API.Repositories.Interfaces;
using API.Resources.Incoming.OfficeMovementResources;
using API.Resources.Outgoing.OfficeMovementResources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.OfficeMovementControllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, 
        Policy = Constants.Roles.Administrator)]
    public class CountingController : ControllerBase
    {
        private readonly IOfficeCountingRepository _countingRepository;
        
        public CountingController(IOfficeCountingRepository countingRepository)
        {
            _countingRepository = countingRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<CountingProcessResponse> ViewExistingMovementCount(int id)
        {
            return _countingRepository.FindById(id);
        }

        [HttpPost("Incoming/{id}")]
        public IActionResult CountExistingIncomingMovement(int id, CountingProcessRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            return _countingRepository.CountIncomingService(id, request);
        }

        [HttpPut("Incoming/{id}")]
        public ActionResult<CountingProcessResponse> UpdateExistingIncomingMovementCount(int id, CountingProcessRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            return _countingRepository.UpdateIncomingService(id, request);
        }
        
        [HttpPost("Outgoing/{id}")]
        public IActionResult CountExistingOutgoingMovement(int id, CountingProcessRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            return _countingRepository.CountOutgoingService(id, request);
        }

        [HttpPut("Outgoing/{id}")]
        public ActionResult<CountingProcessResponse> UpdateExistingOutgoingMovementCount(int id, CountingProcessRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            return _countingRepository.UpdateOutgoingService(id, request);
        }
    }
}