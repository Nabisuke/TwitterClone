using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookmarksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBookmarks()
        {
            return Ok("Success");
        }

        [HttpGet("user/{id}")]
        public IActionResult GetBookmarkByUserId([FromRoute] Guid id)
        {
            return Ok($"Bookmark for user {id} retrieved successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetBookmarkById([FromRoute] Guid id)
        {
            return Ok($"Bookmark with ID {id} retrieved successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookmark([FromRoute] Guid id)
        {
            return Ok($"Bookmark with ID {id} deleted successfully");
        }

        [HttpPost]
        public IActionResult CreateBookmark([FromBody] Guid id)
        {
            return Ok($"Bookmark for user {id} created successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookmark([FromRoute] Guid id)
        {
            return Ok($"Bookmark with ID {id} updated successfully");
        }
    }
}
