using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence.Common;
using WebGame.Domain.Entities.Player;

namespace WebGame.Application.Interfaces.Persistence
{
    public interface IPlayerRepository : IAsyncRepository<Player>
    {
    }
}
