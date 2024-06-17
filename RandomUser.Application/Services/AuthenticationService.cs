using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RandomUser.Domain.DTOs;
using RandomUser.Domain.Entities;
using RandomUser.Domain.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Application.Services {
    public class AuthenticationService : IAuthenticationService {

        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration) {
            _configuration = configuration;
        }
        public async Task<string> Authenticate(AuthenticateRequestDTO authenticateRequest) {

            if (authenticateRequest.Username != "admin" || authenticateRequest.Password != "123456") return "";
            var token = await GenerateJwtToken(authenticateRequest.Username);
            return token;
        }

        private async Task<string> GenerateJwtToken(string userName) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() => {

                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
                var tokenDescriptor = new SecurityTokenDescriptor {
                    Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userName) }),
                    Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpireMinutes"])),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }
    }
}
