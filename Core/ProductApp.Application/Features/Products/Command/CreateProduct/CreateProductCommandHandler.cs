using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using ProductApp.Application.Bases;
using ProductApp.Application.Features.Products.Rules;
using ProductApp.Application.Interfaces.AutoMapper;
using ProductApp.Application.Interfaces.UnitOfWorks;
using ProductApp.Domain.Entities;

namespace ProductApp.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly ProductRules productRules;
        public CreateProductCommandHandler(ProductRules productRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.productRules = productRules;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();
            /*
             if(products.Any(x=>x.Title == request.Title))
                throw new Exception("Same title not excepted"); */
                //
            await productRules.ProductTitleMustNotBeSame(products,request.Title);
            
            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if(await unitOfWork.SaveAsync()> 0) //kaçtane kayıt olduysa onun sayısını int olarak döner
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    }
                    );
                }

                await unitOfWork.SaveAsync();
            }
            return Unit.Value; 
        }
    }
}