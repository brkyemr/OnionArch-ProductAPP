using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Application.Interfaces.UnitOfWorks;
using ProductApp.Persistence.Context;
using ProductApp.Persistence.Repositories;
using ProductApp.Persistence.UnitOfWorks;

namespace ProductApp.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            Console.WriteLine("*** DefaultConnection ==> ",configuration.GetConnectionString("DefaultConnection"));
            services.AddDbContext<AppDbContext>( opt => 
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>),typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>),typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            
        }
    }
}

