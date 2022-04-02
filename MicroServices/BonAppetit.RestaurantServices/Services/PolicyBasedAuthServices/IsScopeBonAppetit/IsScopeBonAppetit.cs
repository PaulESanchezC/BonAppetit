using Microsoft.AspNetCore.Authorization;
using StaticData.Role;

namespace Services.PolicyBasedAuthServices.IsUserAdmin;

public class IsScopeBonAppetit : AuthorizationHandler<IsScopeBonAppetitRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsScopeBonAppetitRequirement requirement)
    {
        if (context.User.IsInRole(Role.Restaurant))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        if(context.User.HasClaim(scp=>scp.Type == "scope" && scp.Value == requirement.ScopeName))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        return Task.CompletedTask;
    }
}