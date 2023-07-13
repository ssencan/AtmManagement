using AtmManagement.Api.Entities;
using FluentValidation;

namespace AtmManagement.Api.Validators
{
    public class DistrictValidator : AbstractValidator<District>
    {
        public DistrictValidator()
        {
            RuleFor(district => district.DistrictName).NotEmpty().WithMessage("DistrictName is required.");
            RuleFor(district => district.CityID).NotEmpty().WithMessage("CityID is required.");
        }
    }
}
