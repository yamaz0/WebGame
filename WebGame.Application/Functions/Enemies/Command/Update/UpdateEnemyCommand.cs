using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Enemies.Command.Update
{
    public class UpdateEnemyCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HealthPoint { get; set; }
        public int Attack { get; set; }
        public int ExpReward { get; set; }
        public int CashReward { get; set; }
    }
}
