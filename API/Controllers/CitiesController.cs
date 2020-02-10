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
            return _cityRepository.GetAllCities();
        }

        [HttpGet("{id}")]
        public ActionResult<CityResponse> FindCountryById(int id)
        {
            var result = _cityRepository.FindCityResponseById(id);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCountry(CityCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _cityRepository.CreateCity(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<CityResponse> UpdateCountry(int id, CityUpdateRequest request)
        {
            var countryToUpdate = _cityRepository.FindCityResponseById(id);
            
            if (countryToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _cityRepository.UpdateCity(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var country = _cityRepository.FindCityById(id);
            
            if (country == null)
                return NotFound();
            
            _cityRepository.DeleteCity(country);
            return Ok();
        }
    }
}