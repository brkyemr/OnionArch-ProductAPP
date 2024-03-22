using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApp.Domain.Entities;

namespace ProductApp.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey( x => new { x.ProductId, x.CategoryId });

            builder.HasOne(x => x.Product)
            .WithMany(pc => pc.ProductCategories)
            .HasForeignKey(p=> p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Category)
            .WithMany(pc => pc.ProductCategories)
            .HasForeignKey(c=> c.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}