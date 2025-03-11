using MediatR;
using Microsoft.Extensions.Logging;
using MyWallet.Application.Commands.Wallets.Update;
using MyWallet.Application.Queries.Wallets.GetAll;
using MyWallet.Domain.Entities;
using MyWallet.Domain.Interfaces;
using MyWallet.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Queries.Wallets.GetBy
{
    public class GetWalletByIdQueryHandler : IRequestHandler<GetWalletByIdQuery, Response<GetWalletByIdQueryResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IWalletRepository _walletRepository;
        private readonly ILogger<GetWalletByIdQueryHandler> _logger;

        public GetWalletByIdQueryHandler(IMediator mediator, ILogger<GetWalletByIdQueryHandler> logger,
                                          IWalletRepository walletRepository)
        {
            _mediator = mediator;
            _walletRepository = walletRepository;
            _logger = logger;
        }

        public async Task<Response<GetWalletByIdQueryResponse>> Handle(GetWalletByIdQuery request, CancellationToken cancellationToken)
        {
            var entity =  await _walletRepository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return ProcessResponse<GetWalletByIdQueryResponse>.Error(new ErrorResponse("E005", "Wallet not found"));
            }
            await _walletRepository.SaveChangesAsync(cancellationToken);

            return ProcessResponse<GetWalletByIdQueryResponse>.Success(new GetWalletByIdQueryResponse(entity.Id,entity.DocumentId,entity.DocumentType,entity.Name));
        }
    }
}
