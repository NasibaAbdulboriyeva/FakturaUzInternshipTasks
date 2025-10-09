using CarCrud.Domain.Entities;

namespace CarCrud.Application.Abstractions
{

    public interface ICarRepository
    {
        Task<List<Car>> SelectAllAsync();
        Task<Car?> SelectByIdAsync(long id);
        Task<long> InsertAsync(Car car);
        Task UpdateAsync(Car car);
        Task RemoveAsync(long id);
    }
}

