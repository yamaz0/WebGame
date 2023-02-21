﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Domain.Common
{
    public interface IDuelable
    {
        public int HealthPoint { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public int AttackSpeed { get; set; }
    }
}