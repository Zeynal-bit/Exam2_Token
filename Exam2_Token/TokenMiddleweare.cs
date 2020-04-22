using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam2_Token.Middleweare
{
    public class TokenMiddleweare
    {
        private readonly RequestDelegate next;
        public TokenMiddleweare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token == "123456")
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
}
