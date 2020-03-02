using System.Collections.Generic;
using API.Enums;
using API.Repositories.Interfaces;
using API.Resources.Incoming.OfficeMovementResources;
using API.Resources.Outgoing.OfficeMovementResources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.OfficeMovementControllers
{
    [ApiController]
    [Route("OfficeMovements/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, 
               Policy = Constants.Roles.Administrator)]
    public class CheckInController : ControllerBase
    {
        private readonly IOfficeCheckInRepository _officeCheckInRepository;

        public CheckInController(IOfficeCheckInRepository officeCheckInRepository)
        {
            _officeCheckInRepository = officeCheckInRepository;
        }
        
        [HttpGet]
        public ActionResult<List<OfficeCheckInResponse>> GetAll()
        {
            return Ok(_officeCheckInRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<OfficeCheckInResponse> FindById(int id)
        {
            var movement = _officeCheckInRepository.FindById(id);

            if (movement == null)
                return NotFound();
            
            return Ok(movement);
        }

        [HttpPost]
        public IActionResult Create(OfficeCheckInRequest movement)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (movement.Custody)
                return _officeCheckInRepository.CreateCheckInWithCustody(movement);

            if (movement.Failed)
                return _officeCheckInRepository.CreateCheckInWithFailure(movement);

            if (movement.OfficeToOffice)
                return _officeCheckInRepository.CreateLogisticsOnlyCheckIn(movement);
            
            if (movement.MovementType == MovementType.Deposit)
                return _officeCheckInRepository.CreateIncomingCheckIn(movement);
                
            if (movement.MovementType == MovementType.Dispatch)
                return _officeCheckInRepository.CreateOutgoingCheckIn(movement);

            return BadRequest("The request didn't fulfill any of the conditions to be processed");
        }
        
        [HttpPut("{id}")]
        public ActionResult<OfficeCheckInResponse> Update(int id, OfficeCheckInRequest movement)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (movement.Custody)
                return _officeCheckInRepository.UpdateCheckInWithCustody(id, movement);

            if (movement.Failed)
                return _officeCheckInRepository.UpdateCheckInWithFailure(id, movement);

            if (movement.OfficeToOffice)
                return _officeCheckInRepository.UpdateLogisticsOnlyCheckIn(id, movement);

            if (movement.MovementType == MovementType.Deposit)
                return _officeCheckInRepository.UpdateIncomingCheckIn(id, movement);
            
            if (movement.MovementType == MovementType.Dispatch)
                return _officeCheckInRepository.UpdateOutgoingCheckIn(id, movement);

            return BadRequest("The request didn't fulfill any of the conditions to be processed");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var movement = _officeCheckInRepository.FindMovementById(id);

            if (movement == null)
                return NotFound();
            
            _officeCheckInRepository.DeleteCheckIn(movement);
            return Ok();
        }
    }
}