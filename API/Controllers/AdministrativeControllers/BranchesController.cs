using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Entities.Administrative;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;

        public BranchesController(IBranchRepository branchRepository, UserManager<User> userManager)
        {
            _branchRepository = branchRepository;
            _userManager = userManager;
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
        
        [HttpGet("ByUser")]
        public async Task<ActionResult<List<BranchResponse>>> GetAllBranchesByUser()
        {
            var currentUserName = HttpContext.User.Identity.Name;
            var currentUser = await _userManager.FindByNameAsync(currentUserName);
            
            return Ok(_branchRepository.GetAllBranchesByUserId(currentUser.Id));
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