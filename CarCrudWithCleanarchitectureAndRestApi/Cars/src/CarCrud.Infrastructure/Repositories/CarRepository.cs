using CarCrud.Application.Abstractions;
using CarCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarCrud.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;
        public CarRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<long> InsertAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car.CarId;

        }

        public async Task RemoveAsync(long id)
        {

            var car = await _context.Cars.FirstOrDefaultAsync(c => c.CarId == id);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {id} not found.");
            }
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public Task<List<Car>> SelectAllAsync()
        {
            var cars = _context.Cars.ToListAsync();
            return cars;
        }

        public async Task<Car?> SelectByIdAsync(long id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.CarId == id);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {id} not found.");
            }
            return car;
        }
        public async Task UpdateAsync(Car car)
        {
            var carr = await _context.Cars.FirstOrDefaultAsync(c => c.CarId == car.CarId);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {car.CarId} not found.");
            }
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }
    }
}
