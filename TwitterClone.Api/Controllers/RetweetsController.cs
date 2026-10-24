using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RetweetsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRetweets()
        {
            return Ok("Success");
        }

        [HttpGet("{id}")]
        public IActionResult GetRetweetByUserId([FromRoute] Guid id)
        {
            return Ok($"Retweet for user {id} retrieved successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetRetweetById([FromRoute] Guid id)
        {
            return Ok($"Retweet with ID {id} retrieved successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRetweet([FromRoute] Guid id)
        {
            return Ok($"Retweet with ID {id} deleted successfully");
        }

        [HttpPost]
        public IActionResult CreateRetweet()
        {
            return Ok($"Retweet for user created successfully");
        }

        [HttpPut("{id}/content")]
        public IActionResult UpdateRetweet([FromRoute] Guid id, string content)
        {
            return Ok($"Retweet with ID {id} updated successfully");
        }
    }
}
