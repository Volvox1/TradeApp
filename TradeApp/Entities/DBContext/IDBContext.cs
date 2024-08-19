using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DBContext
{
    public interface IDBContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<User> Users { get; set; }
        int SaveChanges();
      
    }
}
