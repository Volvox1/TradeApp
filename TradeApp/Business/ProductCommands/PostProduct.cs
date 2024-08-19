using AutoMapper;
using Business.Extensions.Validations;
using Entities;
using Entities.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ProductCommands
{
    public class PostProduct
    {
        private readonly IDBContext _context;
        // private readonly IMapper _mapper;
        public PostProductViewModel ViewModel = new PostProductViewModel();
        public PostProduct(IDBContext context)
        {
            _context = context;
            // _mapper = mapper;

        }
        public void Handle()
        {
            Product product = new Product();
            product = _context.Products.SingleOrDefault(product => product.Name == ViewModel.Name)!;


            if (product != null)
                throw new InvalidOperationException("Ürün zaten var");

            product = new Product();
            product.Name = ViewModel.Name;
            product.Description = ViewModel.Description;
            product.ProductId = ViewModel.ProductId;
            product.ProductQuantity = ViewModel.ProductQuantity;
            product.ProductUnitPrice = ViewModel.ProductUnitPrice;

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public class PostProductViewModel
        {

            public string? Name { get; set; }
            public string? Description { get; set; }
            public int ProductId { get; set; }
            public decimal ProductQuantity { get; set; }
            public int ProductUnitPrice { get; set; }
        }
    }
}
