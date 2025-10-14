using CarCrud.Application.Dtos;
using FluentValidation;


namespace CarCrud.Application.Validation
{

    public class CreateCarValidator : AbstractValidator<CreateCarDto>
    {
        public CreateCarValidator()
        {
            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Brand is required")
                .MaximumLength(50);

            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("Model is required")
                .MaximumLength(50);

            RuleFor(x => x.CarNumber)
                .NotEmpty().WithMessage("Car number is required");

            RuleFor(x => x.Year)
                .InclusiveBetween(1990, DateTime.Now.Year)
                .WithMessage("Year must be between 1990 and current year");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero");
        }
    }

}
