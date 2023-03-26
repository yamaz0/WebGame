using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Application.Functions.Players.Query.GetPlayer
{
    public class GetPlayerAllInfoRequest : IRequest<GetPlayerAllInfoViewModel>
    {
        public int PlayerId { get; set; }
    }
}
