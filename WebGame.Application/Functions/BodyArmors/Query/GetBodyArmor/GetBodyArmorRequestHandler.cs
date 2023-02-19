using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;

namespace WebGame.Application.Functions.Enemies.Query.GetBodyArmor
{
    public class GetBodyArmorRequestHandler : IRequestHandler<GetBodyArmorRequest, GetBodyArmorViewModel>
    {
        private readonly IBodyArmorRepository _bodyArmorRepository;
        private readonly IMapper _mapper;

        public GetBodyArmorRequestHandler(IBodyArmorRepository bodyArmorRepository, IMapper mapper)
        {
            _bodyArmorRepository = bodyArmorRepository;
            _mapper = mapper;
        }

        public async Task<GetBodyArmorViewModel> Handle(GetBodyArmorRequest request, CancellationToken cancellationToken)
        {
            var bodyArmor = await _bodyArmorRepository.GetByIdAsync(request.BodyArmorId);
            var mappedBodyArmor = _mapper.Map<GetBodyArmorViewModel>(bodyArmor);
            return mappedBodyArmor;
        }
    }
}
