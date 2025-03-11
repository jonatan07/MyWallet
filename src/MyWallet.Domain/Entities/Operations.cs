using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Domain.Entities
{
    public class Operations : BaseEntity
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string WalletId { get; private set; }
    }
}
