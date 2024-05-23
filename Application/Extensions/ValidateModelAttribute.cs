using Application.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;

namespace Application.Extensions
{
    public class ValidateModelAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values.Where(x => x.Errors.Count > 0)
            .SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
            ErrorDto errorsDto = new ErrorDto(errors.ToList());
            GenericResponseModel<ErrorDto> responseModel = new GenericResponseModel<ErrorDto>();
            responseModel.Data = errorsDto;
            responseModel.StatusCode = 400;
            context.Result = new BadRequestObjectResult(responseModel);
        }
    }

    
    }
}
