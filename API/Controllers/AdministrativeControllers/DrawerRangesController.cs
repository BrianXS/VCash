using System.Collections.Generic;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AdministrativeResources;
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
    public class DrawerRangesController : ControllerBase
    {
        private readonly IDrawerRangeRepository _drawerRangeRepository;

        public DrawerRangesController(IDrawerRangeRepository drawerRangeRepository)
        {
            _drawerRangeRepository = drawerRangeRepository;
        }
        
        [HttpGet]
        public ActionResult<List<DrawerRangeResponse>> GetAll()
        {
            return Ok(_drawerRangeRepository.GetAllDrawerRanges());
        }

        [HttpGet("{id}")]
        public ActionResult<DrawerRangeResponse> FindDrawerRangeById(int id)
        {
            var result = _drawerRangeRepository.FindDrawerRangeResourceById(id);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateDrawerRange(DrawerRangeRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _drawerRangeRepository.CreateDrawerRange(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<DrawerRangeResponse> UpdateDrawerRange(int id, DrawerRangeRequest request)
        {
            var countryToUpdate = _drawerRangeRepository.FindDrawerRangeResourceById(id);
            
            if (countryToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _drawerRangeRepository.UpdateDrawerRange(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteDrawerRange(int id)
        {
            var country = _drawerRangeRepository.FindDrawerRangeById(id);
            
            if (country == null)
                return NotFound();
            
            _drawerRangeRepository.DeleteDrawerRange(country);
            return Ok();
        }
    }
}