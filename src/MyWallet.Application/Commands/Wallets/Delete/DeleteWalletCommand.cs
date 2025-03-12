using MediatR;
using MyWallet.Application.Commands.Wallets.Create;
using MyWallet.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Commands.Wallets.Delete
{
    public class DeleteWalletCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }
    }
}
