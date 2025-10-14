using CarCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCrud.Application.Abstractions
{
    public interface IUserRepository
    {
        Task<long> InsertUserAsync(User user);
        Task<User> SelectUserByIdAsync(long id);
        Task<User?> SelectUserByUserNameAsync(string userName);
        Task UpdateUserRoleAsync(long userId, UserRole userRole);

        Task DeleteUserAsync(long userId);
        Task<ICollection<User>> SelectAllUsersAsync(int skip, int take);
    }
}
