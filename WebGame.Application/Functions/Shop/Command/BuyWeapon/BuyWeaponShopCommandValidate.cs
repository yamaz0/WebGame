using FluentValidation;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Shop.Command.BuyWeapon
{
    public class BuyWeaponShopCommandValidate : AbstractValidator<BuyWeaponShopCommand>
    {
        private const string PLAYER_NOT_EXIST_MESSAGE = "Player not exist.";
        private const string WEAPON_NOT_EXIST_MESSAGE = "Weapon not exist.";

        private readonly IPlayerRepository _playerRepository;
        private readonly IWeaponRepository _weaponRepository;

        public BuyWeaponShopCommandValidate(IPlayerRepository playerRepository, IWeaponRepository weaponRepository)
        {
            _playerRepository = playerRepository;
            _weaponRepository = weaponRepository;

            RuleFor(x => x.PlayerId).NotNull().MustAsync(PlayerExist).WithMessage(PLAYER_NOT_EXIST_MESSAGE);
            RuleFor(x => x.WeaponId).NotNull().MustAsync(WeaponExist).WithMessage(WEAPON_NOT_EXIST_MESSAGE);
        }

        private async Task<bool> PlayerExist(int id, CancellationToken token)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            return player != null;
        }

        private async Task<bool> WeaponExist(int id, CancellationToken token)
        {
            var weapon = await _weaponRepository.GetByIdAsync(id);
            return weapon != null;
        }
    }
}
