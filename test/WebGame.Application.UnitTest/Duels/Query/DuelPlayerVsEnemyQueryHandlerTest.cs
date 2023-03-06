using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Duel.Command;
using WebGame.Application.Interfaces.Duel;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Duel;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Duels.Query
{
    public class DuelPlayerVsEnemyQueryHandlerTest
    {
        private readonly Mock<IPlayerRepository> _playerRepository;
        private readonly Mock<IEnemyRepository> _enemyRepository;

        public DuelPlayerVsEnemyQueryHandlerTest()
        {
            _playerRepository = PlayerRepositoryMocks.GetPlayerRepository();
            _enemyRepository = EnemyRepositoryMocks.GetEnemyRepository();
        }

        [Fact]
        public async void PlayerVsEnemyDuel_Should_Win()
        {
            var request = new DuelPlayerVsEnemyCommand() { EnemyId = 1, PlayerId = 1 };
            var handler = new DuelPlayerVsEnemyCommandHandler(_playerRepository.Object, _enemyRepository.Object, DuelPlayerVsEnemyMocks.GetWinDuelMocks().Object);

            var playerBefore = await _playerRepository.Object.GetByIdAsync(1);
            var playerExpBefore = playerBefore.Exp;
            var enemy = await _enemyRepository.Object.GetByIdAsync(1);

            var result = await handler.Handle(request, CancellationToken.None);

            var playerAfter = await _playerRepository.Object.GetByIdAsync(1);
            playerAfter.Exp.ShouldBe(playerExpBefore + enemy.ExpReward);
            result.DuelViewData.ShouldNotBeNull();
            result.DuelViewData.PlayerWin.ShouldBeTrue();
            result.DuelViewData.Message.ShouldBe(DuelPlayerVsEnemyMocks.MESSAGE_PLAYER_WIN);
        }
    }
}
