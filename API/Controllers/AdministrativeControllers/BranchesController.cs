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
    public class BranchesController : ControllerBase
    {
        private readonly IBranchRepository _branchRepository;

        public BranchesController(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        
        [HttpGet("{id}")]
        public ActionResult<BranchResponse> FindById(int id)
        {
            var result = _branchRepository.FindBranchById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        
        [HttpGet]
        public ActionResult<List<BranchResponse>> GetAll()
        {
            return Ok(_branchRepository.GetAllBranches());
        }
        
        [HttpPost]
        public IActionResult CreateBranch(BranchCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _branchRepository.CreateBranch(request);
            return Ok();
        }
        
        [HttpPut("{id}")]
        public ActionResult<BranchResponse> UpdateBranch(int id, BranchUpdateRequest request)
        {
            var cityToUpdate = _branchRepository.FindBranchById(id);
            
            if (cityToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _branchRepository.UpdateBranch(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteBranch(int id)
        {
            var branch = _branchRepository.FindBranchById(id);
            
            if (branch == null)
                return NotFound();
            
            _branchRepository.DeleteBranch(branch);
            return Ok();
        }
    }
}