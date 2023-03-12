using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Missions.Command.Delete
{
    public class DeleteMissionCommand : IRequest
    {
        public DeleteMissionCommand(int id)
        {
            MissionId= id;
        }

        public int MissionId { get; set; }
    }
}
