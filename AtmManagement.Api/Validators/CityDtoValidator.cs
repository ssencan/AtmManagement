using FluentValidation;
using AtmManagement.Api.Dtos;

namespace AtmManagement.Api.Validators
{
    public class CityDtoValidator : AbstractValidator<CityDto>
    {
        public CityDtoValidator()
        {
            RuleFor(city => city.Name).NotEmpty().WithMessage("CityName is required.");
            RuleFor(city => city.PlateNumber).GreaterThan(0).WithMessage("PlateNumber must be greater than 90.");
        }
    }
}
