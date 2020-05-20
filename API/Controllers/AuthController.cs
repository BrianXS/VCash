using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using API.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<User> _signInManager;

        public AuthController(IUserRepository userRepository, 
            SignInManager<User> signInManager)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
        }
        
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            var loginResult = await _signInManager
                .PasswordSignInAsync(request.UserName, request.Password, false, false);
            
            if (loginResult.Succeeded)
            {
                var userData = await _userRepository.FindUserByUserName(request.UserName);
                var roles = await _userRepository.GetAllUserRoles(userData);
                
                userData.RefreshToken = TokenUtility.GenerateRefreshToken();
                await _userRepository.Update(userData);
                
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, request.UserName)
                };
                
                roles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
                
                var token = TokenUtility.GenerateToken(claims);
                
                var response = new LoginResponse
                {
                    Token = token,
                    RefreshToken = userData.RefreshToken,
                    ExpirationDate = DateTime.Now.AddMinutes(60).ToString("g")
                };
                
                return Ok(response);
            }
            
            return Unauthorized();
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult<RefreshTokenResponse>> RefreshToken(RefreshTokenRequest request)
        {
            var principal = TokenUtility.GetClaimsPrincipal(request.OldToken);
            var userName = principal.Identity.Name;
            var userData = await _userRepository.FindUserByUserName(userName);

            if (userData != null && userData.RefreshToken.Equals(request.RefreshToken))
            {
                userData.RefreshToken = TokenUtility.GenerateRefreshToken();
                await _userRepository.Update(userData);
                
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, userData.UserName),
                };
                
                claims.AddRange(await _userRepository.GetUserClaims(userData));

                var token = TokenUtility.GenerateToken(claims);
                var response = new LoginResponse
                {
                    Token = token,
                    RefreshToken = userData.RefreshToken,
                    ExpirationDate = DateTime.Now.AddMinutes(60).ToString("g")
                };
                
                return Ok(response);
            }
            
            return Unauthorized();
        }

        [HttpGet("Verify")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Verify()
        {
            return Ok();
        }
    }
}