using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Application.Interfaces.UnitOfWorks;
using ProductApp.Persistence.Context;
using ProductApp.Persistence.Repositories;

namespace ProductApp.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();  //tek satırda return varsa bu yapıda kullanabilirim

        public int Save() => dbContext.SaveChanges(); 

        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>()=> new ReadRepository<T>(dbContext);
   
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()=> new WriteRepository<T>(dbContext);
    }
}