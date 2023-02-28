using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Missions;
using static WebGame.Application.Functions.Missions.Command.Create.CreateMissionCommandHandler;

namespace WebGame.Application.Functions.Missions.Command.Create
{
    public class CreateMissionCommandHandler : IRequestHandler<CreateMissionCommand, CreateMissionCommandResponse>
    {
        private readonly IMissionRepository _missionRepository;

        public CreateMissionCommandHandler(IMissionRepository missionRepository)
        {
            _missionRepository = missionRepository;
        }

        public async Task<CreateMissionCommandResponse> Handle(CreateMissionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMissionCommandValidate();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                return new CreateMissionCommandResponse(validatorResult);
            }

            Mission mission = new Mission()
            {
                Name = request.Name,
                Description = request.Description,
                Duration = request.Duration,
                Reward = request.Reward
            };

            mission = await _missionRepository.AddAsync(mission);
            return new CreateMissionCommandResponse(mission.Id);
        }
    }
}
