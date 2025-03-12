using MediatR;
using MyWallet.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Commands.Wallets.Create
{
    public class CreateWalletCommand: IRequest<Response<CreateWalletCommandResponse>>
    {
        public string DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string Name { get; set; }
    }
}
