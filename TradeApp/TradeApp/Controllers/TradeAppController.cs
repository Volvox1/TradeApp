using AutoMapper;
using Business.Extensions.Validations;
using Business.ProductCommands;
using Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Controllers
{
    [Authorize]
    [Route("[controller]s")]
    [ApiController]
    public class TradeAppController : ControllerBase
    {
        private readonly TradeAppDbContext _context;
        private readonly IMapper _mapper;
        public TradeAppController(TradeAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetProduct()
        {
            GetProduct get = new GetProduct(_context,_mapper);
            var value = get.Handle();
            return Ok(value);


        }
        [HttpPost]
        public IActionResult PostProduct([FromBody] PostProduct.PostProductViewModel newProduct)
        {
            PostProduct post = new PostProduct(_context);
            try
            {
                post.ViewModel = newProduct;
                PostValidation validate = new PostValidation();
                validate.ValidateAndThrow(post);
                
                post.Handle();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok();


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            

            try
            {   
                DeleteProduct delete=new DeleteProduct(_context);
                DeleteValidation validate = new DeleteValidation();
               
               delete.Id=id;
                 validate.ValidateAndThrow(delete);
                delete.Delete();
            

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
            
        }
    }
}
