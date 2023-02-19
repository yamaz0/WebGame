using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Missions.Command.Delete
{
    public class DeleteMissionCommandHandler : IRequestHandler<DeleteMissionCommand>
    {
        private readonly IMissionRepository _missionRepository;

        public DeleteMissionCommandHandler(IMissionRepository missionRepository)
        {
            _missionRepository = missionRepository;
        }
        public async Task<Unit> Handle(DeleteMissionCommand request, CancellationToken cancellationToken)
        {
            var missionToDelete = await _missionRepository.GetByIdAsync(request.MissionId);
            await _missionRepository.RemoveAsync(missionToDelete);
            return Unit.Value;
        }
    }
}
