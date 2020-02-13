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
    public class CashiersController : ControllerBase
    {
        private readonly ICashierRepository _cashierRepository;

        public CashiersController(ICashierRepository cashierRepository)
        {
            _cashierRepository = cashierRepository;
        }

        [HttpGet]
        public ActionResult<List<CashierResponse>> GetAll()
        {
            return Ok(_cashierRepository.GetAllCashiers());
        }

        [HttpGet("{id}")]
        public ActionResult<CashierResponse> FindCashierById(int id)
        {
            var cashier = _cashierRepository.FindCashierResponseById(id);

            if (cashier == null)
                return NotFound();

            return Ok(cashier);
        }

        [HttpPost]
        public IActionResult CreateCashier(CashierCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _cashierRepository.CreateCashier(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<CashierResponse> UpdateCashier(int id, CashierUpdateRequest request)
        {
            var cashierToUpdate = _cashierRepository.FindCashierResponseById(id);

            if (cashierToUpdate == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var cashier = _cashierRepository.UpdateCashier(id, request);
            return Ok(cashier);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCashier(int id)
        {
            var cashier = _cashierRepository.FindCashierById(id);

            if (cashier == null)
                return NotFound();

            _cashierRepository.DeleteCashier(cashier);
            return Ok();
        }
    }
}