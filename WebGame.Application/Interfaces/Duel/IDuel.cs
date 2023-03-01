using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Functions.Duel.Query;
using WebGame.Domain.Common;

namespace WebGame.Application.Interfaces.Duel
{
    public interface IDuel
    {
        DuelData StartDuel(IDuelable player, IDuelable opponent);
    }
}
