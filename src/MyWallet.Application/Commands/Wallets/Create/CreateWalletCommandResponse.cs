using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Commands.Wallets.Create
{
    public class CreateWalletCommandResponse
    {
        public int Id { get; }

        public CreateWalletCommandResponse(int id)
        {
            Id = id;
        }
    }
}
