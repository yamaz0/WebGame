using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Entities.Items;
using static WebGame.Application.Functions.Enemies.Command.Create.CreateEnemyCommandHandler;

namespace WebGame.Application.Functions.Enemies.Command.Create
{
    public class CreateEnemyCommand : IRequest<CreateEnemyCommandResponse>
    {
        public string Name { get; set; }
        public int HealthPoint { get; set; }
        public int Attack { get; set; }
        public int ExpReward { get; set; }
        public int CashReward { get; set; }
    }
}

