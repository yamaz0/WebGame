using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Response;
using WebGame.Domain.Common;
using WebGame.Domain.Entities.Player;
using WebGame.Domain.TimeActionEnum;

namespace WebGame.Application.Interfaces.TimeAction
{
    public interface ITimeActionService
    {
        Task<TimeActionResponse> Check(int id, TimeActionType actionType);
        Task<bool> RewardPlayer(Player player, ITimeAction action, TimeActionType actionType);
        Task<bool> RewardPlayer(Player player, TimeActionType actionType, int rewardExp, int rewardCash);
        Task<bool> SetActionToPlayer(int id, TimeActionType actionType, ITimeAction action);
        Task<bool> SetActionToPlayer(int id, TimeActionType actionType, int actionId, int duration);
    }
}
