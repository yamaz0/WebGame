using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Players.Query.GetAllPlayers
{
    public class GetAllPlayersRequest : IRequest<List<GetAllPlayersViewModel>>
    {

    }
}
