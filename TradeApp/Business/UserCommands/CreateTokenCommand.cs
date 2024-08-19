using AutoMapper;
using Entities;
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
    public class CreateTokenCommand
    {
       
        public CreateTokenModel Model { get; set; }
        private readonly IDBContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public CreateTokenCommand(IDBContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
   public Token Handle()
        {
            User user = new();
            user = _context.Users.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password)!;
            if (user != null)
            {
                //Token
                TokenHandler handler = new TokenHandler(_configuration);
                Token token=handler.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExprireDate=token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;


            }
            else {throw new InvalidOperationException("Kullanıcı adı veya şifre yanlış"); }
                
        }

    }
public class CreateTokenModel
{
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
