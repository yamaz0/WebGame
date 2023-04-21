using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Missions.Command
{
    public class CheckMissionCommand : IRequest<Response.TimeActionResponse>
    {
        public int PlayerId { get; set; }

        public CheckMissionCommand(int playerId)
        {
            PlayerId = playerId;
        }
    }
}
