using CarCrud.Application.Abstractions;
using CarCrud.Application.Dtos;
using CarCrud.Domain.Entities;
using FluentValidation;


namespace CarCrud.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<CreateUserDto> _userCreateValidator;


        public UserService(IUserRepository userRepository, IValidator<CreateUserDto> userCreateValidator)
        {
            _userRepository = userRepository;
            _userCreateValidator = userCreateValidator;
        }

        public async Task<long> CreateUserAsync(CreateUserDto dto)
        {

            var result = await _userCreateValidator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);

            }
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
                Email = dto.Email,
                CreatedAt = DateTime.UtcNow,
                Role = dto.UserRole,
                PasswordHash = dto.Password,

            };
            await _userRepository.InsertUserAsync(user);
            return user.UserId;
        }

        public async Task DeleteUserAsync(long userId)
        {
            var user = await _userRepository.SelectUserByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<ICollection<GetUserDto>> GetAllUsersAsync(int skip, int take)
        {
            var users = await _userRepository.SelectAllUsersAsync(skip, take);
            if (users == null || users.Count == 0)
            {
                throw new Exception("No users found.");
            }

            var getDto = users.Select(dto => new GetUserDto
            {
                UserId = dto.UserId,
                FirstName = dto.FirstName,
                UserName = dto.UserName,
                LastName = dto.LastName,
                Email = dto.Email,
                CreatedAt = dto.CreatedAt,
                LastModifiedAt = dto.LastModifiedAt
            }).ToList();
            return getDto;
        }

        public async Task<GetUserDto> GetUserByIdAsync(long userId)
        {
            var user = await _userRepository.SelectUserByIdAsync(userId);
            if (user == null)
            {
                throw new Exception($"User with ID {userId} not found.");
            }
            var getDto = new GetUserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                UserName = user.UserName,
                LastName = user.LastName,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                LastModifiedAt = user.LastModifiedAt
            };
            return getDto;
        }



        public async Task<GetUserDto?> GetUserByUserNameAsync(string userName)
        {
            var user = await _userRepository.SelectUserByUserNameAsync(userName);
            if (user == null)
            {
                throw new Exception($"User with this UserName {userName} not found.");
            }
            var getDto = new GetUserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                UserName = user.UserName,
                LastName = user.LastName,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                LastModifiedAt = user.LastModifiedAt
            };
            return getDto;
        }

        public async Task UpdateUserRoleAsync(long userId, UserRole userRole)
        {
            await _userRepository.UpdateUserRoleAsync(userId, userRole);

        }
    }
}
