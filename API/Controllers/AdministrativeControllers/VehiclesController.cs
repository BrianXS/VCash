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
        Policy = Constants.Roles.Administrator)]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehiclesController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        
        [HttpGet("{id}")]
        public ActionResult<VehicleResponse> FindById(int id)
        {
            var result = _vehicleRepository.FindVehicleById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        
        [HttpGet]
        public ActionResult<List<VehicleResponse>> GetAll()
        {
            return Ok(_vehicleRepository.GetAllVehicles());
        }
        
        [HttpPost]
        public IActionResult CreateVehicle(VehicleCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _vehicleRepository.CreateVehicle(request);
            return Ok();
        }
        
        [HttpPut("{id}")]
        public ActionResult<VehicleResponse> UpdateVehicle(int id, VehicleUpdateRequest request)
        {
            var cityToUpdate = _vehicleRepository.FindVehicleById(id);
            
            if (cityToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _vehicleRepository.UpdateVehicle(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            var vehicle = _vehicleRepository.FindVehicleById(id);
            
            if (vehicle == null)
                return NotFound();
            
            _vehicleRepository.DeleteVehicle(vehicle);
            return Ok();
        }
    }
}