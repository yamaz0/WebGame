using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Entities.Items;
using static WebGame.Application.Functions.Missions.Command.Create.CreateMissionCommandHandler;

namespace WebGame.Application.Functions.Missions.Command.Create
{
    public class CreateMissionCommand : IRequest<CreateMissionCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Reward { get; set; }
    }
}
