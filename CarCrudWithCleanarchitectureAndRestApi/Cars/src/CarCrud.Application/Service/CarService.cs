using CarCrud.Application.Abstractions;
using CarCrud.Domain.Entities;

namespace CarCrud.Application.Service
{
    public class CarService : ICarService
    {
        private ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<long> CreateAsync(Car car)
        {
            await _carRepository.InsertAsync(car);
            return car.CarId;
        }

        public async Task DeleteAsync(long id)
        {

            var car = await _carRepository.SelectByIdAsync(id);
            if (car == null)
            {
                throw new KeyNotFoundException($"Card with ID {id} not found.");
            }
            await _carRepository.RemoveAsync(id);
        }

        public Task<List<Car>> GetAllAsync()
        {
            var cars = _carRepository.SelectAllAsync();
            return cars;
        }

        public async Task<Car?> GetByIdAsync(long id)
        {
            var car = await _carRepository.SelectByIdAsync(id);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {id} not found.");
            }
            return car;
        }
        public async Task UpdateAsync(Car car)
        {
            var carr = await _carRepository.SelectByIdAsync(car.CarId);
            if (carr == null)
            {
                throw new KeyNotFoundException($"Car with ID {car.CarId} not found.");
            }
            await _carRepository.UpdateAsync(car);
        }
    }
}
