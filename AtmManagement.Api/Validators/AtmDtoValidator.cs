using FluentValidation;
using AtmManagement.Api.Dtos;

namespace AtmManagement.Api.Validators
{
    public class AtmDtoValidator : AbstractValidator<AtmDto>
    {
        public AtmDtoValidator()
        {    
            RuleFor(a => a.AtmName)
                .NotEmpty()
                .WithMessage("AtmName cannot be empty")
                .Length(1, 100)
                .WithMessage("AtmName length should be between 1 and 100 characters");

            RuleFor(a => a.Latitude)
                .NotEmpty()
                .WithMessage("Latitude cannot be empty")
                .InclusiveBetween(-90.0, 90.0)
                .WithMessage("Latitude must be between -90 and 90");

            RuleFor(a => a.Longitude)
                .NotEmpty()
                .WithMessage("Longitude cannot be empty")
                .InclusiveBetween(-180.0, 180.0)
                .WithMessage("Longitude must be between -180 and 180");

            RuleFor(a => a.IsActive)
                .NotNull()
                .WithMessage("IsActive cannot be null");

            RuleFor(a => a.CityID)
                .NotEmpty()
                .WithMessage("CityID cannot be empty");

            RuleFor(a => a.DistrictID)
                .NotEmpty()
                .WithMessage("DistrictID cannot be empty");
        }
    }
}
