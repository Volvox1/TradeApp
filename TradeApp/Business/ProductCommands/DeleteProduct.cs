using Entities.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ProductCommands
{
    public class DeleteProduct
    {
        public int Id { get; set; }
        private readonly IDBContext _context;

        public DeleteProduct(IDBContext context)
        {
            _context = context;
        }

        public void Delete()
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == Id);
            if (product == null)
            {

                throw new InvalidOperationException("Öyle bir veri yok");

            }
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}

