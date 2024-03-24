using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ProductApp.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0)
                .WithName("Id değeri");
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithName("Başlık");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Açıklama");
            RuleFor(x => x.BrandId)
                .GreaterThan(0)
                .WithName("Marka");
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithName("Fiyat");
            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0)
                .WithName("İndirim oranı");
            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(categories => categories.Any())
                .WithName("Kategoriler");

            
        }
    }
}