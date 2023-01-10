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

            PlayerVsEnemyDuel fight = new PlayerVsEnemyDuel(player, enemy);
            fight.Fight();
            return fight.Details;
        }

        public DuelData DuelPlayer(int playerId)
        {
            Entities.Player? enemy = GetPlayer(playerId);
            Entities.Player? player = GetPlayer(0);

            if (player == null || enemy == null) return null;

            PlayerVsPlayerDuel fight = new PlayerVsPlayerDuel(player, enemy);
            fight.Fight();
            return fight.Details;
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
