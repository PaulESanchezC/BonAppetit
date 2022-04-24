using System.Runtime.CompilerServices;
using AutoMapper;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Models.ApplicationUserModels;
using Models.ResponseModels;

namespace Services.AccountsServices;

public class AccountsService : IAccountsService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    public AccountsService(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<Response<ApplicationUserDto>> GetApplicationUser(string userId )
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is not null)
            return await ResponseSingleBuilderTask(false, 400, "Empty Result", "The user cannot be found, operation returned an empty result",
                null);

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