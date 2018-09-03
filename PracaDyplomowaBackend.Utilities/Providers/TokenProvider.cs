using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;

namespace PracaDyplomowaBackend.Utilities.Providers
{
    public class TokenProvider : ITokenProvider
    {
        private IConfiguration _configuration;

        public TokenProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string BuildToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
          _configuration["Jwt:Issuer"],
          expires: DateTime.Now.AddDays(30),
          signingCredentials: credentials,
          claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
