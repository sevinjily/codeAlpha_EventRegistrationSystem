using EventRegistration.Application.Interfaces.Tokens;
using EventRegistration.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventRegistration.Infrastructure.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly TokenSettings tokenSettings;
        private readonly UserManager<User> userManager;

        public TokenService(IOptions<TokenSettings> options,UserManager<User> userManager)
        {
            tokenSettings = options.Value;
            this.userManager = userManager;
        }
        public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),//claimnamesdeki jti-jwt deki id mizi gosterir
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()), //userin id-i goreceyik
                new Claim(JwtRegisteredClaimNames.Email,user.Email),//emaili ona gore istifade edirikki user i logout etmek isteye bilerik
             };
            foreach (var role in roles)//role-lari claim olaraq elave edirik
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret));
            var token = new JwtSecurityToken(
                issuer: tokenSettings.Issuer,
                audience: tokenSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(tokenSettings.TokenValidityInMinutes),
                claims: claims,
                signingCredentials:new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
                );

            await userManager.AddClaimsAsync(user, claims);

            return token;
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken()
        {
            throw new NotImplementedException();
        }
    }
}
