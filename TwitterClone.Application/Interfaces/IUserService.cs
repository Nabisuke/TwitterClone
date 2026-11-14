using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos.UsersDto;

namespace TwitterClone.Application.Interfaces
{
    public interface IUserService
    {
        UserDto CreateUser(CreateUserDto createUserDto);

        UserDto GetUserById(Guid id);

        UserDto UpdateUser(Guid id, UpdateUserDto updateUserDto);

        bool DeleteUser(Guid id);

        List<UserDto> GetUsers();
    }
}
