using Application.DTOs.AgentDtos;
using Application.DTOs.ReviewDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.AgentValidators
{
  public class AgentCreateUpdateDTOValidator : AbstractValidator<CreateUpdateAgentDTO>
    {
        public AgentCreateUpdateDTOValidator()
        {
            RuleFor(dto => dto.AgentName)
                .NotEmpty().WithMessage("Agent name cannot be empty.")
                .MaximumLength(100).WithMessage("Agent name cannot exceed 100 characters.");

            RuleFor(dto => dto.AgentMail)
                .NotEmpty().WithMessage("Agent mail cannot be empty.")
                .MaximumLength(100).WithMessage("Agent mail cannot exceed 100 characters.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(dto => dto.AgentPhoneNumber)
                .NotEmpty().WithMessage("Agent phone number cannot be empty.")
                .MaximumLength(20).WithMessage("Agent phone number cannot exceed 20 characters.")
                .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").WithMessage("Invalid phone number format.");
        }
    }
}

