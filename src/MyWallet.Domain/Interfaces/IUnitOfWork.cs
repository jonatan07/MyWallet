﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public interface IUnitOfWork : IDisposable
        {
            Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        }
    }
}
