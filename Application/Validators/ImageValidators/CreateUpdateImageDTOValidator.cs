using Application.DTOs.ImageDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.ImageValidators
{
    public class CreateUpdateImageDTOValidator : AbstractValidator<CreateUpdateImageDTO>
    {
        public CreateUpdateImageDTOValidator()
        {
            RuleFor(dto => dto.Url)
                .NotEmpty().WithMessage("URL cannot be empty.")
                .MaximumLength(255).WithMessage("URL cannot exceed 255 characters.");

            RuleFor(dto => dto.PropertyId)
                .GreaterThan(0).WithMessage("PropertyId must be greater than 0.");
        }
    
    }
}
