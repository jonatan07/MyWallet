using MediatR;
using Microsoft.Extensions.Logging;
using MyWallet.Application.Queries.Wallets.GetAll;
using MyWallet.Application.Responses;
using MyWallet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Queries.Operations.GetAll
{
    public class GetAllOperationsQueryHandler:IRequestHandler<GetAllOperationsQuery, Response<GetAllOperationsQueryResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IOperationRepository _operationRepository;
        private readonly ILogger<GetAllOperationsQueryHandler> _logger;

        public GetAllOperationsQueryHandler(IMediator mediator, ILogger<GetAllOperationsQueryHandler> logger,
                                          IOperationRepository operationRepository)
        {
            _mediator = mediator;
            _operationRepository = operationRepository;
            _logger = logger;
        }

        public async Task<Response<GetAllOperationsQueryResponse>> Handle(GetAllOperationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _operationRepository.GetAll();

            return ProcessResponse<GetAllOperationsQueryResponse>.Success(
               new GetAllOperationsQueryResponse(result.ToList()));
        }
    }
}
