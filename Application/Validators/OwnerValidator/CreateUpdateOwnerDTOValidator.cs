using Application.DTOs.OwnerDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.OwnerValidator
{
   public class CreateUpdateOwnerDTOValidator : AbstractValidator<CreateUpdateOwnerDTO>
    {
        public CreateUpdateOwnerDTOValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(dto => dto.Surname)
                .NotEmpty().WithMessage("Surname cannot be empty.")
                .MaximumLength(100).WithMessage("Surname cannot exceed 100 characters.");

            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(dto => dto.PhoneNumber)
                .NotEmpty().WithMessage("Phone number cannot be empty.")
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.")
                .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").WithMessage("Invalid phone number format.");
        }
    }
}
