using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApp.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace TodoApp.Extensions.Middlewares
{
    public class ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                _logger.LogInformation(
                    "{0} - {1}",
                    context.Request.Method,
                    context.Request.QueryString
                );
                await _next(context);
            }
            catch (ExceptionBase ex)
            {
                if (ex.Result is not null)
                    await HandleCustomExceptionAsync(context, ex);
                else
                {
                    ErrorModel model = new() { Code = ex.Code, Message = ex.Message };
                    await HandleAsync(context, (int)ex.ExceptionStatusCode, model);
                }
            }
            catch (Exception ex)
            {
                ErrorModel model = new() { Code = 0, };

                _logger.LogError("{0} - {1}", ex.Source, ex.Message);

                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.Message);

                await HandleAsync(context, (int)HttpStatusCode.InternalServerError, model);
            }
        }

        private async Task HandleCustomExceptionAsync(
            HttpContext context,
            ExceptionBase exceptionBase
        )
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exceptionBase.ExceptionStatusCode;

            await exceptionBase.Result!.ExecuteResultAsync(
                new ActionContext { HttpContext = context }
            );
        }

        private async Task HandleAsync(HttpContext context, int code, ErrorModel model)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            var result = JsonConvert.SerializeObject(model);

            await context.Response.WriteAsync(result);
        }

        private class ErrorModel
        {
            [JsonProperty("code")]
            public int Code { get; set; }

            [JsonProperty("message")]
            public string? Message { get; set; }

            public override string ToString()
            {
                return Code + " " + Message;
            }
        }
    }
}
