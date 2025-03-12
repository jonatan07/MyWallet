using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Commands.Operations.Create
{
    public class CreateOperationCommandResponse
    {
        public CreateOperationCommandResponse(int id, int walletId, decimal amount, string type)
        {
            Id = id;
            WalletId = walletId;
            Amount = amount;
            Type = type;
        }

        public int Id { get; set; }
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
    }
}
