using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Shop.Command.BuyWeapon
{
    public class BuyWeaponShopCommandHandler : IRequestHandler<BuyWeaponShopCommand, BasicResponse>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IWeaponRepository _weaponRepository;

        public BuyWeaponShopCommandHandler(IPlayerRepository playerRepository, IWeaponRepository weaponRepository)
        {
            _playerRepository = playerRepository;
            _weaponRepository = weaponRepository;
        }

        public async Task<BasicResponse> Handle(BuyWeaponShopCommand request, CancellationToken cancellationToken)
        {

            var player = await _playerRepository.GetByIdAsync(request.PlayerId);
            var weapon = await _weaponRepository.GetByIdAsync(request.WeaponId);

            var validator = new BuyWeaponShopCommandValidate(_playerRepository, _weaponRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                return new BasicResponse(validatorResult);
            }

            var weaponValue = weapon.Value;
            var playerCash = player.Cash;

            if (playerCash < weaponValue)
            {
                return new BasicResponse("Not enough cash.");
            }

            player.Cash -= weaponValue;
            player.Weapon = weapon;

            await _playerRepository.UpdateAsync(player);

            return new BasicResponse();
        }
    }
}
