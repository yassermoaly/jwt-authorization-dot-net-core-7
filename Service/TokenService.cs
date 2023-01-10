using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration; 
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private byte[] SignningKey
        {
            get
            {
                return Encoding.UTF8.GetBytes(_configuration["jwt:key"] ?? throw new Exception("JWT Key is not configured"));
            }
        }
        
        private SecurityKey SecurityKey
        {
            get
            {
                return new SymmetricSecurityKey(SignningKey);
            }
        }
        private SigningCredentials SigningCredentials
        {
            get
            {
                return new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            }
        }

        public string Create(Dictionary<string, string> Claims)
        {
            var TokenDescription = new SecurityTokenDescriptor()
            {
                Issuer = _configuration["jwt:issuer"],
                Audience = _configuration["jwt:audience"],
                SigningCredentials = SigningCredentials,
                Expires = DateTime.UtcNow.AddMinutes(30),
            };
            TokenDescription.Subject = new ClaimsIdentity();
            foreach (var Claim in Claims)
            {
                TokenDescription.Subject.AddClaim(new Claim(Claim.Key, Claim.Value));
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = new JwtSecurityTokenHandler().CreateToken(TokenDescription);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal Validate(string Authorization)
        {
            string[] AuthorizationTokens = Authorization.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (AuthorizationTokens[0] == "Bearer")
            {
                string Token = AuthorizationTokens[1];
                var valid = new TokenValidationParameters()
                {

                    ValidIssuer = _configuration["jwt:issuer"],
                    ValidAudience = _configuration["jwt:audience"],
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = SecurityKey,
                    ValidateIssuerSigningKey = true,
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                return tokenHandler.ValidateToken(Token, valid, out SecurityToken validatedToken);
            }
            return ClaimsPrincipal.Current;
        }
    }
}
