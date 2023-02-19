using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.BodyArmors.Command.Update
{
    public class UpdateBodyArmorCommandHandler : IRequestHandler<UpdateBodyArmorCommand>
    {
        private readonly IBodyArmorRepository _bodyArmorRepository;
        private readonly IMapper _mapper;

        public UpdateBodyArmorCommandHandler(IBodyArmorRepository bodyArmorRepository, IMapper mapper)
        {
            _bodyArmorRepository = bodyArmorRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBodyArmorCommand request, CancellationToken cancellationToken)
        {
            var mappedBodyArmor = _mapper.Map<BodyArmor>(request);

            await _bodyArmorRepository.UpdateAsync(mappedBodyArmor);

            return Unit.Value;
        }
    }
}
