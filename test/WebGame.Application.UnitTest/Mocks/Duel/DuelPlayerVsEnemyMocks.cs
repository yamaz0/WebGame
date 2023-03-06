using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Duel.Command;
using WebGame.Application.Interfaces.Duel;
using WebGame.Domain.Common;

namespace WebGame.Application.UnitTest.Mocks.Duel
{
    public class DuelPlayerVsEnemyMocks
    {
        public const string MESSAGE_PLAYER_WIN = "Player won!";

        public static Mock<IDuel> GetWinDuelMocks()
        {
            var mockDuel = new Mock<IDuel>();

            mockDuel.Setup(d => d.StartDuel(It.IsAny<IDuelable>(), It.IsAny<IDuelable>()))
                .ReturnsAsync(new DuelData(true, MESSAGE_PLAYER_WIN, new List<string>() { "player deal 1 dmg to enemy." }));

            return mockDuel;
        }
    }
}
