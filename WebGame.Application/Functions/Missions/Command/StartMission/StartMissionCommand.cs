using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Application.Functions.Missions.Command.StartMission
{
    public class StartMissionCommand : IRequest<StartMissionCommandResponse>
    {
        public int MissionId { get; set; }
        public int PlayerId { get; set; }

        public StartMissionCommand(int playerId, int missionId)
        {
            PlayerId = playerId;
            MissionId = missionId;
        }
    }
}