using Entities;
using Entities.TokenOperations.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.UserCommands
{
    public class TokenHandler
    {
        private readonly IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Token CreateAccessToken(User user)
        {
            Token TokenModel= new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Token:SecurityKey"));
            SigningCredentials Credentials=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            TokenModel.Expiration=DateTime.Now.AddMinutes(15);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: TokenModel.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: Credentials


                );
            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
            TokenModel.AccessToken=TokenHandler.WriteToken(jwtSecurityToken);
            TokenModel.RefreshToken = CreateRefreshToken();
            return TokenModel;

        }
        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
