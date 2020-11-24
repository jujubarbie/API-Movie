using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using MoviesRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesRental.API.Infrastructure
{
    public class AuthRequiredAttribute : TypeFilterAttribute
    {
        public AuthRequiredAttribute() : base(typeof(AuthRequiredFilter)) { 
        
        }

        
    }

    public class AuthRequiredFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorizations);
            // recuperer le token recu
            string token = authorizations.SingleOrDefault((auth) => auth.StartsWith("Bearer "));

            // recuperer le token service au travers de l'injection de dependance
            TokenService tokenService = (TokenService)context.HttpContext.RequestServices.GetService(typeof(TokenService));

            // verifier le token 
            if (token is null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            Customer customer = tokenService.VerifyToken(token);

            if (customer is null)
                context.Result = new UnauthorizedResult();

        }
    }
}
