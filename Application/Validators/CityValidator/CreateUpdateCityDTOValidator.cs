using Application.DTOs.CityDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.CityValidator
{
    public class CreateUpdateCityDTOValidator : AbstractValidator<CreateUpdateCityDTO>
    {
        public CreateUpdateCityDTOValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(dto => dto.Country)
                .NotEmpty().WithMessage("Country cannot be empty.")
                .MaximumLength(100).WithMessage("Country cannot exceed 100 characters.");
        }
    
    }
}
