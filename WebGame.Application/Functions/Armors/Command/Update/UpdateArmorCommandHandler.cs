using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.BodyArmors.Command.Update
{
    public class UpdateArmorCommandHandler : IRequestHandler<UpdateArmorCommand>
    {
        private readonly IArmorRepository _armorRepository;
        private readonly IMapper _mapper;

        public UpdateArmorCommandHandler(IArmorRepository armorRepository, IMapper mapper)
        {
            _armorRepository = armorRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateArmorCommand request, CancellationToken cancellationToken)
        {
            var mappedArmor = _mapper.Map<Armor>(request);

            await _armorRepository.UpdateAsync(mappedArmor);

            return Unit.Value;
        }
    }
}
