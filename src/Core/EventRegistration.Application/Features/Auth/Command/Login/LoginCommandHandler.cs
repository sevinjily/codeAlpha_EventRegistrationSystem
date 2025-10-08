using EventRegistration.Application.Bases;
using EventRegistration.Application.Features.Auth.Rules;
using EventRegistration.Application.Interfaces.AutoMapper;
using EventRegistration.Application.Interfaces.Tokens;
using EventRegistration.Application.Interfaces.UnitOfWorks;
using EventRegistration.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace EventRegistration.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler :BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;
        private readonly AuthRules authRules;

        public LoginCommandHandler(UserManager<User> userManager,RoleManager<Role> roleManager,IConfiguration configuration,ITokenService tokenService,AuthRules authRules,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor):base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.authRules = authRules;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user= await userManager.FindByEmailAsync(request.Email);
            bool checkPassword= await userManager.CheckPasswordAsync(user, request.Password);

            await authRules.EmailOrPasswordShouldNotBeInvalid(user,checkPassword);

            IList<string> roles =await userManager.GetRolesAsync(user);

            JwtSecurityToken token= await tokenService.CreateToken(user,roles);

            string refreshToken = tokenService.GenerateRefreshToken();

           _= int.TryParse(configuration["JWT:RefreshTokenValidityInDays"],out int refreshTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiredTime=DateTime.UtcNow.AddDays(refreshTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);
            //Bu kod SecurityStamp-ı yeniləyir, yəni:
            //User obyektinin SecurityStamp dəyəri dəyişir(bazada yeni GUID yazılır)
           //Bu da köhnə sessiyaları(tokenləri və cookie-ləri) keçərsiz edir.


            string _token=new JwtSecurityTokenHandler().WriteToken(token);

            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

            return new()
            {
                AccessToken = _token,
                RefreshToken = refreshToken,
                AccessTokenExpiration = token.ValidTo
            };

        }
    }
}
