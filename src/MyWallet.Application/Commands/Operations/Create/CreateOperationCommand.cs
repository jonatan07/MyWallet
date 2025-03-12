using MediatR;
using MyWallet.Application.Commands.Wallets.Create;
using MyWallet.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public int WalletId { get; set; }
        [Required]
        [Range(0, 900000000000)]
        public decimal Amount { get; set; }
        [Required]
        [RegularExpression("debito|credito", ErrorMessage = "La operacion debe ser 'debito' o 'credito'.")]
        public string Type { get; set; }
    }
}
