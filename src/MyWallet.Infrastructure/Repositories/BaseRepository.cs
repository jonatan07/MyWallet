using MyWallet.Domain.Entities;
using MyWallet.Domain.Interfaces;
using MyWallet.Infrastructure.Context;
using MyWallet.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly BaseDbContext _context;
        public BaseRepository(BaseDbContext context)
        {
            _context = context;
        }
        public IQueryable<T> GetAll()
        {
            return  _context.Set<T>().AsQueryable();
        }
        public  async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public  Task<T> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return Task.FromResult(entity);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return Task.FromResult(entity);
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
