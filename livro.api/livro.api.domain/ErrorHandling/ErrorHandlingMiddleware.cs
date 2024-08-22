using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace livro.api.domain.ErrorHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            if (exception is ValidationException)
            {
                code = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(new { mensagem = String.Join(Environment.NewLine, ((ValidationException)exception).Errors.Select(x => x.ErrorMessage)) });
            }
            else
            {
                result = JsonSerializer.Serialize(new { mensagem = exception?.InnerException?.Message ?? exception.Message });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
