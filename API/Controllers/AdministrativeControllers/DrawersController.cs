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
    public class DrawersController : ControllerBase
    {
        private readonly IDrawerRepository _drawerRangeRepository;

        public DrawersController(IDrawerRepository drawerRangeRepository)
        {
            _drawerRangeRepository = drawerRangeRepository;
        }
        
        [HttpGet]
        public ActionResult<List<DrawerResponse>> GetAll()
        {
            return Ok(_drawerRangeRepository.GetAllDrawers());
        }

        [HttpGet("{id}")]
        public ActionResult<DrawerResponse> FindDrawerById(int id)
        {
            var result = _drawerRangeRepository.FindDrawerResourceById(id);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateDrawer(DrawerRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _drawerRangeRepository.CreateDrawer(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<DrawerResponse> UpdateDrawer(int id, DrawerRequest request)
        {
            var countryToUpdate = _drawerRangeRepository.FindDrawerResourceById(id);
            
            if (countryToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _drawerRangeRepository.UpdateDrawer(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteDrawer(int id)
        {
            var country = _drawerRangeRepository.FindDrawerById(id);
            
            if (country == null)
                return NotFound();
            
            _drawerRangeRepository.DeleteDrawer(country);
            return Ok();
        }
    }
}