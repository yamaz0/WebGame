using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Domain.Entities.Player;
using static WebGame.Application.Functions.Players.Command.Create.CreatePlayerCommandHandler;

namespace WebGame.Application.Functions.Players.Command.Create
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, CreatePlayerCommandResponse>
    {
        private readonly IPlayerRepository _playerRepository;

        public CreatePlayerCommandHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<CreatePlayerCommandResponse> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePlayerCommandValidate();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.IsValid)
            {
                return new CreatePlayerCommandResponse(validatorResult);
            }

            Player player = new Player()
            {
                Name = request.Name,
            };

            player = await _playerRepository.AddAsync(player);
            return new CreatePlayerCommandResponse(player.Id);
        }
    }
}
