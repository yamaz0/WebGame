using Shouldly;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebGame.Application.Functions.Duel.Query;
using WebGame.Domain.Entities.Player;
using WebGame.Duel;
using WebGame.Duel.Common;
using WebGame.Entities.Enemies;

namespace WebGame.Application.UnitTest.Duels
{
    public class DuelPlayerVsEnemyTest
    {
        [Fact]
        public void Duel_Player_Versus_Enemy_Should_Player_Win()
        {
            Duelist player = new Duelist(new Player() { Attack = 10, AttackSpeed = 10, Defense = 10, HealthPoint = 100, Name = "player" });
            Duelist enemy = new Duelist(new Enemy() { Attack = 1, AttackSpeed = 1, Defense = 1, HealthPoint = 1, Name = "enemy" });

            DuelPlayerVsEnemy duel = new DuelPlayerVsEnemy();
            var result = duel.StartDuel(player, enemy);
            result.ShouldBeOfType(typeof(DuelData));
            result.DuelHistory.Count.ShouldBeGreaterThan(0);
            result.HasPlayerWon.ShouldBeTrue();
            result.Message.ShouldNotBeNull();
        }

        [Fact]
        public void Duel_Player_Versus_Enemy_Should_Player_Lose()
        {
            Duelist player = new Duelist(new Player() { Attack = 1, AttackSpeed = 1, Defense = 1, HealthPoint = 1, Name = "player" });
            Duelist enemy = new Duelist(new Enemy() { Attack = 10, AttackSpeed = 10, Defense = 10, HealthPoint = 100, Name = "enemy" });

            DuelPlayerVsEnemy duel = new DuelPlayerVsEnemy();
            var result = duel.StartDuel(player, enemy);
            result.ShouldBeOfType(typeof(DuelData));
            result.DuelHistory.Count.ShouldBeGreaterThan(0);
            result.HasPlayerWon.ShouldBeFalse();
            result.Message.ShouldNotBeNull();
        }
    }
}
