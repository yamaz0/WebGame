using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Domain.Common;
using WebGame.Domain.Entities.Player;

namespace WebGame.Application.UnitTest.Players.Logic
{
    public class RewardTest
    {
        public RewardTest()
        {

        }


        [Fact]
        public void Test()
        {
            Player player = new Player();
            //int playerExpBefore = player.Exp;
            //int playerLeveleBefore = player.Level;
            int playerCashBefore = player.Cash;

            player.AddReward(100, 0);

            int playerExpAfter = player.Exp;
            int playerLevelAfter = player.Level;
            int playerCashAfter = player.Cash;
                        

            playerExpAfter.ShouldBe(0);
            playerLevelAfter.ShouldBe(5);
            playerCashAfter.ShouldBe(playerCashBefore);
        }
    }
}
