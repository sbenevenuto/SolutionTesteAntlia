using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Middlewares
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate next;        

        public BasicAuthMiddleware(RequestDelegate next)
        {
            this.next = next;            
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length);

                // Check if login is correct
                if (IsAuthorized(token))
                {
                    await next.Invoke(context);
                    return;
                }
            }

            // Return authentication type (causes browser to show login dialog)
            context.Response.Headers["WWW-Authenticate"] = "Bearer";
           
            // Return unauthorized
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }

        // Make your own implementation of this
        public bool IsAuthorized(string token)
        {
            // Check that username and password are correct
            return token.Equals("VXNlcjE6U2VjcmV0UGFzc3dvcmQh", StringComparison.InvariantCultureIgnoreCase);

        }
    }
}
