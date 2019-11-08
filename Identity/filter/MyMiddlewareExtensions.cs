using System;
using Microsoft.AspNetCore.Builder;
namespace Identity.filter
{
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();
        }
    }
}



