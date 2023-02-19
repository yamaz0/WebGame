﻿using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Enemies.Query.GetBodyArmor
{
    public class GetBodyArmorViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int Defense { get; set; }
        public ItemType ItemType { get; set; }
    }
}
