using CarCrud.Application.Abstractions;
using CarCrud.Application.Dtos;
using CarCrud.Application.Service;
using CarCrud.Application.Validation;
using CarCrud.Application.Validators;
using CarCrud.Infrastructure.Repositories;
using FluentValidation;

namespace CarCrud.Presentation.Configurations
{
    public static class DependicyInjectionConfigurations
    {
        public static void ConfigureDI(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IValidator<CreateCarDto>, CreateCarValidator>();
            builder.Services.AddScoped<IValidator<CreateUserDto>, CreateUserValidator>();

        }
    }
}