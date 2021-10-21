using DefinexService.DAL.Entity;
using DefinexService.DAL.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DefinexService.DAL.UOW
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : BaseEntity;
        int SaveChanges(bool useAudit = false);
        Task<int> SaveChangesAsync(bool useAudit = false);
    }
}
