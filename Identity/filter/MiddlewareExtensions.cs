using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.filter
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSecurityHeadersMiddleware(this IApplicationBuilder app, SecurityHeadersBuilder builder)
        {
            SecurityHeadersPolicy policy = builder.Build();
            return app.UseMiddleware<SecurityHeadersMiddleware>(policy);
        }
    }
}
