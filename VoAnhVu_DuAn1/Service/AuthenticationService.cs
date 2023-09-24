using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface IAuthenticationService
    {
        string GenerateToken(UserEntity user);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppSetting _appSettings;

        public AuthenticationService(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GenerateToken(UserEntity user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.RoleName),
                new Claim("Username", user.Username),
                new Claim("UserId", user.UserId),
                //new Claim("RoleId", user.RoleId),
                //new Claim("RoleName", roleName),

                new Claim("TokenId", Guid.NewGuid().ToString())
            }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }

    }
}
