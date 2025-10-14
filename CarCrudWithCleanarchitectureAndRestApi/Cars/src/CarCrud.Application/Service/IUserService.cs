using CarCrud.Application.Dtos;
using CarCrud.Domain.Entities;

namespace CarCrud.Application.Service
{
    public interface IUserService
    {
        Task<long> CreateUserAsync(CreateUserDto dto);
        Task<GetUserDto> GetUserByIdAsync(long id);
        Task<GetUserDto?> GetUserByUserNameAsync(string userName);
        Task UpdateUserRoleAsync(long userId, UserRole userRole);

        Task DeleteUserAsync(long userId);
        Task<ICollection<GetUserDto>> GetAllUsersAsync(int skip, int take);
    }
}