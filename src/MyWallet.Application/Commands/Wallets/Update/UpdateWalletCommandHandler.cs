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

namespace MyWallet.Application.Commands.Wallets.Update
{
    public class UpdateWalletCommandHandler: IRequestHandler<UpdateWalletCommand, Response<UpdateWalletCommandResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IWalletRepository _walletRepository;
        private readonly ILogger<UpdateWalletCommandHandler> _logger;

        public UpdateWalletCommandHandler(IMediator mediator, ILogger<UpdateWalletCommandHandler> logger,
                                          IWalletRepository walletRepository)
        {
            _mediator = mediator;
            _walletRepository = walletRepository;
            _logger = logger;
        }

        public async Task<Response<UpdateWalletCommandResponse>> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
        {
            var entity = await _walletRepository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return ProcessResponse<UpdateWalletCommandResponse>.Error(new ErrorResponse("E005", "Wallet not found"));
            }
            entity.DocumentType = request.DocumentType;
            entity.DocumentId = request.DocumentId;
            entity.UpdatedAt = DateTime.UtcNow;

            await _walletRepository.SaveChangesAsync(cancellationToken);
            return ProcessResponse<UpdateWalletCommandResponse>.Success(
               new UpdateWalletCommandResponse(entity.Id,entity.Name,entity.DocumentId,entity.DocumentType));
            
        }
    }
}
