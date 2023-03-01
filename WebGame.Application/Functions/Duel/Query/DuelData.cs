using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Application.Functions.Duel.Query
{
    public class DuelData
    {
        public List<string> DuelHistory { get; private set; }
        public string Message { get; private set; }
        public bool HasPlayerWon { get; private set; }

        public DuelData(bool hasPlayerWon, string message, List<string> duelHistory)
        {
            HasPlayerWon = hasPlayerWon;
            DuelHistory = duelHistory;
            Message = message;
        }
    }
}
