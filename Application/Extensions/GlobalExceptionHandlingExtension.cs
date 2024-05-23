﻿using Application.Abstractions.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class GlobalExceptionHandlingExtension
    {
        public static void ConfigureExtentionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    Console.WriteLine("Global Exception is running");
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        //todo log yazacayiq bura
                        Log.Error($"Something went wrong: {contextFeature.Error}");
                        if (contextFeature.Error is UnauthorizedAccessException)
                        {
                            // Handle authorization error
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Unauthorized Access"
                            }));
                        }
                        else
                        {
                            // Handle other errors
                            await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = $"Internal Server Error: {contextFeature.Error}"
                            }));
                        }
                    }
                });
            });
        }
    }
}
