using MediatR;
using MyWallet.Application.Commands.Wallets.Create;
using MyWallet.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Commands.Wallets.Update
{
    public class UpdateWalletCommand: IRequest<Response<UpdateWalletCommandResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentId { get; set; }
        public string DocumentType { get; set; }
    }
}
