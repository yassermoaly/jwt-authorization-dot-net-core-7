using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ServiceLayer;
using System.Threading.Tasks;
using ServiceLayer.Interfaces;
namespace web_pairing_kit_dot_net.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class JwtTokenInterceptor
    {
        private readonly RequestDelegate _next;

        private readonly ITokenService _tokenService;
        public JwtTokenInterceptor(RequestDelegate next, ITokenService tokenService)
        {
            _next = next;
            _tokenService = tokenService;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string? Authorization = httpContext.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(Authorization))
            {
                httpContext.User = _tokenService.Validate(Authorization);
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class JwtTokenInterceptorExtensions
    {
        public static IApplicationBuilder UseJwtTokenInterceptor(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtTokenInterceptor>();
        }
    }
}
