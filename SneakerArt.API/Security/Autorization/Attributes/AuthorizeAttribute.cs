using Microsoft.AspNetCore.Authorization;
using SneakerArt.API.Security.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SneakerArt.API.Security.Authorization.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // If action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context
            .ActionDescriptor
            .EndpointMetadata
            .OfType<AllowAnonymousAttribute>()
            .Any();

        if (allowAnonymous)
            // Then skip authorization process and return
            return;
        // Otherwise, perform authorization process
        var user = (Domain.Models.User)context.HttpContext.Items["User"]!;
        if (user == null)
            context.Result = new JsonResult(
                new { message = "Unauthorized" })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
    }
}
