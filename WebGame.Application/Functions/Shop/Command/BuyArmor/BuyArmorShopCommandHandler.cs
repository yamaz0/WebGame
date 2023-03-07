using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Response;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Shop.Command.BuyArmor
{
    public class BuyArmorShopCommandHandler : IRequestHandler<BuyArmorShopCommand, BasicResponse>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IArmorRepository _armorRepository;

        public BuyArmorShopCommandHandler(IPlayerRepository playerRepository, IArmorRepository armorRepository)
        {
            _playerRepository = playerRepository;
            _armorRepository = armorRepository;
        }

        public async Task<BasicResponse> Handle(BuyArmorShopCommand request, CancellationToken cancellationToken)
        {

            var player = await _playerRepository.GetByIdAsync(request.PlayerId);
            var armor = await _armorRepository.GetByIdAsync(request.ArmorId);

            var validator = new BuyArmorShopCommandValidate(_playerRepository, _armorRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                return new BasicResponse(validatorResult);
            }

            var armorValue = armor.Value;
            var playerCash = player.Cash;

            if (playerCash < armorValue)
            {
                return new BasicResponse("Not enough cash.");
            }

            player.Cash -= armorValue;
            switch (armor.ItemType)
            {
                case ItemType.HELMET:
                    player.Helmet = armor;
                    break;
                case ItemType.ARMOR:
                    player.Armor = armor;
                    break;
                case ItemType.LEGS:
                    player.Legs = armor;
                    break;
                case ItemType.BOOTS:
                    player.Boots = armor;
                    break;
            };

            await _playerRepository.UpdateAsync(player);

            return new BasicResponse();
        }
    }
}
