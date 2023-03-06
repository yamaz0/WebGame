using FluentValidation;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Shop.Command.BuyArmor
{
    public class BuyArmorShopCommandValidate : AbstractValidator<BuyArmorShopCommand>
    {
        private const string PLAYER_NOT_EXIST_MESSAGE = "Player not exist.";
        private const string WEAPON_NOT_EXIST_MESSAGE = "Armor not exist.";

        private readonly IPlayerRepository _playerRepository;
        private readonly IArmorRepository _armorRepository;

        public BuyArmorShopCommandValidate(IPlayerRepository playerRepository, IArmorRepository armorRepository)
        {
            _playerRepository = playerRepository;
            _armorRepository = armorRepository;

            RuleFor(x => x.PlayerId).NotNull().MustAsync(PlayerExist).WithMessage(PLAYER_NOT_EXIST_MESSAGE);
            RuleFor(x => x.ArmorId).NotNull().MustAsync(ArmorExist).WithMessage(WEAPON_NOT_EXIST_MESSAGE);
        }

        private async Task<bool> PlayerExist(int id, CancellationToken token)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            return player != null;
        }

        private async Task<bool> ArmorExist(int id, CancellationToken token)
        {
            var armor = await _armorRepository.GetByIdAsync(id);
            return armor != null;
        }
    }
}
