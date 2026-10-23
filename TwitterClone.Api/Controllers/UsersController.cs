using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult getUsers()
        {
            // Implementation for getting users
            var user = new List<object>
            {
                new
                {
                    UserId = Guid.NewGuid(),
                    firstName = "nabil",
                    lastName = "safowan",
                    email = "nabilsafowan@gmail.com"
                },

                new
                {
                    UserId = Guid.NewGuid(),
                    firstName = "nabi",
                    lastName = "saf",
                    email = "nabisaf@gmail.com"
                },

                new
                {
                    UserId = Guid.NewGuid(),
                    firstName = "na",
                    lastName = "sa",
                    email = "nasa@gmail.com"
                },
            };

            return Ok(user);


        }
    }

}
