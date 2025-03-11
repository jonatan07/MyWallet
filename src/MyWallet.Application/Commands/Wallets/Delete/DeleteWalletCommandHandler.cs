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

namespace MyWallet.Application.Commands.Wallets.Delete
{
    public class DeleteWalletCommandHandler : IRequestHandler<DeleteWalletCommand, Response<bool>>
    {

        private readonly IMediator _mediator;
        private readonly IWalletRepository _walletRepository;
        private readonly ILogger<DeleteWalletCommandHandler> _logger;

        public DeleteWalletCommandHandler(IMediator mediator, ILogger<DeleteWalletCommandHandler> logger,
                                          IWalletRepository walletRepository)
        {
            _mediator = mediator;
            _walletRepository = walletRepository;
            _logger = logger;
        }
        public async Task<Response<bool>> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
        {
            var entity = await _walletRepository.GetByIdAsync(request.Id);
            if (entity == null) 
            {
                return ProcessResponse<Boolean>.Error(new ErrorResponse("E005","Wallet not found"));
            }
            _walletRepository.Remove(entity);
            await _walletRepository.SaveChangesAsync(cancellationToken);
            return ProcessResponse<Boolean>.Success(true);
        }
    }
}
