using System.Security.Claims;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Models.ApplicationUserModels;

namespace Configurations.ProfileServiceConfigurations;

public class ProfileService : IProfileService
{
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    public ProfileService(UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var userId = context.Subject.GetSubjectId();
        var user = await _userManager.FindByIdAsync(userId);
        var userClaims = await _userClaimsPrincipalFactory.CreateAsync(user);
        var claims = userClaims.Claims.ToList().Where(claim => context.RequestedClaimTypes.Contains(claim.Type))
            .ToList();

        claims.Add(new Claim(JwtClaimTypes.GivenName,user.FirstName));
        claims.Add(new Claim(JwtClaimTypes.FamilyName,user.LastName));
        claims.Add(new Claim(JwtClaimTypes.PhoneNumber,user.PhoneNumber));
        claims.Add(new Claim(JwtClaimTypes.PreferredUserName,user.UserName));

        var roles = await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
            claims.Add(new Claim(JwtClaimTypes.Role, role));

        context.IssuedClaims = claims;
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        var userId = context.Subject.GetSubjectId();
        var user = await _userManager.FindByIdAsync(userId);
        context.IsActive = user is not null;
    }
}