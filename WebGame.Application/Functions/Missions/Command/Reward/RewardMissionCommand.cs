using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Missions.Command.RewardMission
{
    public class RewardMissionCommand : IRequest<BasicResponse>
    {
        public int PlayerId { get; set; }

        public RewardMissionCommand(int playerId)
        {
            PlayerId = playerId;
        }
    }
}