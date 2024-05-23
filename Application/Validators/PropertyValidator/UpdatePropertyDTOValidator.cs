using Application.DTOs.PropertyDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.PropertyValidator
{
    public class UpdatePropertyDTOValidator : AbstractValidator<UpdatePropertyDTO>
    {
        public UpdatePropertyDTOValidator()
        {
            RuleFor(dto => dto.Title)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");

            RuleFor(dto => dto.PublishDate)
                .NotEmpty().WithMessage("Publish Date cannot be empty.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Publish Date cannot be in the future.");

            RuleFor(dto => dto.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(dto => dto.Address)
                .NotEmpty().WithMessage("Address cannot be empty.")
                .MaximumLength(500).WithMessage("Address cannot exceed 500 characters.");

            RuleFor(dto => dto.CountRooms)
                .GreaterThanOrEqualTo(0).WithMessage("CountRooms must be 0 or greater.");

            RuleFor(dto => dto.CountBathRooms)
                .GreaterThanOrEqualTo(0).WithMessage("CountBathRooms must be 0 or greater.");

            RuleFor(dto => dto.CountSquareFeet)
                .GreaterThan(0).WithMessage("CountSquareFeet must be greater than 0.");

            RuleFor(dto => dto.Status)
                .NotEmpty().WithMessage("Status cannot be empty.")
                .MaximumLength(50).WithMessage("Status cannot exceed 50 characters.");

            RuleFor(dto => dto.AgentId)
                .GreaterThan(0).WithMessage("AgentId must be greater than 0.");

            RuleFor(dto => dto.CategoryId)
              .GreaterThan(0).WithMessage("AgentId must be greater than 0.");

            RuleFor(dto => dto.OwnerId)
                .GreaterThan(0).WithMessage("OwnerId must be greater than 0.");

            RuleFor(dto => dto.RegionOfCityId)
                .GreaterThan(0).WithMessage("RegionOfCityId must be greater than 0.");
        }
    }
}
