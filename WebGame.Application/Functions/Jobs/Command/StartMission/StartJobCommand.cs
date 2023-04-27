using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Jobs.Command.StartJob
{
    public class StartJobCommand : IRequest<BasicResponse>
    {
        public int Duration { get; set; }
        public int PlayerId { get; set; }

        public StartJobCommand(int playerId, int duration)
        {
            PlayerId = playerId;
            Duration = duration;
        }
    }
}