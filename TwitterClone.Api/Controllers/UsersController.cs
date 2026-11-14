using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos.UsersDto;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Repositories;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public UsersController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult getUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(user);
        }



        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        { 
         var createduser = _userService.CreateUser(createUserDto);
            if (createduser == null)
            {
                return BadRequest("Invalid user data or email already exists.");
            }
            return Ok(createduser);{ }


        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            _userService.DeleteUser(user.Id);
            return Ok($"User with ID {id} deleted.");
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            var existingUser = _userService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            var updatedUser = _userService.UpdateUser(id, updateUserDto);
            return Ok(updatedUser);

        }

    }
}
