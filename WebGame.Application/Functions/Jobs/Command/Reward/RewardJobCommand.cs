using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Jobs.Command.RewardJob
{
    public class RewardJobCommand : IRequest<BasicResponse>
    {
        public int PlayerId { get; set; }

        public RewardJobCommand(int playerId)
        {
            PlayerId = playerId;
        }
    }
}