using CarCrud.Application.Abstractions;
using CarCrud.Application.Dtos;
using CarCrud.Domain.Entities;
using FluentValidation;

namespace CarCrud.Application.Service
{
    public class CarService : ICarService
    {
        private ICarRepository _carRepository;
        private readonly IValidator<CreateCarDto> _createCarDtoValidator;

        public CarService(ICarRepository carRepository, IValidator<CreateCarDto> createCarDtoValidator)
        {
            _carRepository = carRepository;
            _createCarDtoValidator = createCarDtoValidator;
        }
        public async Task<long> CreateAsync(CreateCarDto dto)
        {
            var result = await _createCarDtoValidator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);

            }
            var car = new Car
            {
                Brand = dto.Brand,
                Model = dto.Model,
                CarNumber = dto.CarNumber,
                Year = dto.Year,
                Price = dto.Price,
                UserId = dto.UserId,
                CreatedAt = DateTime.UtcNow

            };
            await _carRepository.InsertAsync(car);
            return car.CarId;
        }

        public async Task DeleteAsync(long id)
        {

            var car = await _carRepository.SelectByIdAsync(id);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {id} not found.");
            }
            await _carRepository.RemoveAsync(id);
        }

        public async Task<ICollection<GetCarDto>> GetAllAsync()
        {
            var cars = await _carRepository.SelectAllAsync();

            var getDto = cars.Select(car => new GetCarDto
            {
                CarId = car.CarId,
                Brand = car.Brand,
                Model = car.Model,
                CarNumber = car.CarNumber,
                Year = car.Year,
                Price = car.Price,
                CreatedAt = car.CreatedAt,
                LastModifiedAt = car.LastModifiedAt
            }).ToList();

            return getDto;
        }


        public async Task<GetCarDto?> GetByIdAsync(long id)
        {
            var car = await _carRepository.SelectByIdAsync(id);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {id} not found.");
            }
            var dto = new GetCarDto
            {
                CarId = car.CarId,
                Brand = car.Brand,
                Model = car.Model,
                CarNumber = car.CarNumber,
                Year = car.Year,
                Price = car.Price,
                LastModifiedAt = car.LastModifiedAt,
                CreatedAt = car.CreatedAt,
            };
            return dto;
        }
        public async Task UpdateAsync(GetCarDto dto)
        {
            var car = await _carRepository.SelectByIdAsync(dto.CarId);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {dto.CarId} not found.");
            }
            //validator kere getDtoga year uchun ???

            car.Brand = dto.Brand;
            car.Model = dto.Model;
            car.CarNumber = dto.CarNumber;
            car.Year = dto.Year;
            car.Price = dto.Price;
            car.LastModifiedAt = DateTime.UtcNow;

            await _carRepository.UpdateAsync(car);
        }

        public async Task<ICollection<GetCarDto>> GetCarsByUserId(long userId)
        {
            var cars = await _carRepository.SelectCarsByUserIdAsync(userId);

            if (cars == null || !cars.Any())
            {
                throw new KeyNotFoundException($"Cars for User ID {userId} not found.");
            }

            var getDto = cars.Select(car => new GetCarDto
            {
                CarId = car.CarId,
                Brand = car.Brand,
                Model = car.Model,
                CarNumber = car.CarNumber,
                Year = car.Year,
                Price = car.Price,
                CreatedAt = car.CreatedAt,
                LastModifiedAt = car.LastModifiedAt
            }).ToList();

            return getDto;
        }

    }
}
