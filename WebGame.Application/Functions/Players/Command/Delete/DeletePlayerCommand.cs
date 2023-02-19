using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Players.Command.Delete
{
    public class DeletePlayerCommand : IRequest
    {
        public int PlayerId { get; set; }
    }
}
