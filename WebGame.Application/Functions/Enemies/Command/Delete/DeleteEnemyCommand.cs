using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Enemies.Command.Delete
{
    public class DeleteEnemyCommand : IRequest
    {
        public int EnemyId { get; set; }
    }
}
