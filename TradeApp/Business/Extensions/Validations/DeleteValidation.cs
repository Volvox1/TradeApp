﻿using Business.ProductCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions.Validations
{
    public class DeleteValidation:AbstractValidator<DeleteProduct>
    {
        public DeleteValidation()
        { 
            RuleFor(command=>command.Id).NotEmpty();

        }
    }
}
