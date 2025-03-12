using MediatR;
using MyWallet.Application.Queries.Wallets.GetAll;
using MyWallet.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Queries.Operations.GetAll
{
    public class GetAllOperationsQuery: IRequest<Response<GetAllOperationsQueryResponse>>
    {

    }
}
