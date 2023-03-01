using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Duel.Query;
using WebGame.Application.Interfaces.Duel;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.UnitTest.Mocks.Duel;
using WebGame.Application.UnitTest.Mocks.Repository;

namespace WebGame.Application.UnitTest.Duels.Query
{
    public class DuelPlayerVsEnemyTest
    {
        private readonly Mock<IPlayerRepository> _playerRepository;
        private readonly Mock<IEnemyRepository> _enemyRepository;

        public DuelPlayerVsEnemyTest()
        {
            _playerRepository = PlayerRepositoryMocks.GetPlayerRepository();
            _enemyRepository = EnemyRepositoryMocks.GetEnemyRepository();
        }

        [Fact]
        public async void PlayerVsEnemyDuel_Should_Win()
        {
            var request = new DuelPlayerVsEnemyQuery() { EnemyId = 1, PlayerId = 1 };
            var handler = new DuelPlayerVsEnemyQueryHandler(_playerRepository.Object, _enemyRepository.Object, DuelPlayerVsEnemyMocks.GetWinDuelMocks().Object);
            var result = await handler.Handle(request, CancellationToken.None);
            result.PlayerWin.ShouldBeTrue();
            result.Message.ShouldBe(DuelPlayerVsEnemyMocks.MESSAGE_PLAYER_WIN);
        }
    }
}
