using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Domain.PlayerStatsEnum;
using WebGame.Domain.TimeActionEnum;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Players.Command.AddedStats
{
    public class AddedStatsPlayerCommand : IRequest
    {
        public int PlayerId { get; set; }
        public Statistic Statistic { get; set; }
    }
}
