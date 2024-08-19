using Business.ProductCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions.Validations
{
    public class PostValidation:AbstractValidator<PostProduct>
    {
        public PostValidation()
        {
            RuleFor(command=>command.ViewModel.ProductId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.ViewModel.Name).NotEmpty().MinimumLength(1);
            RuleFor(command => command.ViewModel.ProductQuantity).ExclusiveBetween(0, 100);
            RuleFor(command => command.ViewModel.ProductUnitPrice).ExclusiveBetween(1, 5000);
            RuleFor(command => command.ViewModel.Description).NotEmpty().MinimumLength(1);
          

        }
    }
}
