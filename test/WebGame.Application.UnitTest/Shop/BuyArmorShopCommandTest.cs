using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Repository;
using Shouldly;
using WebGame.Application.Response;
using WebGame.Domain.Entities.Player;
using WebGame.Entities.Items;
using WebGame.Application.Functions.Shop.Command.BuyArmor;

namespace WebGame.Application.UnitTest.Shop
{
    public class BuyArmorShopCommandTest
    {
        private const int PLAYER_ID = 1;
        private const int ARMOR_ID = 1;
        private const int ARMOR_ID_WITH_HIGH_STATS = 5;
        private readonly Mock<IPlayerRepository> _mockPlayerRepository;
        private readonly Mock<IArmorRepository> _mockArmorRepository;

        public BuyArmorShopCommandTest()
        {
            _mockPlayerRepository = PlayerRepositoryMocks.GetPlayerRepository();
            _mockArmorRepository = ArmorRepositoryMocks.GetArmorRepository();
        }

        [Fact]
        public async void Transaction_Should_Succesfull_Complete()
        {
            var command = new BuyArmorShopCommand(PLAYER_ID, ARMOR_ID);
            var handler = new BuyArmorShopCommandHandler(_mockPlayerRepository.Object, _mockArmorRepository.Object);

            Player playerBefore = await _mockPlayerRepository.Object.GetByIdAsync(PLAYER_ID);
            Armor armor = await _mockArmorRepository.Object.GetByIdAsync(ARMOR_ID);

            var cashBefore = playerBefore.Cash;
            var armorValue = armor.Value;

            var response = await handler.Handle(command, CancellationToken.None);

            Player playerAfter = (await _mockPlayerRepository.Object.GetByIdAsync(PLAYER_ID));
            var cashAfter = playerAfter.Cash;
            var armorAfter = playerAfter.Helmet;

            cashAfter.ShouldBe(cashBefore - armorValue);
            armorAfter.Id.ShouldBe(armor.Id);
            response.Success.ShouldBeTrue();
            response.Errors.Count.ShouldBe(0);
            response.ShouldBeOfType(typeof(BasicResponse));
        }

        [Fact]
        public async void Transaction_Should_Not_Found_Player_And_Armor()
        {
            var command = new BuyArmorShopCommand(0,0);
            var handler = new BuyArmorShopCommandHandler(_mockPlayerRepository.Object, _mockArmorRepository.Object);

            var response = await handler.Handle(command, CancellationToken.None);

            response.Success.ShouldBeFalse();
            response.Errors.Count.ShouldBeGreaterThan(1);
            response.ShouldBeOfType(typeof(BasicResponse));
        }

        [Fact]
        public async void Player_Should_Not_Have_Enough_Money()
        {
            var command = new BuyArmorShopCommand(PLAYER_ID, ARMOR_ID_WITH_HIGH_STATS);
            var handler = new BuyArmorShopCommandHandler(_mockPlayerRepository.Object, _mockArmorRepository.Object);

            var response = await handler.Handle(command, CancellationToken.None);

            response.Success.ShouldBeFalse();
            response.Errors.Count.ShouldBe(1);
            response.ShouldBeOfType(typeof(BasicResponse));
        }
    }
}
