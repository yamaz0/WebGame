using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WebGame.Application.Response;
using WebGame.Entities.Enemies;

namespace WebGame.Application.Functions.Duel.Query
{
    public class DuelPlayerVsEnemyQuery : IRequest<DuelViewData>
    {
        public int PlayerId { get; set; }
        public int EnemyId { get; set; }
    }
}
