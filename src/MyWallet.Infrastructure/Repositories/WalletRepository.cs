using MyWallet.Domain.Entities;
using MyWallet.Domain.Interfaces;
using MyWallet.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Infrastructure.Repositories
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
