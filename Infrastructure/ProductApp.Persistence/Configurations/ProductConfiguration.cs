using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApp.Domain.Entities;

namespace ProductApp.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker =  new("tr");
            Product product = new()
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                //BrandId = 1,
                Discount = faker.Random.Decimal(0,10),
                IsDeleted = false,
                Price = faker.Finance.Amount(10,1000)
            };
            Product product2 = new()
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                //BrandId = 2,
                Discount = faker.Random.Decimal(0,10),
                IsDeleted = false,
                Price = faker.Finance.Amount(10,1000)
            };
            builder.HasData(product,product2);

            
        }
    }
}