using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Response;

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
            player.Armor = armor;

            await _playerRepository.UpdateAsync(player);

            return new BasicResponse();
        }
    }
}
