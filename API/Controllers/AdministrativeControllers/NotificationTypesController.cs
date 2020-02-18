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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = Constants.Roles.Administrator)]
    public class NotificationTypesController : ControllerBase
    {
        private readonly INotificationTypeRepository _notificationTypeRepository;

        public NotificationTypesController(INotificationTypeRepository notificationTypeRepository)
        {
            _notificationTypeRepository = notificationTypeRepository;
        }
        
        [HttpGet]
        public ActionResult<List<NotificationTypeResponse>> GetAll()
        {
            return Ok(_notificationTypeRepository.GetAllNotificationTypes());
        }

        [HttpGet("{id}")]
        public ActionResult<NotificationTypeResponse> FindNotificationTypeById(int id)
        {
            var result = _notificationTypeRepository.FindNotificationTypeResponseById(id);
            
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateNotificationType(NotificationTypeCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _notificationTypeRepository.CreateNotificationType(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<NotificationTypeResponse> UpdateNotificationType(int id, NotificationTypeUpdateRequest request)
        {
            var denomiationTypeToUpdate = _notificationTypeRepository.FindNotificationTypeResponseById(id);
            
            if (denomiationTypeToUpdate == null) 
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _notificationTypeRepository.UpdateNotificationType(id, request);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteNotificationType(int id)
        {
            var denomiationType = _notificationTypeRepository.FindNotificationTypeById(id);
            
            if (denomiationType == null)
                return NotFound();
            
            _notificationTypeRepository.DeleteNotificationType(denomiationType);
            return Ok();
        }
    }
}