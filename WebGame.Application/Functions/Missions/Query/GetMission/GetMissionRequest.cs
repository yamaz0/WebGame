using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Application.Functions.Missions.Query.GetMission
{
    public class GetMissionRequest : IRequest<GetMissionViewModel>
    {
        public GetMissionRequest(int id)
        {
            MissionId = id;
        }

        public int MissionId { get; set; }
    }
}
