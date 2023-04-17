using MediatR;
using WebGame.Application.Interfaces.Duel;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Interfaces.TimeAction;
using WebGame.Application.Response;
using WebGame.Domain.Common;
using WebGame.Domain.Entities.Player;
using WebGame.Domain.TimeActionEnum;

namespace WebGame.TimeAction
{

    public class TimeActionService : ITimeActionService
    {
        private readonly IPlayerRepository _playerRepository;

        public TimeActionService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<bool> SetActionToPlayer(int id, TimeActionType actionType, ITimeAction action)
        {
            Player player = await GetPlayer(id);

            if (player is not null && player.ActionState == TimeActionState.NoAction)
            {
                player.ActionId = action.Id;
                player.ActionType = actionType;
                player.ActionState = TimeActionState.InProgress;
                player.EndTime = DateTime.UtcNow.AddMinutes(action.Duration);
                await _playerRepository.UpdateAsync(player);

                return true;
            }

            return false;
        }

        public async Task<bool> RewardPlayer(Player player, ITimeAction action, TimeActionType actionType)
        {
            if (player.ActionState == TimeActionState.Finished && player.ActionType == actionType)
            {
                player.ActionState = TimeActionState.NoAction;
                player.ActionId = 0;
                player.AddReward(action.RewardExp, action.RewardCash);
                await _playerRepository.UpdateAsync(player);

                return true;
            }

            return false;
        }

        public async Task<TimeActionResponse> Check(int id, TimeActionType actionType)
        {
            Player player = await GetPlayer(id);

            await TryUpdateState(player, actionType);

            var stateResponse = GetActionTimeStateResponse(player, actionType);

            return new TimeActionResponse(stateResponse, player.EndTime);
        }

        private async Task<Player> GetPlayer(int id)
        {
            return await _playerRepository.GetByIdAsync(id);
        }

        private bool HasActionEnded(Player player)
        {
            return player.EndTime < DateTime.UtcNow;
        }

        private async Task TryUpdateState(Player player, TimeActionType actionType)
        {
            if (player.ActionType == actionType
                && player.ActionState == TimeActionState.InProgress
                && HasActionEnded(player))
            {
                player.ActionState = TimeActionState.Finished;
                await _playerRepository.UpdateAsync(player);
            }
        }

        private TimeActionStateResponse GetActionTimeStateResponse(Player player, TimeActionType actionType)
        {
            TimeActionStateResponse timeActionStateResponse = TimeActionStateResponse.NoAction;

            switch (player.ActionState)
            {
                case TimeActionState.NoAction:
                    break;
                case TimeActionState.InProgress:
                    timeActionStateResponse = player.ActionType == actionType ? TimeActionStateResponse.InProgress : TimeActionStateResponse.OtherAction;
                    break;
                case TimeActionState.Finished:
                    timeActionStateResponse = TimeActionStateResponse.Finished;
                    break;
                default:
                    break;
            }

            return timeActionStateResponse;
        }
    }
}