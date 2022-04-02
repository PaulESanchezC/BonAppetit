using Microsoft.AspNetCore.Authorization;

namespace Services.PolicyBasedAuthServices.IsUserAdmin;

public class IsScopeBonAppetitRequirement : IAuthorizationRequirement
{
    public string ScopeName { get; set; }
    
    public IsScopeBonAppetitRequirement(string scopeName)
    {
        ScopeName = scopeName;
    }
}