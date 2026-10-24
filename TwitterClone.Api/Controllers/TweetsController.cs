using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TweetsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TweetsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult getTweets()
        {
            var maxlength = _configuration.GetValue<int>("TwitterSettings:MaxTweetLength");
            var appname = _configuration.GetValue<string>("TwitterSettings:AppName");
            // Implementation for getting tweets
            var tweets = new List<Object>
            {
                new
                {
                    UserId = Guid.NewGuid(),
                    Content = "This is a sample tweet",
                    MaxLength = maxlength,
                    AppName = appname,
                },

                new
                {
                    UserId = Guid.NewGuid(),
                    Content = "This is another sample tweet",
                    MaxLength = maxlength,
                    AppName = appname,
                },
            };

            return Ok(tweets);


        }

        [HttpGet("{id}")]
        public IActionResult GetTweetByUserId([FromRoute] Guid id)
        {
            return Ok(
                new
                {
                    UserId = id,
                    Content = "This is a sample tweet",
                    MaxLength = _configuration.GetValue<int>("TwitterSettings:MaxTweetLength"),
                    AppName = _configuration.GetValue<string>("TwitterSettings:AppName"),
                }
            );
        }

        [HttpPost]
        public IActionResult CreateTweet()
        {
            return Ok("Tweet created successfully");
        }

        [HttpPut("{id}/content")]
        public IActionResult UpdateTweet([FromRoute] Guid id, [FromBody] string content)
        {
            return Ok("Tweet updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            return Ok("Tweet deleted successfully");
        }


    }

}
