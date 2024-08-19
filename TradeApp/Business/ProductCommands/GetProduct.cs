using AutoMapper;
using Core.Extensions;
using Entities;
using Entities.DBContext;

namespace Business.ProductCommands
{
    public class GetProduct
    {
        private readonly IDBContext _context;
        private readonly IMapper _mapper;
        public GetProduct(IDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


        }

        public List<ProductViewModel> Handle()
        {
            var Product = _context.Products.OrderBy(x => x.Id).ToList<Product>();
            List<ProductViewModel> viewModel = new List<ProductViewModel>(); //_mapper.Map<List<ProductViewModel>>(Product); 
            foreach (var item in Product)
            {

                viewModel.Add(new ProductViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    ProductId = item.ProductId,
                    ProductQuantity = item.ProductQuantity,
                    ProductUnitPrice = item.ProductUnitPrice

                });



            }
            return viewModel;
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public int ProductId { get; set; }
            public decimal ProductQuantity { get; set; }
            public int ProductUnitPrice { get; set; }

        }
    }
}