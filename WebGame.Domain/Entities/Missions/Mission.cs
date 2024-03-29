﻿using System.ComponentModel.DataAnnotations;
using WebGame.Domain.Common;

namespace WebGame.Entities.Missions
{
    public class Mission : AuditableEntity, ITimeAction
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int RewardExp { get; set; }
        public int RewardCash { get; set; }
    }

}
