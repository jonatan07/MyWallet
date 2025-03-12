using MediatR;
using MyWallet.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Commands.Wallets.Update
{
    public class UpdateWalletCommandResponse:IRequest<Response<UpdateWalletCommandResponse>>
    {
        public int Id { get; }
        public string Name { get; set; }
        public string DocumentId { get; set; }
        public string DocumentType { get; set; }
        public UpdateWalletCommandResponse(int id,string name,string documentId,string documentType)
        {
            Id = id;
            Name = name;
            DocumentId = documentId;
            DocumentType = documentType;
        }
    }
}
