using AutoMapper;
using Business.UserCommands;
using Entities.DBContext;
using Entities.TokenOperations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IDBContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UserController(IDBContext dBContext,IMapper mapper,IConfiguration configuration)
        {
            _config = configuration;
            _context = dBContext;
            _mapper = mapper;
        }



        [HttpPost]
        public IActionResult UserCreate([FromBody] CreateUserModel NewUser)
        {
            try
            {
CreateUserCommand command= new CreateUserCommand(_context,_mapper);
            command.Model= NewUser;
            command.Handle();
            
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            try {CreateTokenCommand command = new CreateTokenCommand(_context,_mapper,_config);
            command.Model= login;
            var Token=command.Handle();
            return Token; }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("RefreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            try
            {
                RefreshTokenCommand command = new RefreshTokenCommand(_config,_context);
                command.RefreshToken = token;
                var ResultToken = command.Handle();
                return ResultToken;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }

}
