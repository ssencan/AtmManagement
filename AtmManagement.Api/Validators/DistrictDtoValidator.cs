using AtmManagement.Api.Dtos;
using FluentValidation;

namespace AtmManagement.Api.Validators
{
    public class DistrictDtoValidator : AbstractValidator<DistrictDto>
    {
        public DistrictDtoValidator()
        {
            RuleFor(district => district.Name).NotEmpty().WithMessage("DistrictName is required.");
            RuleFor(district => district.CityId).NotEmpty().WithMessage("CityID is required.");
        }
    }
}
