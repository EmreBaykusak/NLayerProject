using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;

namespace NLayer.API.Middlewares;

public static class UseCustomExceptionHandler
{
    public static void UseCustomException(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(config =>
        {
            config.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var exceptionFailure = context.Features.Get<IExceptionHandlerFeature>();

                var statusCode = exceptionFailure.Error switch
                {
                    ClientSideException => 400,
                    NotFoundException => 404,
                    _ => 500
                };
                context.Response.StatusCode = statusCode;

                var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFailure.Error.Message);

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            });
        });
    }
}