﻿using System.ComponentModel.DataAnnotations;

namespace WebGame.Entities
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
