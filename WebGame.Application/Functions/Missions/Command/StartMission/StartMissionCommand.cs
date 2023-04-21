using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Missions.Command.StartMission
{
    public class StartMissionCommand : IRequest<BasicResponse>
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