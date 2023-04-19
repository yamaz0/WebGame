using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Constants;
using WebGame.Application.Functions.Jobs.Command.Create;
using WebGame.Application.Interfaces.Persistence.Common;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Shop.Command.BuyArmor
{
    public class BuyArmorShopCommand : IRequest<BasicResponse>
    {
        public BuyArmorShopCommand(int playerId, int armorId)
        {
            PlayerId = playerId;
            ArmorId = armorId;
        }

        public int PlayerId { get; set; }
        public int ArmorId { get; set; }
    }
}
