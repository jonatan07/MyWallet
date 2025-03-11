using MyWallet.Domain.Interfaces;
using MyWallet.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BaseDbContext _context;
        public UnitOfWork(BaseDbContext contest)
        {
            _context = contest;
        }
        protected Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) 
        {
            return _context.SaveChangesAsync();
        }
    }
}
