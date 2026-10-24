using Microsoft.AspNetCore.Authorization;
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


        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            return Ok(
                new
                {
                    UserId = id,
                    firstName = "nabil",
                    lastName = "safowan",
                    email = "nabilsafowan@gmail.com"

                }
            );
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser()
        {
            return Ok("User Created");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            return Ok($"{id} Deleted");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id)
        {
            return Ok($"{id} Updated");
        }

    }
}
