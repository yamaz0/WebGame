﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Armors.Query.GetAllArmors
{
    public class GetAllArmorsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int Defense { get; set; }
        public ItemType ItemType { get; set; }
    }
}
