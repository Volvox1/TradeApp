using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.TestSetup
{
    public static class Products
    {
        public static void AddProduct(this TradeAppDbContext context)
        {
            context.Products.AddRange(new Product //ilk veri ekleme
                {
                    Id = 1,
                    Name = "Peynir",
                    ProductQuantity = 2,
                    ProductId = 1,
                    ProductUnitPrice = 22,
                    Description = ""
                }
                );
        }
    }
}
