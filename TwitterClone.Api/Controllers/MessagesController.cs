using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessages()
        {
            return Ok("Success");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageByUserId([FromRoute] Guid id)
        {
            return Ok($"Message for user {id} retrieved successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageById([FromRoute] Guid id)
        {
            return Ok($"Message with ID {id} retrieved successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage([FromRoute] Guid id)
        {
            return Ok($"Message with ID {id} deleted successfully");
        }
        
        [HttpPost]
        public IActionResult CreateMessage()
        {
            return Ok($"Message for user created successfully");
        }

        [HttpPut("{id}/content")]
        public IActionResult UpdateMessage([FromRoute] Guid id, string content)
        {
            return Ok($"Message with ID {id} updated successfully");
        }


    }
}
