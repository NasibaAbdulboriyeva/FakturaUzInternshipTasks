using CarCrud.Application.Dtos;
using CarCrud.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace CarCrud.Presentation.Controllers
{

    [Route("api/")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("car")]
        public Task<long> CreateCarAsync(CreateCarDto carDto)
        {
            return _carService.CreateAsync(carDto);
        }

        [HttpGet("cars")]
        public async Task<ICollection<GetCarDto>> GetAllAsync()
        {
            return await _carService.GetAllAsync();
        }

        [HttpGet("car/id")]
        public async Task<GetCarDto?> GetByIdAsync(long carId)
        {
            return await _carService.GetByIdAsync(carId);
        }


        [HttpDelete("car")]
        public async Task DeleteBookingAsync(long carId)
        {
            await _carService.DeleteAsync(carId);
        }

        [HttpPut("car")]
        public async Task UpdateBookingAsync(GetCarDto getCarDto)
        {
            await _carService.UpdateAsync(getCarDto);
        }
    }
}
