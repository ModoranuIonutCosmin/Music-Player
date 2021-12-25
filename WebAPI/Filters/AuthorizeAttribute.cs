using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Items["User"] is not ApplicationUser)
            {
                // not logged in
                throw new UnauthorizedAccessException("Unauthorized");
            }
        }
    }
}