using JobSearch.Logic.Interfaces;
using JobSearch.Repositories.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Logic.Services
{
    internal class JwtService : IJwtService
    {
        public string CreateToken(User user)
        {
            var token = CreateJwtToken(
                CreateClaims(user),
                CreateSigningCredentials()
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials) =>
            new JwtSecurityToken(
                claims: claims,
                signingCredentials: credentials
            );

        private Claim[] CreateClaims(User user) =>
            new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

        private SigningCredentials CreateSigningCredentials() =>
            new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("secretKeyPassword")
                ),
                SecurityAlgorithms.HmacSha256
            );
    }
}
