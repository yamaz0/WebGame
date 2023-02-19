using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Missions.Query.GetAll
{
    public class GetAllMissionsRequestHandler : IRequestHandler<GetAllMissionsRequest, List<GetAllMissionsViewModel>>
    {
        private readonly IMissionRepository _missionRepository;
        private readonly IMapper _mapper;

        public GetAllMissionsRequestHandler(IMissionRepository missionRepository, IMapper mapper)
        {
            _missionRepository = missionRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllMissionsViewModel>> Handle(GetAllMissionsRequest request, CancellationToken cancellationToken)
        {
            var missions = await _missionRepository.GetAllAsync();
            var missionsViewModel = _mapper.Map<List<GetAllMissionsViewModel>>(missions);
            return missionsViewModel;
        }
    }
}
