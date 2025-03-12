using MediatR;
using Microsoft.Extensions.Logging;
using MyWallet.Application.Commands.Wallets.Create;
using MyWallet.Domain.Entities;
using MyWallet.Domain.Interfaces;
using MyWallet.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Queries.Wallets.GetAll
{
    public class GetAllWalletsQueryHandler : IRequestHandler<GetAllWalletsQuery, Response<GetAllWalletsQueryResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IWalletRepository _walletRepository;
        private readonly ILogger<GetAllWalletsQueryHandler> _logger;

        public GetAllWalletsQueryHandler(IMediator mediator, ILogger<GetAllWalletsQueryHandler> logger,
                                          IWalletRepository walletRepository)
        {
            _mediator = mediator;
            _walletRepository = walletRepository;
            _logger = logger;
        }
        public async Task<Response<GetAllWalletsQueryResponse>> Handle(GetAllWalletsQuery request, CancellationToken cancellationToken)
        {
            var result = await _walletRepository.GetAll();
            await _walletRepository.SaveChangesAsync(cancellationToken);

            return ProcessResponse<GetAllWalletsQueryResponse>.Success(
               new GetAllWalletsQueryResponse(result.ToList()));
        }
    }
}
