using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Constants;
using WebGame.Application.Functions.Jobs.Command.Create;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Interfaces.Persistence.Common;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Shop.Query
{
    public class BuyWeaponShopCommand : IRequest<BasicResponse>
    {
        public int PlayerId { get; set; }
        public int WeaponId { get; set; }
    }

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
