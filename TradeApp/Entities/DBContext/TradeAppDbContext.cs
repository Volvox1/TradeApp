using Entities;
using Entities.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    public class TradeAppDbContext: DbContext, IDBContext //EF (entity framework) bağlantısı
    {
      

        public TradeAppDbContext(DbContextOptions<TradeAppDbContext> options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
