using CarCrud.Application.Dtos;

namespace CarCrud.Application.Service
{
    public interface ICarService
    {
        Task<ICollection<GetCarDto>> GetAllAsync();
        Task<GetCarDto?> GetByIdAsync(long id);
        Task<long> CreateAsync(CreateCarDto dto);
        Task<ICollection<GetCarDto>> GetCarsByUserId(long userId);
        Task UpdateAsync(GetCarDto dto);
        Task DeleteAsync(long id);
    }
}
