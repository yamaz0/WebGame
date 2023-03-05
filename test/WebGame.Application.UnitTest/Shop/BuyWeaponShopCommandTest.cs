using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;
using WebGame.Application.Functions.Shop.Query;
using Shouldly;
using WebGame.Application.Response;
using WebGame.Domain.Entities.Player;
using WebGame.Entities.Items;

namespace WebGame.Application.UnitTest.Shop
{
    public class BuyWeaponShopCommandTest
    {
        private const int PLAYER_ID = 1;
        private const int WEAPON_ID = 1;
        private const int WEAPON_ID_WITH_HIGH_STATS = 2;
        private readonly Mock<IPlayerRepository> _mockPlayerRepository;
        private readonly Mock<IWeaponRepository> _mockWeaponRepository;

        public BuyWeaponShopCommandTest()
        {
            _mockPlayerRepository = PlayerRepositoryMocks.GetPlayerRepository();
            _mockWeaponRepository = WeaponRepositoryMocks.GetWeaponRepository();
        }

        [Fact]
        public async void Transaction_Should_Succesfull_Complete()
        {
            var command = new BuyWeaponShopCommand() { PlayerId = PLAYER_ID, WeaponId = WEAPON_ID };
            var handler = new BuyWeaponShopCommandHandler(_mockPlayerRepository.Object, _mockWeaponRepository.Object);

            Player playerBefore = await _mockPlayerRepository.Object.GetByIdAsync(PLAYER_ID);
            Weapon weapon = await _mockWeaponRepository.Object.GetByIdAsync(WEAPON_ID);

            var cashBefore = playerBefore.Cash;
            var weaponValue = weapon.Value;

            var response = await handler.Handle(command, CancellationToken.None);

            Player playerAfter = (await _mockPlayerRepository.Object.GetByIdAsync(PLAYER_ID));
            var cashAfter = playerAfter.Cash;
            var weaponAfter = playerAfter.Weapon;

            cashAfter.ShouldBe(cashBefore - weaponValue);
            weaponAfter.Id.ShouldBe(weapon.Id);
            response.Success.ShouldBeTrue();
            response.Errors.Count.ShouldBe(0);
            response.ShouldBeOfType(typeof(BasicResponse));
        }

        [Fact]
        public async void Transaction_Should_Not_Found_Player_And_Weapon()
        {
            var command = new BuyWeaponShopCommand() { };
            var handler = new BuyWeaponShopCommandHandler(_mockPlayerRepository.Object, _mockWeaponRepository.Object);

            var response = await handler.Handle(command, CancellationToken.None);

            response.Success.ShouldBeFalse();
            response.Errors.Count.ShouldBeGreaterThan(1);
            response.ShouldBeOfType(typeof(BasicResponse));
        }

        [Fact]
        public async void Player_Should_Not_Have_Enough_Money()
        {
            var command = new BuyWeaponShopCommand() { PlayerId = PLAYER_ID, WeaponId = WEAPON_ID_WITH_HIGH_STATS };
            var handler = new BuyWeaponShopCommandHandler(_mockPlayerRepository.Object, _mockWeaponRepository.Object);

            var response = await handler.Handle(command, CancellationToken.None);

            response.Success.ShouldBeFalse();
            response.Errors.Count.ShouldBe(1);
            response.ShouldBeOfType(typeof(BasicResponse));
        }
    }
}
