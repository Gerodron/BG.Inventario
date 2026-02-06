using BG.Inventario.Application.External.GetTokenJwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BG.Inventario.External.GetTokenJwt
{
    public class GetTokenJwtService : IGetTokenJwtService
    {
        private readonly IConfiguration _configuration;
        public GetTokenJwtService(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        public string Execute(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = _configuration["SecretKeyJwt"] ?? string.Empty;
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, id)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["IssuerJwt"],
                Audience = _configuration["AudienceJwt"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenstring = tokenHandler.WriteToken(token);
            return tokenstring;
        }
    }
}
