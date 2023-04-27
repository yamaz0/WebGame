using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Jobs.Command
{
    public class CheckJobCommand : IRequest<Response.TimeActionResponse>
    {
        public int PlayerId { get; set; }

        public CheckJobCommand(int playerId)
        {
            PlayerId = playerId;
        }
    }
}
