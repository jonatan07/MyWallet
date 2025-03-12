using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Queries.Wallets.GetAll
{
    public record WalletItem{ 
        public int Id { get; set; }
        public string DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string Name { get; set; }
    }
    public class GetAllWalletsQueryResponse
    {
        
        public List<WalletItem> Wallets { get; } = [];

        public GetAllWalletsQueryResponse(List<Wallet> wallets)
        {
            foreach (var wallet in wallets)
            {
                Wallets.Add(new WalletItem { Id =wallet.Id, DocumentId= wallet.DocumentId, DocumentType= wallet.DocumentType, Name= wallet.Name });
            }
        }
        
    }
}
