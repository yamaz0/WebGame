using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Enemies.Query.GetAllEnemies
{
    public class GetAllEnemiesRequest : IRequest<List<GetAllEnemiesViewModel>>
    {

    }
}
