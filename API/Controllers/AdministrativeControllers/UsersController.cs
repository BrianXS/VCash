using System.Collections.Generic;
using System.Threading.Tasks;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AdministrativeControllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, 
                Policy = Constants.Roles.Administrator)]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<UserResponse>> GetAllUsers()
        {
            return Ok(_userRepository.FindAll());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<UserResponse>> FindUserById(string Id)
        {
            var userData = await _userRepository.FindUserResponseById(Id);
            
            if (userData == null) 
                return NotFound();

            return Ok(userData);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var result = await _userRepository.CreateUser(request);

            if (!result.Succeeded)
                return Problem();
            
            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateUser(UserUpdateRequest request, string Id)
        {
            var userData = await _userRepository.FindUserById(Id);

            if (userData == null)
                return NotFound();
            
            _mapper.Map(request, userData);

            var result = await _userRepository.Update(userData);
            if (!result.Succeeded)
                return Problem();
            
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            var userData = await _userRepository.FindUserById(Id);
            if (userData == null)
                return NotFound();

            var result = await _userRepository.DeleteUser(userData);
            if (!result.Succeeded)
                return Problem();
            
            return Ok();
        }
    }
}