using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos.TweetsDto;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TweetsController : ControllerBase
    {
        private readonly ITweetService _tweetService;

        public TweetsController(ITweetService tweetService)
        {
            _tweetService = tweetService;
        }

        [HttpGet]
        public IActionResult GetTweets()
        {
            return Ok(_tweetService.GetTweets());
        }

        [HttpGet("{id}")]
        public IActionResult GetTweetById([FromRoute] Guid id)
        {
            var tweet = _tweetService.GetTweetById(id);

            if (tweet == null)
            {
                return NotFound($"Tweet with ID {id} not found.");
            }

            return Ok(tweet);
        }

        [HttpPost]
        public IActionResult CreateTweet([FromBody] CreateTweetDto createTweetDto)
        {
            var createdTweet = _tweetService.CreateTweet(createTweetDto);

            if (createdTweet == null)
            {
                return BadRequest("Tweet content is required and cannot exceed the maximum length.");
            }

            return Ok(createdTweet);
        }

        [HttpPut("{id}/content")]
        public IActionResult UpdateTweet(
            [FromRoute] Guid id,
            [FromBody] UpdateTweetDto updateTweetDto)
        {
            var existingTweet = _tweetService.GetTweetById(id);

            if (existingTweet == null)
            {
                return NotFound($"Tweet with ID {id} not found.");
            }

            var updatedTweet = _tweetService.UpdateTweet(id, updateTweetDto);

            if (updatedTweet == null)
            {
                return BadRequest("Tweet content is required and cannot exceed the maximum length.");
            }

            return Ok(updatedTweet);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            if (!_tweetService.DeleteTweet(id))
            {
                return NotFound($"Tweet with ID {id} not found.");
            }

            return Ok($"Tweet with ID {id} deleted.");
        }
    }
}