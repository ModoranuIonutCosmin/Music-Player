using Application.Features.Auth.Commands;
using Domain.Config;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.Implementation
{
    public class JwtService
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly SymmetricSecurityKey _securityKey;
        private readonly SigningCredentials _credentials;
        private JwtTokenConfig jwtConfig = new JwtTokenConfig();

        public JwtService()
        {
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));
            _credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
        }
        public LoginResponseDTO GenerateJwt(LoginUserCommand userInfo)
        {
            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(ClaimsIdentity.DefaultNameClaimType, userInfo.UserName),
            };

            var expires = DateTime.UtcNow.AddMinutes(jwtConfig.ExpiryInMinutes);

            var token = new JwtSecurityToken
            (
                ".net",
                audience: "commonUsers",
                claims,
                DateTime.UtcNow.AddMilliseconds(-30),
                expires,
                _credentials
            );

            return new()
            {
                JwtToken = _jwtSecurityTokenHandler.WriteToken(token),
                Expires = expires
            };
        }
        public string ValidateToken(string token)
        {
            if (token == null)
                return null;

            try
            {
                _jwtSecurityTokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = _securityKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userName = jwtToken.Claims.First(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;

                return userName;
            }
            catch
            {
                return null;
            }
        }
    }
}
