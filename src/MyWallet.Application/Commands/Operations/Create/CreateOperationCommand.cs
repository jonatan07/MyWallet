using MediatR;
using MyWallet.Application.Commands.Wallets.Create;
using MyWallet.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Commands.Operations.Create
{
    public class CreateOperationCommand: IRequest<Response<CreateOperationCommandResponse>>
    {
        public CreateOperationCommand(int walletId, decimal amount, string type)
        {
            WalletId = walletId;
            Amount = amount;
            Type = type;
        }

        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
    }
}
