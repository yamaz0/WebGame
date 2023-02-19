using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Application.Functions.Enemies.Query.GetAllEnemies
{
    public class GetAllEnemiesViewModel
    {
        public string Name { get; set; }
        public int HealthPoint { get; set; }
        public int Attack { get; set; }
        public int ExpReward { get; set; }
        public int CashReward { get; set; }
    }
}
