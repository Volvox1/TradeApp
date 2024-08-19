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
    public class DeleteTest
    {

        private readonly TradeAppDbContext? _context;
        public int Id = 1;
        public DeleteTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
        }
        [Fact]
        public void WhenProductIsNull_InvalidOperationException_ShouldBeReturned()
        {
            
            DeleteProduct product = new DeleteProduct(_context!);
            product.Id = Id;
            _context?.Remove(product);
            _context?.SaveChanges();
            FluentActions.Invoking(() => product.Delete()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Öyle bir veri yok");


        }
    }
}
