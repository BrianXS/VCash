using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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
        public ActionResult<UserResponse> FindUserById(string Id)
        {
            var userData = _userRepository.FindUserById(Id);
            
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

        [HttpPost("{Id}")]
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