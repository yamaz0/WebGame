using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Application.Functions.Weapons.Query.GetAllWeapons
{
    public class GetAllWeaponsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int Attack { get; set; }
        public int AttackSpeed { get; set; }
    }
}
