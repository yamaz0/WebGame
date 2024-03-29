﻿using System.Numerics;
using System;
using WebGame.Application.Interfaces.Duel;
using WebGame.Domain.Entities.Player;
using WebGame.Entities.Enemies;
using WebGame.Domain.Common;
using WebGame.Duel.Common;
using WebGame.Application.Functions.Duel.Command;

namespace WebGame.Duel
{
    public class DuelPlayerVsEnemy : IDuel
    {
        private const int MAX_ROUND = 50;

        public List<string> DuelHistory { get; private set; }
        public string Message { get; private set; }
        public bool HasPlayerWon { get; private set; }

        public DuelPlayerVsEnemy()
        {
            DuelHistory = new List<string>();
            Message = "Draw.";
        }


        public async Task<DuelData> StartDuel(IDuelable player, IDuelable enemy)
        {
            Duelist dPlayer = new Duelist(player);
            Duelist dEnemy = new Duelist(enemy);

            await Task.Run(()=>Duel(dPlayer, dEnemy)).ConfigureAwait(false);

            HasPlayerWon = dPlayer.IsAlive() && !dEnemy.IsAlive();

            return new DuelData(HasPlayerWon, Message, DuelHistory);
        }

        private void Duel(Duelist dPlayer, Duelist dEnemy)
        {
            bool isDuelOver = false;

            for (int i = 0; i < MAX_ROUND && !isDuelOver; i++)
            {
                isDuelOver = DoTurn(dPlayer, dEnemy) || DoTurn(dEnemy, dPlayer);
            }
        }

        private bool DoTurn(Duelist attacker, Duelist defender)
        {
            Attack(attacker, defender);

            bool isDuelOver = !defender.IsAlive();

            if (isDuelOver)
            {
                Message = $"{attacker.Name} win!";
            }

            return isDuelOver;
        }

        private void Attack(Duelist attacker, Duelist defender)
        {
            int damage = attacker.AttackOpponent(defender);

            DuelHistory.Add($"{attacker.Name} deal {damage} damage to {defender.Name} ");
        }
    }
}