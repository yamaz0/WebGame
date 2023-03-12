using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Jobs.Query.GetJob;

namespace WebGame.Application.Functions.Enemies.Query.GetEnemy
{
    public class GetEnemyRequest : IRequest<GetEnemyViewModel>
    {
        public GetEnemyRequest(int id)
        {
            EnemyId = id;
        }

        public int EnemyId { get; set; }
    }
}