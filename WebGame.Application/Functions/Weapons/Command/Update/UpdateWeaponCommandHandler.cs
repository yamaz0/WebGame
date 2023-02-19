using AutoMapper;
using MediatR;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Entities.Items;

namespace WebGame.Application.Functions.Weapons.Command.Update
{
    public class UpdateWeaponCommandHandler : IRequestHandler<UpdateWeaponCommand>
    {
        private readonly IWeaponRepository _weaponRepository;
        private readonly IMapper _mapper;

        public UpdateWeaponCommandHandler(IWeaponRepository weaponRepository, IMapper mapper)
        {
            _weaponRepository = weaponRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWeaponCommand request, CancellationToken cancellationToken)
        {
            var mappedWeapon = _mapper.Map<Weapon>(request);

            await _weaponRepository.UpdateAsync(mappedWeapon);

            return Unit.Value;
        }
    }
}
