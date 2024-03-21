using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductApp.Application.DTOs;
using ProductApp.Application.Interfaces.AutoMapper;
using ProductApp.Application.Interfaces.UnitOfWorks;
using ProductApp.Domain.Entities;

namespace ProductApp.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {


        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include : x=>x.Include(b => b.Brand));
            var brand = mapper.Map<BrandDto,Brand>(new Brand());
            //List<GetAllProductsQueryResponse> response = new();
            //response IList tipinde olmalıydı fakat interface ler new yemez ondan dolayı IList değil List ile oluşturduk

            /* foreach (var product in products)
            {
               response.Add( new GetAllProductsQueryResponse
                {
                    Title = product.Title,
                    Description = product.Description,
                    Discount = product.Discount,
                    Price = product.Price
                });
            } */   //IMapper ile birlikte böyle bir mevzuya gerek yok direk map şekliyle response dönebilirim
            var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);

            foreach (var item in map)
            {
                item.Price -= (item.Price * item.Discount / 100);
            }
            return map;
        }
    }
}