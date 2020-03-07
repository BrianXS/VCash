using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.OfficeMovementControllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, 
        Policy = Constants.Roles.Administrator)]
    public class CountingController : ControllerBase
    {
        private readonly IOfficeCountingRepository _countingRepository;

        public CountingController(IOfficeCountingRepository countingRepository)
        {
            _countingRepository = countingRepository;
        }
    }
}