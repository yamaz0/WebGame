using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebGame.Entities.Enemies;
using WebGame.Entities;
using WebGame.Models;
using WebGame.Services.Duel.Interface;
using System.Numerics;
using System;

namespace WebGame.Services.Duel
{
    public class DuelService : IDualService
    {
        private readonly DbGameContext _context;

        public DuelService(DbGameContext context)
        {
            _context = context;
        }

        public DuelData DuelEnemy(int enemyId)
        {
            Enemy? enemy = GetEnemy(enemyId);
            Entities.Player? player = GetPlayer(0);

            if (player == null || enemy == null) return null;

            PlayerVsEnemyDuel duel = new PlayerVsEnemyDuel(player, enemy);
            bool isPlayerWin = duel.Fight();

            if (isPlayerWin == true)
            {
                Reward(player, enemy);
            }

            return duel.Details;
        }

        private void Reward(Entities.Player? player, Enemy? enemy)
        {
            player.Exp += enemy.ExpReward;
            player.Cash += enemy.CashReward;
            _context.SaveChanges();
        }

        public DuelData DuelPlayer(int playerId)
        {
            Entities.Player? enemy = GetPlayer(playerId);
            Entities.Player? player = GetPlayer(0);

            if (player == null || enemy == null) return null;

            PlayerVsPlayerDuel duel = new PlayerVsPlayerDuel(player, enemy);
            bool isPlayerWin = duel.Fight();

            if (isPlayerWin == true)
            {
                player.Cash += 10;//testowe
                _context.SaveChanges();
            }
            return duel.Details;
        }

        private Enemy? GetEnemy(int enemyId)
        {
            return _context.Enemies.ToList().Find(e => e.Id == enemyId);
        }

        private Entities.Player? GetPlayer(int id)
        {
            return _context.Players
                .Include(p => p.Boots)
                .Include(p => p.Armor)
                .Include(p => p.Helmet)
                .Include(p => p.Legs)
                .Include(p => p.Weapon)
                .ToList().FirstOrDefault();
        }
    }
}
