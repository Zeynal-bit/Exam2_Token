using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam2_Token
{
    public class TokenMiddleweare3
    {

        
        private readonly RequestDelegate next;
        private string path;

        public TokenMiddleweare3(RequestDelegate next, string path)
        {
            this.next = next;
            this.path = path;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token == path)
            {
                await context.Response.WriteAsync("Token is valid");
            }
            else
            {
                //context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid");
            }
        }

    }
    public static class Middle2
    {
        public static IApplicationBuilder UseToke(this IApplicationBuilder app, string path)
        {
            return app.UseMiddleware<TokenMiddleweare3>(path);
        }
    }
}

