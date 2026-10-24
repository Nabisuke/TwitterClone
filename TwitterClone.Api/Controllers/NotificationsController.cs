using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetNotifications()
        {
            return Ok("Success");
        }
        [HttpGet("{id}")]
        public IActionResult GetNotificationByUserId([FromRoute] Guid id)
        {
            return Ok($"Notification for user {id} retrieved successfully");
        }
        [HttpGet("{id}")]
        public IActionResult GetNotificationById([FromRoute] Guid id)
        {
            return Ok($"Notification with ID {id} retrieved successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification([FromRoute] Guid id)
        {
            return Ok($"Notification with ID {id} deleted successfully");
        }
        [HttpPost]
        public IActionResult CreateNotification()
        {
            return Ok($"Notification for user created successfully");
        }
        [HttpPut("{id}/notifications")]
        public IActionResult UpdateNotification([FromRoute] Guid id, [FromBody] string notification)
        {
            return Ok($"Notification with ID {id} updated successfully");
        }
    }
}
