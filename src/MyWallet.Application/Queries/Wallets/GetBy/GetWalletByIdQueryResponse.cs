using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Queries.Wallets.GetBy
{
    public class GetWalletByIdQueryResponse
    {
        public int Id { get; }
        public string DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string Name { get; set; }

        public GetWalletByIdQueryResponse(int id,string documentId,string documentType,string name)
        {
            Id = id;
            DocumentId = documentId;
            DocumentType = documentType;
            Name = name;

        }
    }
}
