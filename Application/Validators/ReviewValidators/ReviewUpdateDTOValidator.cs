﻿using Application.DTOs.ReviewDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.ReviewValidators
{
    public class ReviewUpdateDTOValidator : AbstractValidator<ReviewUpdateDTO>
    {
        public ReviewUpdateDTOValidator()
        {

            RuleFor(dto => dto.ReviewText)
                .NotEmpty().WithMessage("Review text cannot be empty.");

            RuleFor(dto => dto.Point)
                .InclusiveBetween(1, 10).WithMessage("Point must be between 1 and 10.");
        }
    }
}
