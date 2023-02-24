using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.BodyArmors.Query.GetAllBodyArmors
{
    public class GetAllArmorsRequestHandler : IRequestHandler<GetAllArmorsRequest, List<GetAllArmorsViewModel>>
    {
        private readonly IArmorRepository _armorRepository;
        private readonly IMapper _mapper;

        public GetAllArmorsRequestHandler(IArmorRepository armorRepository, IMapper mapper)
        {
            _armorRepository = armorRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllArmorsViewModel>> Handle(GetAllArmorsRequest request, CancellationToken cancellationToken)
        {
            var armor = await _armorRepository.GetAllAsync();
            var armorsViewModel = _mapper.Map<List<GetAllArmorsViewModel>>(armor);
            return armorsViewModel;
        }
    }
}
