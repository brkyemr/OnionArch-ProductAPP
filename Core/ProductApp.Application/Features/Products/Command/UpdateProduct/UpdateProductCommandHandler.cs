using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using ProductApp.Application.Bases;
using ProductApp.Application.Interfaces.AutoMapper;
using ProductApp.Application.Interfaces.UnitOfWorks;
using ProductApp.Domain.Entities;

namespace ProductApp.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : BaseHandler ,IRequestHandler<UpdateProductCommandRequest, Unit>
    {
        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {}
        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x=>x.Id == request.Id && !x.IsDeleted);

            var map = mapper.Map<Product, UpdateProductCommandRequest>(request);
            var productCategories = await unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(x=>x.ProductId == product.Id);

            await unitOfWork.GetWriteRepository<ProductCategory>().HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds)
            {
                await unitOfWork.GetWriteRepository<ProductCategory>()
                    .AddAsync(new() { CategoryId = categoryId, ProductId = product.Id });
            }
            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}