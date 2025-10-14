using CarCrud.Application.Dtos;
using CarCrud.Application.Service;
using CarCrud.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarCrud.Presentation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("user")]
        public Task<long> CreateUserAsync(CreateUserDto userDto)
        {
            return _userService.CreateUserAsync(userDto);
        }

        [HttpGet("users")]
        public async Task<ICollection<GetUserDto>> GetAllAsync(int skip, int take)
        {
            return await _userService.GetAllUsersAsync(skip, take);
        }

        [HttpGet("user/id")]
        public async Task<GetUserDto?> GetUserByIdAsync(long userId)
        {
            return await _userService.GetUserByIdAsync(userId);
        }
        [HttpGet("user/username")]
        public async Task<GetUserDto?> GetUserByUserNameAsync(string userName)
        {
            return await _userService.GetUserByUserNameAsync(userName);
        }

        [HttpDelete("user")]
        public async Task DeleteUserAsync(long userId)
        {
            await _userService.DeleteUserAsync(userId);
        }

        [HttpPut("user")]
        public async Task UpdateUserRoleAsync(long userId, UserRole userRole)
        {
            await _userService.UpdateUserRoleAsync(userId, userRole);
        }
    }
}