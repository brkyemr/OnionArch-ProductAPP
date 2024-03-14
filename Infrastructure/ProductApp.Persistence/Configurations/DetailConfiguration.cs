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
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
        Faker faker =  new("tr");

        Detail detail = new()
        {
            Id = 1,
            Title = faker.Lorem.Sentence(1),
            Description = faker.Lorem.Sentence(2),
            CategoryId = 1,
            CreatedDate = DateTime.Now
        };
        Detail detail2 = new()
        {
            Id = 2,
            Title = faker.Lorem.Sentence(1),
            Description = faker.Lorem.Sentence(2),
            CategoryId = 3,
            CreatedDate = DateTime.Now

        };
        Detail detail3 = new()
        {
            Id = 3,
            Title = faker.Lorem.Sentence(1),
            Description = faker.Lorem.Sentence(2),
            CategoryId = 2,
            CreatedDate = DateTime.Now

        };
        builder.HasData(detail,detail2,detail3);

        }
    }
}