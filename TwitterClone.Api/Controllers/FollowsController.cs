using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFollows()
        {
            return Ok("Success");
        }

        [HttpGet("user/{id}")]
        public IActionResult GetFollowByUserId([FromRoute] Guid id)
        {
            return Ok($"Follow for user {id} retrieved successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetFollowById([FromRoute] Guid id)
        {
            return Ok($"Follow with ID {id} retrieved successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFollow([FromRoute] Guid id)
        {
            return Ok($"Follow with ID {id} deleted successfully");
        }

        [HttpPost]
        public IActionResult CreateFollow()
        {
            return Ok("Follow for user created successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFollow([FromRoute] Guid id)
        {
            return Ok($"Follow with ID {id} updated successfully");
        }
    }
}
