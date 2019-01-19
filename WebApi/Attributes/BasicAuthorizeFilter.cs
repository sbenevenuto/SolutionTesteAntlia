using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Attributes
{
    public class BasicAuthorizeFilter : IAuthorizationFilter
    {
        public BasicAuthorizeFilter()
        {
            
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string authHeader = context.HttpContext.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length);

                // Check if login is correct
                if (IsAuthorized(token))
                {
                    return;
                }
            }

            // Return authentication type (causes browser to show login dialog)
            context.HttpContext.Response.Headers["WWW-Authenticate"] = "Bearer";

            // Return unauthorized
            context.Result = new UnauthorizedResult();
        }

        // Make your own implementation of this
        public bool IsAuthorized(string token)
        {
            // Check that username and password are correct
            return token.Equals("VXNlcjE6U2VjcmV0UGFzc3dvcmQh", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
