using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.Persistence.Context;

namespace ProductApp.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            Console.WriteLine("*** DefaultConnection ==> ",configuration.GetConnectionString("DefaultConnection"));
            services.AddDbContext<AppDbContext>( opt => 
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
        }
    }
}

