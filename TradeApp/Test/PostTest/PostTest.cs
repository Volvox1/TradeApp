using Business.ProductCommands;
using Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.TestSetup;
using Xunit;

namespace Test.PostTest
{
    public class PostTest:IClassFixture<CommonTestFixture>
    {
        private readonly TradeAppDbContext? _context;
        public PostTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
        }
        [Fact]
        public void WhenAlreadyExistProductNameIsGiven_InvalidOperationException_ShouldBeReturned()
        {
            //arrange
            Product product = new Product() {
                Description = "Test_ WhenAlreadyExistProductNameIsGiven_InvalidOperationException_ShouldBeReturned",
                ProductId = 1,
                ProductQuantity = 1,
                ProductUnitPrice = 1,
                Name = "Test_ WhenAlreadyExistProductNameIsGiven_InvalidOperationException_ShouldBeReturned"


            };
            _context?.Add(product);
            _context?.SaveChanges();
            PostProduct post = new PostProduct(_context!);
            post.ViewModel=new PostProduct.PostProductViewModel() { Name=product.Name };
            //act //assert
            FluentActions.Invoking(() => post.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Ürün zaten var");
            
        }
      
    }
}
