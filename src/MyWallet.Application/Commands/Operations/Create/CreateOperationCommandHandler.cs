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
        private readonly ILogger<CreateOperationCommandHandler> _logger;
        public CreateOperationCommandHandler(IMediator mediator, ILogger<CreateOperationCommandHandler> logger,
                                          IOperationRepository operationRepository)
        {
            _mediator = mediator;
            _OperationRepository = operationRepository;
            _logger = logger;
        }
        public async Task<Response<CreateOperationCommandResponse>> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
            var result = await _OperationRepository.Add(new Domain.Entities.Operations(request.Type, request.Amount, request.WalletId));
            await _OperationRepository.SaveChangesAsync(cancellationToken);
            return ProcessResponse<CreateOperationCommandResponse>.Success(
                new CreateOperationCommandResponse(result.Id, result.WalletId, result.Amount, result.Type));
        }
    }
}
