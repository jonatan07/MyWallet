using MediatR;
using MyWallet.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Commands.Wallets.Create
{
    public class CreateWalletCommand: IRequest<Response<CreateWalletCommandResponse>>
    {
        [Required]
        [StringLength(25)]
        public string DocumentId { get; set; }
        [Required]
        [StringLength(10)]
        [RegularExpression("cedula|pasaporte", ErrorMessage = "El DocumentType debe ser 'cedula' o 'pasaporte'.")]

        public string DocumentType { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
