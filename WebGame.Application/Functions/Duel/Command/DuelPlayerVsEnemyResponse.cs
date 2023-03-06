using FluentValidation.Results;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Duel.Command
{
    public class DuelPlayerVsEnemyResponse : BasicResponse
    {
        public DuelViewData? DuelViewData { get; set; }

        public DuelPlayerVsEnemyResponse(ValidationResult result) : base(result)
        {

        }

        public DuelPlayerVsEnemyResponse(DuelViewData? duelViewData)
        {
            DuelViewData = duelViewData;
        }
    }
}
