using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Domain.Entities
{
    public class Operations : BaseEntity
    {
        public Operations(int id,string type, decimal amount, int walletId): base(id)
        {
            Type = type;
            Amount = amount;
            WalletId = walletId;
        }
        public Operations(string type, decimal amount, int walletId)
        {
            Type = type;
            Amount = amount;
            WalletId = walletId;
        }

        public string Type { get; set; }
        public decimal Amount { get; set; }
        public int WalletId { get; set; }
    }
}
