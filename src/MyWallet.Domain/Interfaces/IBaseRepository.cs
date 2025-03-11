using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> Add(T entity);
        void Remove(T entity);
        Task<T> Update(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
