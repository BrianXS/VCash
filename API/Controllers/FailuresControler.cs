using System.Collections.Generic;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FailuresControler : ControllerBase
    {
        private readonly IFailureRepository _failureRepository;

        public FailuresControler(IFailureRepository failureRepository)
        {
            _failureRepository = failureRepository;
        }

        [HttpGet]
        public ActionResult<List<FailureResponse>> GetAll()
        {
            return Ok(_failureRepository.GetAllFailures());
        }

        [HttpGet("{id}")]
        public ActionResult<FailureResponse> FindFailureById(int id)
        {
            var result = _failureRepository.FindFailureResponseById(id);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateFailure(FailureCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _failureRepository.CreateFailure(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<FailureResponse> UpdateFailure(int id, FailureUpdateRequest request)
        {
            var failureToUpdate = _failureRepository.FindFailureResponseById(id);
            
            if (failureToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _failureRepository.UpdateFailure(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteFailure(int id)
        {
            var failure = _failureRepository.FindFailureById(id);
            
            if (failure == null)
                return NotFound();
            
            _failureRepository.DeleteFailure(failure);
            return Ok();
        }
    }
}