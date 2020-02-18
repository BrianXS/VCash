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
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public ActionResult<List<CountryResponse>> GetAll()
        {
            return Ok(_countryRepository.GetAllCountries());
        }

        [HttpGet("{id}")]
        public ActionResult<CountryResponse> FindCountryById(int id)
        {
            var result = _countryRepository.FindCountryResourceById(id);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCountry(CountryCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _countryRepository.CreateCountry(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<CountryResponse> UpdateCountry(int id, CountryUpdateRequest request)
        {
            var countryToUpdate = _countryRepository.FindCountryResourceById(id);
            
            if (countryToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _countryRepository.UpdateCountry(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var country = _countryRepository.FindCountryById(id);
            
            if (country == null)
                return NotFound();
            
            _countryRepository.DeleteCountry(country);
            return Ok();
        }
    }
}