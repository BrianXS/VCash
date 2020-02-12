using System.Collections.Generic;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ATMController : ControllerBase
    {
        private readonly IATMRepository _ATMRepository;

        public ATMController(IATMRepository ATMRepository)
        {
            _ATMRepository = ATMRepository;
        }

        [HttpGet]
        public ActionResult<List<ATMResponse>> GetAll()
        {
            return Ok(_ATMRepository.GetAllATM());
        }

        [HttpGet("{id}")]
        public ActionResult<ATMResponse> FindATMById(int id)
        {
            var result = _ATMRepository.FindATMResponseById(id);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateATM(ATMCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _ATMRepository.CreateATM(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<ATMResponse> UpdateATM(int id, ATMUpdateRequest request)
        {
            var ATMToUpdate = _ATMRepository.FindATMResponseById(id);
            
            if (ATMToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _ATMRepository.UpdateATM(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteATM(int id)
        {
            var ATM = _ATMRepository.FindATMById(id);
            
            if (ATM == null)
                return NotFound();
            
            _ATMRepository.DeleteATM(ATM);
            return Ok();
        }
    }
}