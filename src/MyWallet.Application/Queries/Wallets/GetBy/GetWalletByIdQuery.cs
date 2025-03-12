using MediatR;
using MyWallet.Application.Responses;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Queries.Wallets.GetBy
{
    public class GetWalletByIdQuery: IRequest<Response<GetWalletByIdQueryResponse>>
    {
        public int Id { get; set; }
        public GetWalletByIdQuery(int id)
        {
            Id = id;
        }
    }
}
