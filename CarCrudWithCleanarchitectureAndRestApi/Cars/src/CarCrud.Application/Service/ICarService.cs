using CarCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCrud.Application.Service
{
    public interface ICarService
    {
        Task<List<Car>> GetAllAsync();
        Task<Car?> GetByIdAsync(long id);
        Task<long> CreateAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(long id);
    }
}
