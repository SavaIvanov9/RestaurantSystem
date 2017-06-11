namespace RestaurantSystem.Web.ErrorHandling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using System.Net;
    using Newtonsoft.Json;
    using RestaurantSystem.Data;
    using RestaurantSystem.Models;
    using System.Text;
    using RestaurantSystem.ErrorLogData;
    using RestaurantSystem.ErrorLogData.Models;
    using RestaurantSystem.ErrorLogData.Abstraction;
    using RestaurantSystem.Infrastructure;
    using RestaurantSystem.Infrastructure.Constants;

    public class CustomErrorHandler : BaseErrorHandler
    {
        public CustomErrorHandler()
        {
        }

        public CustomErrorHandler(IErrorData data) : base(data)
        {
        }

        private readonly RequestDelegate _next;

        public CustomErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }

            //return _next(httpContext);
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            ////if (exception is MyNotFoundException) code = HttpStatusCode.NotFound;
            ////else if (exception is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            ////else if (exception is MyException) code = HttpStatusCode.BadRequest;

            //var result = JsonConvert.SerializeObject(new { error = exception.Message });
            //context.Response.ContentType = "application/json";
            //context.Response.StatusCode = (int)code;
            //return context.Response.WriteAsync(result);

            ////

            StringBuilder message = new StringBuilder("Error occured!");

            try
            {
                var system = this.Data.SystemEnvironmentRepository
                    .All()
                    .Where(x => x.IsDeleted != true
                        && x.Name == SystemEnvironments.RestaurantSystemWebMvc.ToString())
                    .FirstOrDefault();

                if (system == null)
                {
                    var restaurantSystemWebMvc = new SystemEnvironment
                    {
                        Name = SystemEnvironments.RestaurantSystemWebMvc.ToString(),
                        Description = GlobalConstants.RestaurantSystemDescription,
                    };

                    this.Data.SystemEnvironmentRepository
                        .Add(restaurantSystemWebMvc);

                    this.Data.SaveChanges();

                    restaurantSystemWebMvc.Errors.Add(new Error
                    {
                        Name = exception.Message,
                        Content = exception.ToString(),
                    });

                    this.Data.SystemEnvironmentRepository
                        .Update(restaurantSystemWebMvc);
                }
                else
                {
                    system.Errors
                        .Add(new Error
                        {
                            Name = exception.Message,
                            Content = exception.ToString(),
                            SystemEnvironmentId = system.Id,
                            SystemEnvironment = system
                        });

                    this.Data.SystemEnvironmentRepository
                        .Update(system);
                }

                this.Data.SaveChanges();

                message.Append(" Log saved successfully.");
            }
            catch (Exception ex)
            {
                message.Append(" Could not save log.");

                if (GlobalConstants.IsDevelopment)
                {
                    message.AppendLine();
                    message.AppendLine(ex.ToString());
                }
            }

            return context.Response.WriteAsync(message.ToString());
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomErrorHandler>();
        }
    }
}
