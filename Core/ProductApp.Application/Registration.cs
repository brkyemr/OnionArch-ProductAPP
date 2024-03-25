using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.Application.Bases;
using ProductApp.Application.Behaviours;
using ProductApp.Application.Exceptions;
using ProductApp.Application.Features.Products.Rules;

namespace ProductApp.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly  = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();
            //services.AddTransient<ProductRules>();
            services.AddRulesFromAssemblyContaining(assembly,typeof(BaseRules));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(FluentValidationBehavior<,>));
        }
        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
            {
                services.AddTransient(item);
            }
            return services;
        }

    }
}