using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyWallet.Application.Queries.Operations.GetAll
{
    public record OperationItem
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
    }
    public class GetAllOperationsQueryResponse
    {
        public List<OperationItem> Operations { get; } = [];

        public GetAllOperationsQueryResponse(List<MyWallet.Domain.Entities.Operations> transactions)
        {
            foreach (var operation in transactions)
            {
                Operations.Add(new OperationItem { Id = operation.Id, 
                                                   WalletId = operation.WalletId,
                                                   Amount = operation.Amount,
                                                   Type = operation.Type
                });
            }
        }
    }
}
