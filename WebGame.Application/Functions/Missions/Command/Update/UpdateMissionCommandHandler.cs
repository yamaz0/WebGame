using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Missions;

namespace WebGame.Application.Functions.Missions.Command.Update
{
    public class UpdateMissionCommandHandler : IRequestHandler<UpdateMissionCommand>
    {
        private readonly IMissionRepository _missionRepository;
        private readonly IMapper _mapper;

        public UpdateMissionCommandHandler(IMissionRepository missionRepository, IMapper mapper)
        {
            _missionRepository = missionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMissionCommand request, CancellationToken cancellationToken)
        {
            var mappedMission = _mapper.Map<Mission>(request);

            await _missionRepository.UpdateAsync(mappedMission);

            return Unit.Value;
        }
    }
}
