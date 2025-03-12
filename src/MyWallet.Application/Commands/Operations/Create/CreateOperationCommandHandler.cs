using MediatR;
using Microsoft.Extensions.Logging;
using MyWallet.Application.Commands.Wallets.Create;
using MyWallet.Application.Commands.Wallets.Update;
using MyWallet.Application.Responses;
using MyWallet.Domain.Entities;
using MyWallet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Commands.Operations.Create
{
    public class CreateOperationCommandHandler : IRequestHandler<CreateOperationCommand, Response<CreateOperationCommandResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IOperationRepository _OperationRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly ILogger<CreateOperationCommandHandler> _logger;
        public CreateOperationCommandHandler(IMediator mediator, ILogger<CreateOperationCommandHandler> logger,
                                          IOperationRepository operationRepository, IWalletRepository walletRepository)
        {
            _mediator = mediator;
            _logger = logger;
            _OperationRepository = operationRepository;
            _walletRepository = walletRepository;
        }
        public async Task<Response<CreateOperationCommandResponse>> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetByIdAsync(request.WalletId);
            if (wallet == null)
            {
                return ProcessResponse<CreateOperationCommandResponse>.Error(new ErrorResponse("E005", "Wallet not found"));
            }
            var result = await _OperationRepository.Add(new Domain.Entities.Operations(request.Type, request.Amount, request.WalletId));
            
            if (result.Type.ToLower() == "credito")
            {
                wallet.Balance += result.Amount;
            }
            else if (result.Type.ToLower() == "debito")
            {
                if (wallet.Balance < result.Amount)
                {
                    return ProcessResponse<CreateOperationCommandResponse>.Error(new ErrorResponse("E010", "Insufficient balance"));
                }
                wallet.Balance -= result.Amount;
            }
            await _OperationRepository.SaveChangesAsync(cancellationToken);
            await _walletRepository.SaveChangesAsync(cancellationToken);

            return ProcessResponse<CreateOperationCommandResponse>.Success(
                new CreateOperationCommandResponse(result.Id, result.WalletId, result.Amount, result.Type));
        }
    }
}
