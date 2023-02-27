using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Enemies.Query.GetArmor
{
    public class GetArmorRequestHandler : IRequestHandler<GetArmorRequest, GetArmorViewModel>
    {
        private readonly IArmorRepository _armorRepository;
        private readonly IMapper _mapper;

        public GetArmorRequestHandler(IArmorRepository armorRepository, IMapper mapper)
        {
            _armorRepository = armorRepository;
            _mapper = mapper;
        }

        public async Task<GetArmorViewModel> Handle(GetArmorRequest request, CancellationToken cancellationToken)
        {
            var armor = await _armorRepository.GetByIdAsync(request.ArmorId);
            var mappedArmor = _mapper.Map<GetArmorViewModel>(armor);
            return mappedArmor;
        }
    }
}
