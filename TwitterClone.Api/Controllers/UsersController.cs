using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Api.Data;
using TwitterClone.Api.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserRepository _userRepository;

        public UsersController(IConfiguration configuration, UserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult getUsers()
        {
            var users = _userRepository.GetUsers();
            return Ok(users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            }));
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return Ok(new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {

            if(string.IsNullOrWhiteSpace(createUserDto.FirstName) || 
            string.IsNullOrWhiteSpace(createUserDto.LastName) || 
            string.IsNullOrWhiteSpace(createUserDto.Email))
            {
                return BadRequest("First name, last name, and email are required.");
            }

            var existingUser = _userRepository.GetUserByEmail(createUserDto.Email);

            if (existingUser != null)
            {
                return BadRequest("A user with this email already exists.");
            }


            var user = new User(createUserDto.FirstName, createUserDto.LastName, createUserDto.Email);
            _userRepository.AddUser(user);

            return Ok(new UserDto
            {

                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            _userRepository.DeleteUser(user.Id);
            return Ok($"User with ID {id} deleted.");
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            user.Update(updateUserDto.FirstName, updateUserDto.LastName);
            _userRepository.UpdateUser(user);

            return Ok(new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });
        }

    }
}
