using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.Application.Interfaces.AutoMapper;

namespace ProductApp.Mapper
{
    public static class Registration
    {

        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper,AutoMapper.Mapper>();
        }
    }
}