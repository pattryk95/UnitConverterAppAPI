using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using UnitConverterAppAPI.Entities;

namespace UnitConverterAppAPI.Authorization
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Conversion>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Conversion conversion)
        {
            if (requirement.ResourceOperation == ResourceOperation.Read ||
                requirement.ResourceOperation == ResourceOperation.Create
                )
            {
                context.Succeed(requirement);
            }
            var userId = context.User.FindFirst(c=>c.Type == ClaimTypes.NameIdentifier).Value;
            if (conversion.CreatedById == int.Parse(userId))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
