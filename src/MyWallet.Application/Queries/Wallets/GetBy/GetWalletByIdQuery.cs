using MediatR;
using MyWallet.Domain.Entities;
using MyWallet.Domain.Responses;
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
