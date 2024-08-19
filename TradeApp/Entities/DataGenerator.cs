using Entities.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DataGenerator //Database veri yazma
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TradeAppDbContext(serviceProvider.GetRequiredService<DbContextOptions<TradeAppDbContext>>()))
            {
                if (context.Products.Any())// Veri varsa geç
                {
                    return;
                }// yoksa
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
                context.SaveChanges();
                    }
        }
    }
}
