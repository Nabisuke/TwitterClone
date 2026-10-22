using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }

}
