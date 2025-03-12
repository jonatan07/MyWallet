using MediatR;
using MyWallet.Application.Commands.Wallets.Create;
using MyWallet.Domain.Entities;
using MyWallet.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Queries.Wallets.GetAll
{
    public class GetAllWalletsQuery: IRequest<Response<GetAllWalletsQueryResponse>>
    {
    }
}
