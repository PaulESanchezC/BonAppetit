using System.Security.Claims;
using AutoMapper;
using Data;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.ApplicationUserModels;
using Models.ResponseModels;
using Models.RestaurantManagersModels;
using StaticData;

namespace Services.RegistrationServices;

public class RegistrationService : IRegistrationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    public RegistrationService(IMapper mapper, UserManager<ApplicationUser> userManager, ApplicationDbContext db)
    {
        _mapper = mapper;
        _userManager = userManager;
        _db = db;
    }

    public async Task<Response<ApplicationUserDto>> RegisterManagerAsync(ApplicationUserCreateDto managerToCreate, string restaurantId,
        CancellationToken cancellationToken)
    {
        var user = _mapper.Map<ApplicationUser>(managerToCreate);

        var userRegistration = await _userManager.CreateAsync(user, managerToCreate.Password);
        if (!userRegistration.Succeeded)
            return await ResponseSingleBuilderTask(false, 400, "Error", "Error creating user", null);

        var roleRegistration = await _userManager.AddToRoleAsync(user, Role.Manager);
        if (!roleRegistration.Succeeded)
            return await ResponseSingleBuilderTask(false, 400, "Error", "User is Registered but has no Role in Bon Appetit", null);

        var claimsRegistration = await _userManager.AddClaimsAsync(user, new Claim[]{
            new (JwtClaimTypes.Email, user.Email),
            new (JwtClaimTypes.GivenName, user.FirstName),
            new (JwtClaimTypes.FamilyName, user.LastName),
            new (JwtClaimTypes.PhoneNumber, user.PhoneNumber),
            new (JwtClaimTypes.Role, Role.Manager)
        });

        if (!claimsRegistration.Succeeded)
            return await ResponseSingleBuilderTask(false, 400, "Error", "User is Registered but has no Claims in Bon Appetit", null);

        var restaurantManager = new RestaurantManager
        {
            ApplicationUserId = user.Id,
            RestaurantId = restaurantId
        };
        var entity = await _db.Managers.AddAsync(restaurantManager, cancellationToken);
        if (entity.State != EntityState.Added)
            return await ResponseSingleBuilderTask(false, 400, "Operation Failed", "Could not add the user to restaurant's manager list", null);

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        {
            return await ResponseSingleBuilderTask(false, 409, "Operation Failed", "Could not save the user to restaurant's manager list", null);
        }

        return await ResponseSingleBuilderTask(true, 200, "Ok", "Ok", user);
    }

    public async Task<Response<ApplicationUserDto>> RegisterClientAsync(ApplicationUserCreateDto clientToCreate, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<ApplicationUser>(clientToCreate);

        var userRegistration = await _userManager.CreateAsync(user, clientToCreate.Password);
        if (!userRegistration.Succeeded)
            return await ResponseSingleBuilderTask(false, 400, "Error", "Error creating user", null);

        var roleRegistration = await _userManager.AddToRoleAsync(user, Role.Manager);
        if (!roleRegistration.Succeeded)
            return await ResponseSingleBuilderTask(false, 400, "Error", "User is Registered but has no Role in Bon Appetit", null);

        var claimsRegistration = await _userManager.AddClaimsAsync(user, new Claim[]{
            new (JwtClaimTypes.Email, user.Email),
            new (JwtClaimTypes.GivenName, user.FirstName),
            new (JwtClaimTypes.FamilyName, user.LastName),
            new (JwtClaimTypes.PhoneNumber, user.PhoneNumber),
            new (JwtClaimTypes.Role, Role.Manager)
        });

        if (!claimsRegistration.Succeeded)
            return await ResponseSingleBuilderTask(false, 400, "Error", "User is Registered but has no Claims in Bon Appetit", null);

        return await ResponseSingleBuilderTask(true, 200, "Ok", "Ok", user);
    }

    public Task<Response<ApplicationUserDto>> ResponseSingleBuilderTask(bool isSuccessful, int statusCode, string title, string message,
        ApplicationUser? responseObject)
    {
        var responseObjectDto = new List<ApplicationUserDto> { _mapper.Map<ApplicationUserDto>(responseObject) };

        var response = new Response<ApplicationUserDto>
        {
            IsSuccessful = isSuccessful,
            StatusCode = statusCode,
            Title = title,
            Message = message,
            ResponseObject = responseObjectDto
        };
        return Task.FromResult(response);
    }
}