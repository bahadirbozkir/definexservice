using DefinexService.DAL.Context;
using DefinexService.DAL.Entity;
using DefinexService.DAL.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DefinexService.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;
        public UnitOfWork(DataContext dbContext)
        {
            context = dbContext;
        }
        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(context);
        }

        public int SaveChanges(bool useAudit = false)
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(bool useAudit = false)
        {
            return await context.SaveChangesAsync();
        }
    }
}
