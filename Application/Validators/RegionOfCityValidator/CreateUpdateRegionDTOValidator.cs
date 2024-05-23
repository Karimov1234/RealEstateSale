using Application.DTOs.RegionOfCity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.RegionOfCityValidator
{
    public class CreateUpdateRegionDTOValidator : AbstractValidator<CreateUpdateRegionDTO>
    {
        public CreateUpdateRegionDTOValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(dto => dto.CityId)
                .GreaterThan(0).WithMessage("CityId must be greater than 0.");
        }
    
    }
}
