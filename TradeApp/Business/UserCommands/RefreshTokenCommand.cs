using AutoMapper;
using Entities.DBContext;
using Entities.TokenOperations.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.UserCommands
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IDBContext _context;
        private readonly IConfiguration _configuration;
       

        public RefreshTokenCommand(IConfiguration configuration, IDBContext context)
        {
            _configuration = configuration;
            _context = context;
            
        }
        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x=>x.RefreshToken==RefreshToken && x.RefreshTokenExprireDate>DateTime.Now);
            if (user!=null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);
                user.RefreshTokenExprireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;

            }
            else
            {
                throw new InvalidOperationException("Geçerli bir RefreshToken Bulunamadı!");
            }
        }

    }
}
