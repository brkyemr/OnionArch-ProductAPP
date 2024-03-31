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

namespace ProductApp.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : BaseHandler, IRequestHandler<DeleteProductCommandRequest,Unit>
    {
        public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {}
        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x=>x.Id == request.Id && !x.IsDeleted);
            product.IsDeleted = true;

            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
    }