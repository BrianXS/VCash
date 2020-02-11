using System.Collections.Generic;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = Constants.Roles.Administrator)]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CitiesController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public ActionResult<List<CityResponse>> GetAll()
        {
            return Ok(_cityRepository.GetAllCities());
        }

        [HttpGet("{id}")]
        public ActionResult<CityResponse> FindCityById(int id)
        {
            var result = _cityRepository.FindCityResponseById(id);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCity(CityCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _cityRepository.CreateCity(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<CityResponse> UpdateCity(int id, CityUpdateRequest request)
        {
            var cityToUpdate = _cityRepository.FindCityResponseById(id);
            
            if (cityToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _cityRepository.UpdateCity(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var city = _cityRepository.FindCityById(id);
            
            if (city == null)
                return NotFound();
            
            _cityRepository.DeleteCity(city);
            return Ok();
        }
    }
}