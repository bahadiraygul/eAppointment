
using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Auth.Login;

internal sealed class LoginCommandHandler(
    UserManager<AppUser> userManager, IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = 
            await userManager.Users.FirstOrDefaultAsync(
                x => x.UserName == request.UserNameOrEmail ||
                x.Email == request.UserNameOrEmail,cancellationToken);

        if(appUser is null)
        {
            return Result<LoginCommandResponse>.Failure("User not found.");
        }   

        bool IsPasswordValid = 
            await userManager.CheckPasswordAsync(appUser, request.Password);

        if(!IsPasswordValid)
        {
            return Result<LoginCommandResponse>.Failure("Invalid password.");
        }

        string token = jwtProvider.CreateToken(appUser);
        LoginCommandResponse response = new(token);
        return Result<LoginCommandResponse>.Succeed(response);
    }
}

