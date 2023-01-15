using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebGame.Entities.Enemies;
using WebGame.Entities;
using WebGame.Models;
using WebGame.Services.Duel.Interface;
using System.Numerics;
using System;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WebGame.Services.Duel
{
    public class DuelService : IDualService
    {
        private readonly DbGameContext _context;

        public DuelService(DbGameContext context)
        {
            _context = context;
        }

        public DuelData DuelEnemy(string userId, int enemyId)
        {
            Enemy? enemy = GetEnemy(enemyId);
            Entities.Player? userPlayer = GetPlayer(p => p.UserId.Equals(userId));

            if (userPlayer == null || enemy == null) return null;

            PlayerVsEnemyDuel duel = new PlayerVsEnemyDuel(userPlayer, enemy);
            bool isPlayerWin = duel.Fight();

            if (isPlayerWin == true)
            {
                Reward(userPlayer, enemy);
            }

            return duel.Details;
        }

        private void Reward(Entities.Player? player, Enemy? enemy)
        {
            player.Exp += enemy.ExpReward;
            player.Cash += enemy.CashReward;
            _context.SaveChanges();
        }

        public DuelData DuelPlayer(string userId, int playerId)
        {
            Entities.Player? userPlayer = GetPlayer(p => p.UserId.Equals(userId));
            Entities.Player? enemyPlayer = GetPlayer(p => p.Id.Equals(playerId));

            if (userPlayer == null || enemyPlayer == null) return null;

            PlayerVsPlayerDuel duel = new PlayerVsPlayerDuel(userPlayer, enemyPlayer);
            bool isPlayerWin = duel.Fight();

            if (isPlayerWin == true)
            {
                userPlayer.Cash += 10;//testowe
                _context.SaveChanges();
            }
            return duel.Details;
        }

        private Enemy? GetEnemy(int enemyId)
        {
            return _context.Enemies.ToList().Find(e => e.Id.Equals(enemyId));
        }

        private Entities.Player? GetPlayer(Predicate<Entities.Player> match)
        {
            return _context.Players
                .Include(p => p.Boots)
                .Include(p => p.Armor)
                .Include(p => p.Helmet)
                .Include(p => p.Legs)
                .Include(p => p.Weapon)
                .ToList().Find(match);
        }
    }
}
