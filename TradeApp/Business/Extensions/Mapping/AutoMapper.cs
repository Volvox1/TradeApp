using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Business.ProductCommands.GetProduct;
using static Business.ProductCommands.PostProduct;

namespace Core.Extensions.Mapping
{
    public class AutoMapper:Profile
    {
        public AutoMapper() {
            CreateMap<PostProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
