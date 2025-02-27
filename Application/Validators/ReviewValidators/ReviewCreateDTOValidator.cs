﻿using Application.DTOs.ReviewDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.ReviewValidators
{
   public class ReviewCreateDTOValidator : AbstractValidator<ReviewCreateDTO>
    {
        public ReviewCreateDTOValidator()
        {

            RuleFor(dto => dto.PropertyId)
                .GreaterThan(0).WithMessage("Property ID must be greater than 0.");

            RuleFor(dto => dto.ReviewText)
                .NotEmpty().WithMessage("Review text cannot be empty.");

            RuleFor(dto => dto.Point)
                .InclusiveBetween(1, 10).WithMessage("Point must be between 1 and 10.");
        }
    }
}
