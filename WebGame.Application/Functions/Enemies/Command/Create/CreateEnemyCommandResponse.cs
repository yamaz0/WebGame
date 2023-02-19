using FluentValidation.Results;
using WebGame.Application.Response;

namespace WebGame.Application.Functions.Enemies.Command.Create
{
    public class CreateEnemyCommandResponse : BasicResponse
    {
        public int? EnemyId { get; set; }

        public CreateEnemyCommandResponse(ValidationResult result) : base(result)
        {
        }

        public CreateEnemyCommandResponse(int? enemyId)
        {
            EnemyId = enemyId;
        }
    }
}

