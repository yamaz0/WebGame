using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Entities.Items;
using static WebGame.Application.Functions.Players.Command.Create.CreatePlayerCommandHandler;

namespace WebGame.Application.Functions.Players.Command.Create
{
    public class CreatePlayerCommand : IRequest<CreatePlayerCommandResponse>
    {
        public string Name { get; set; }
    }
}
