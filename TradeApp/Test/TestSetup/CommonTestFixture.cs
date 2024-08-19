using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.TestSetup
{
    public class CommonTestFixture
    {
        public TradeAppDbContext? Context {  get; set; }

        public CommonTestFixture()
        {
            var options= new DbContextOptionsBuilder<TradeAppDbContext>().UseInMemoryDatabase(databaseName:"ProductTestDB").Options;
            Context= new TradeAppDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddProduct();
            Context.SaveChanges();
        }

    }
}
