using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Missions.Query.GetMission
{
    public class GetMissionRequestHandler : IRequestHandler<GetMissionRequest, GetMissionViewModel>
    {
        private readonly IMissionRepository _missionRepository;
        private readonly IMapper _mapper;

        public GetMissionRequestHandler(IMissionRepository missionRepository, IMapper mapper)
        {
            _missionRepository = missionRepository;
            _mapper = mapper;
        }

        public async Task<GetMissionViewModel> Handle(GetMissionRequest request, CancellationToken cancellationToken)
        {
            var mission = await _missionRepository.GetByIdAsync(request.MissionId);
            var mappedMission = _mapper.Map<GetMissionViewModel>(mission);
            return mappedMission;
        }
    }
}
