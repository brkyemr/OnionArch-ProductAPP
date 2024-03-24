using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApp.Application.Bases;
using ProductApp.Application.Features.Products.Exceptions;
using ProductApp.Domain.Entities;

namespace ProductApp.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products, string requestTitle) 
        {
            if(products.Any(x=> x.Title == requestTitle))
            {
                throw new ProductTitleMustNotBeSameException();
            }
            return Task.CompletedTask;
        }
    }
}