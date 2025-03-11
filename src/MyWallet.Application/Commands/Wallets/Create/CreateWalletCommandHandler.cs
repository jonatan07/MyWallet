using MediatR;
using MyWallet.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWallet.Domain.Entities;
using MyWallet.Domain.Responses;

namespace MyWallet.Application.Commands.Wallets.Create
{
    public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, Response<CreateWalletCommandResponse>>
    {
        
        private readonly IMediator _mediator;
        private readonly IWalletRepository _walletRepository;
        private readonly ILogger<CreateWalletCommandHandler> _logger;

        public CreateWalletCommandHandler(IMediator mediator, ILogger<CreateWalletCommandHandler> logger,
                                          IWalletRepository walletRepository)
        {
            _mediator = mediator;
            _walletRepository = walletRepository;
            _logger = logger;
        }

        public async Task<Response<CreateWalletCommandResponse>> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            var result = await _walletRepository.Add(new Wallet(request.DocumentId, request.DocumentType, request.Name));
            await _walletRepository.SaveChangesAsync(cancellationToken);
            return ProcessResponse<CreateWalletCommandResponse>.Success(
                new CreateWalletCommandResponse(result.Id));
            
        }
    }
}
