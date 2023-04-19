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

namespace WebGame.Application.Functions.Shop.Command.BuyWeapon
{
    public class BuyWeaponShopCommand : IRequest<BasicResponse>
    {
        public int PlayerId { get; set; }
        public int WeaponId { get; set; }

        public BuyWeaponShopCommand(int playerId, int weaponId)
        {
            PlayerId = playerId;
            WeaponId = weaponId;
        }
    }
}
