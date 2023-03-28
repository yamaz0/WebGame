using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Application.Functions.Missions.Command
{
    public class CheckMissionCommand : IRequest<CheckMissionCommandResponse>
    {
        public int PlayerId { get; set; }

        public CheckMissionCommand(int playerId)
        {
            PlayerId = playerId;
        }
    }
}
