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
    public class ATMBatteriesController : ControllerBase
    {
        private readonly IATMBatteryRepostiory _ATMBatteryRepository;

        public ATMBatteriesController(IATMBatteryRepostiory ATMBatteryRepository)
        {
            _ATMBatteryRepository = ATMBatteryRepository;
        }

        [HttpGet]
        public ActionResult<List<ATMBatteryResponse>> GetAll()
        {
            return Ok(_ATMBatteryRepository.GetAllATMBatteries());
        }

        [HttpGet("{id}")]
        public ActionResult<ATMBatteryResponse> FindATMBatteryById(int id)
        {
            var result = _ATMBatteryRepository.FindATMBatteryResponseById(id);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateATMBattery(ATMBatteryCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _ATMBatteryRepository.CreateATMBattery(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<ATMBatteryResponse> UpdateATMBattery(int id, ATMBatteryUpdateRequest request)
        {
            var ATMBatteryToUpdate = _ATMBatteryRepository.FindATMBatteryResponseById(id);
            
            if (ATMBatteryToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _ATMBatteryRepository.UpdateATMBattery(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteATMBattery(int id)
        {
            var ATMBattery = _ATMBatteryRepository.FindATMBatteryById(id);
            
            if (ATMBattery == null)
                return NotFound();
            
            _ATMBatteryRepository.DeleteATMBattery(ATMBattery);
            return Ok();
        }
    }
}