using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LikesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLikes()
        {
            return Ok("Success");
        }

        [HttpGet("{id}")]
        public IActionResult GetLikeByUserId([FromRoute] Guid id)
        {
            return Ok($"Like for user {id} retrieved successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetLikeById([FromRoute] Guid id)
        {
            return Ok($"Like with ID {id} retrieved successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLike([FromRoute] Guid id)
        {
            return Ok($"Like with ID {id} deleted successfully");
        }

        [HttpPost]
        public IActionResult CreateLike()
        {
            return Ok($"Like for user created successfully");
        }



    }
}
