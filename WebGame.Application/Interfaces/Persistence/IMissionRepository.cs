﻿using WebGame.Application.Interfaces.Persistence.Common;
using WebGame.Entities.Missions;

namespace WebGame.Application.Interfaces.Persistence
{
    public interface IMissionRepository : IAsyncRepository<Mission>
    {
    }
}
