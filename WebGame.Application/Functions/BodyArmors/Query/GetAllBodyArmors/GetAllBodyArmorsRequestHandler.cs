using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.BodyArmors.Query.GetAllBodyArmors
{
    public class GetAllBodyArmorsRequestHandler : IRequestHandler<GetAllBodyArmorsRequest, List<GetAllBodyArmorsViewModel>>
    {
        private readonly IBodyArmorRepository _bodyArmorRepository;
        private readonly IMapper _mapper;

        public GetAllBodyArmorsRequestHandler(IBodyArmorRepository bodyArmorRepository, IMapper mapper)
        {
            _bodyArmorRepository = bodyArmorRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllBodyArmorsViewModel>> Handle(GetAllBodyArmorsRequest request, CancellationToken cancellationToken)
        {
            var bodyArmor = await _bodyArmorRepository.GetAllAsync();
            var bodyArmorsViewModel = _mapper.Map<List<GetAllBodyArmorsViewModel>>(bodyArmor);
            return bodyArmorsViewModel;
        }
    }
}
