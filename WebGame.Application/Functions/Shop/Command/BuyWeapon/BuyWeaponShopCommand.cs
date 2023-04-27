using MediatR;
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
